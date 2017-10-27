using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventType = ColaFrame.EventType;

public class SubSysMgr : IEventHandler
{
    /// <summary>
    /// 存储系统的字典
    /// </summary>
    private Dictionary<int, SubSysBase> subSysList;


    public SubSysMgr()
    {
        subSysList = new Dictionary<int, SubSysBase>();

        GameEventMgr.GetInstance().RegisterHandler(this,EventType.ChangeSys,EventType.ServerMsg,EventType.SystemMsg);
    }

    /// <summary>
    /// 获取对应类型的系统
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetSubSys<T>() where T : SubSysBase
    {
        foreach (var subSys in subSysList)
        {
            if (typeof(T) == subSys.Value.GetType())
            {
                return (T) subSys.Value;
            }
        }
        return null;
    }

    /// <summary>
    /// 根据系统类型，返回对应的系统
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="subSysType"></param>
    /// <returns></returns>
    public T GetSubSys<T>(SubSysType subSysType) where T : SubSysBase
    {
        return (T)subSysList[(int)subSysType];
    }

    public bool HandleMessage(GameEvent evt)
    {
        throw new System.NotImplementedException();
    }

    public bool IsHasHandler(GameEvent evt)
    {
        throw new System.NotImplementedException();
    }
}
