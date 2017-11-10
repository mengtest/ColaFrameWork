using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void TimerEnd(int timerID);

public delegate void RepeatTimerEvent(int timerID);


public class TimerBehavior : MonoBehaviour
{
    private TimerEnd timerEnd;

    private RepeatTimerEvent repeatTimerEvent;

    private int timerID;

    /// <summary>
    /// 启动计时器
    /// </summary>
    /// <param name="timeListener"></param>
    /// <param name="tmpTimerID"></param>
    /// <param name="time"></param>
    /// <param name="isIgnoreTimeScale"></param>
    public void BeginTimer(TimerEnd timeListener, int tmpTimerID, float time, bool isIgnoreTimeScale)
    {
        if (null != timeListener && time > 0.0f)
        {
            this.timerEnd = timeListener;
            this.timerID = tmpTimerID;

            Invoke("EndTimer", time * GetTimeScale(isIgnoreTimeScale));
        }
    }

    private void EndTimer()
    {
        if (null != timerEnd)
        {
            timerEnd(timerID);
        }
    }

    private float GetTimeScale(bool isIgnoreTimeScale)
    {
        float timeScale = 1.0f;
        if (isIgnoreTimeScale && Time.timeScale > 0)
        {
            timeScale = Time.timeScale;
        }
        return timeScale;
    }

    public void BeginRepeatTimer(RepeatTimerEvent timerListener, int tmpTimerID, float time, bool isInoreTimeScale)
    {
        if (null != timerListener && time > 0.0f)
        {
            repeatTimerEvent = timerListener;
            timerID = tmpTimerID;

            InvokeRepeating("EndRepeatTimer", time * GetTimeScale(isInoreTimeScale), time * GetTimeScale(isInoreTimeScale));
        }
    }

    private void EndRepeatTimer()
    {
        if (null != repeatTimerEvent)
        {
            repeatTimerEvent(timerID);
        }
    }
}
