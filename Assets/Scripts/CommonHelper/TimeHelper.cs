using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class TimeHelper
{
    private static int timerID;
    private static Dictionary<int, Action> timerFuncDic;
    private static Dictionary<int, GameObject> timerObjects;

    /// <summary>
    /// 静态构造函数
    /// </summary>
    static TimeHelper()
    {
        timerID = 1;
        timerFuncDic = new Dictionary<int, Action>();
        timerObjects = new Dictionary<int, GameObject>();
    }

    /// <summary>
    /// 设置一个单次计时器
    /// </summary>
    /// <param name="action"></param>
    /// <param name="time"></param>
    /// <param name="isIgnoreTimeScale"></param>
    /// <returns></returns>
    public static int SetTimer(Action action, float time, bool isIgnoreTimeScale)
    {
        int tmpTimerID = int.MaxValue;
        if (null != action && time > 0.0f)
        {
            tmpTimerID = GetTimerID();
            GameObject timerTmpObj = new GameObject();
            GameObject.DontDestroyOnLoad(timerTmpObj);
            timerTmpObj.name = tmpTimerID.ToString();

            TimerBehavior timerBehavior = timerTmpObj.AddComponent<TimerBehavior>();
            timerFuncDic.Add(tmpTimerID,action);
            timerObjects.Add(tmpTimerID,timerTmpObj);
            timerBehavior.BeginTimer(TimerEndEvent,tmpTimerID,time,isIgnoreTimeScale);
        }
        return tmpTimerID;
    }

    /// <summary>
    /// 设置一个受TimeScale影响的单次计时器
    /// </summary>
    /// <param name="action"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static int SetTimer(Action action, float time)
    {
        return SetTimer(action, time, false);
    }

    /// <summary>
    /// 设置一个重复调用的多次计时器
    /// </summary>
    /// <param name="action"></param>
    /// <param name="time"></param>
    /// <param name="isIgnoreTimeScale"></param>
    /// <returns></returns>
    public static int SetRepeatTimer(Action action, float time, bool isIgnoreTimeScale)
    {
        int tmpTimerID = -1;
        if (null != action && time > 0)
        {
            tmpTimerID = GetTimerID();
            GameObject timerTmpObj = new GameObject();
            GameObject.DontDestroyOnLoad(timerTmpObj);
            timerTmpObj.name = tmpTimerID.ToString();

            TimerBehavior timerBehavior = timerTmpObj.AddComponent<TimerBehavior>();
            timerFuncDic.Add(tmpTimerID,action);
            timerObjects.Add(tmpTimerID,timerTmpObj);
            timerBehavior.BeginRepeatTimer(RepeatTimerEvent,timerID,time,isIgnoreTimeScale);
        }
        return tmpTimerID;
    }

    /// <summary>
    /// 设置一个受TimeScale影响的重复调用的多次计时器
    /// </summary>
    /// <param name="action"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static int SetRepeatTimer(Action action, float time)
    {
        return SetRepeatTimer(action, time, false);
    }

    /// <summary>
    /// 关闭指定ID的计时器
    /// </summary>
    /// <param name="killID"></param>
    public static void KillTimer(int killID)
    {
        if (timerFuncDic.ContainsKey(killID))
        {
            timerFuncDic.Remove(killID);
        }

        if (timerObjects.ContainsKey(killID))
        {
            GameObject timerTmpObj = timerObjects[killID];
            timerObjects.Remove(killID);
            GameObject.Destroy(timerTmpObj);
        }
    }

    private static int GetTimerID()
    {
        return timerID++;
    }

    private static void RepeatTimerEvent(int tmpTimerID)
    {
        if (timerFuncDic.ContainsKey(tmpTimerID))
        {
            timerFuncDic[tmpTimerID]();
        }
    }


    private static void TimerEndEvent(int tmpTimerID)
    {
        if (timerFuncDic.ContainsKey(tmpTimerID))
        {
            timerFuncDic[tmpTimerID]();
            timerFuncDic.Remove(tmpTimerID);
        }

        if (timerObjects.ContainsKey(tmpTimerID))
        {
            GameObject tmpTimerObj = timerObjects[tmpTimerID];
            timerObjects.Remove(tmpTimerID);
            GameObject.Destroy(tmpTimerObj);
            tmpTimerObj = null;
        }
    }

}
