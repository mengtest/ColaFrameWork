using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventType = ColaFrame.EventType;

/// <summary>
/// 事件消息管理中心
/// </summary>
public class GameEventMgr
{
    /// <summary>
    /// 存储Hander的字典
    /// </summary>
    private Dictionary<int, List<IEventHandler>> handlerDic;

    private static GameEventMgr instance = null;

    private GameEventMgr()
    {
        handlerDic = new Dictionary<int, List<IEventHandler>>();
    }

    public static GameEventMgr GetInstance()
    {
        if (null == instance)
        {
            instance = new GameEventMgr();
        }
        return instance;
    }

    /// <summary>
    /// 对外提供的注册监听的接口
    /// </summary>
    /// <param name="handler"></param>监听者(处理回调)
    /// <param name="eventTypes"></param>想要监听的事件类型
    public void RegisterHandler(IEventHandler handler, params EventType[] eventTypes)
    {
        for (int i = 0; i < eventTypes.Length; i++)
        {
            RegisterHandler(eventTypes[i],handler);
        }
    }

    /// <summary>
    /// 内部实际调用的注册监听的方法
    /// </summary>
    /// <param name="type"></param>要监听的事件类型
    /// <param name="handler"></param>监听者(处理回调)
    private void RegisterHandler(EventType type, IEventHandler handler)
    {
        if (null != handler)
        {
            if (!handlerDic.ContainsKey((int) type))
            {
                handlerDic.Add((int)type,new List<IEventHandler>());
            }
            if (!handlerDic[(int)type].Contains(handler))
            {
                handlerDic[(int)type].Add(handler);
            }
        }
    }

    /// <summary>
    /// 反注册事件监听的接口，对所有类型的事件移除指定的监听
    /// </summary>
    /// <param name="handler"></param>
    public void UnRegisterHandler(IEventHandler handler)
    {
        using (var enumerator = handlerDic.GetEnumerator())
        {
            List<IEventHandler> list;
            while (enumerator.MoveNext())
            {
                list = enumerator.Current.Value;
                list.Remove(handler);
            }
        }
    }

    /// <summary>
    /// 反注册事件监听的接口，移除指定类型事件的监听
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="types"></param>
    public void UnRegisterHandler(IEventHandler handler, params EventType[] types)
    {
        EventType type;
        for (int i = 0; i < types.Length; i++)
        {
            type = types[i];
            if (handlerDic.ContainsKey((int) type) && handlerDic[(int) type].Contains(handler))
            {
                handlerDic[(int) type].Remove(handler);
            }
        }

    }

    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="gameEvent"></param>想要分发的事件
    public void DispatchEvent(GameEvent gameEvent)
    {
        bool eventHandle = false;

        List<IEventHandler> handlers;
        if (null != gameEvent && handlerDic.TryGetValue((int) gameEvent.EventType, out handlers))
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                try
                {
                    eventHandle = handlers[i].HandleMessage(gameEvent) || eventHandle;
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }

            if (!eventHandle)
            {
                if (null != gameEvent)
                {
                    switch (gameEvent.EventType)
                    {
                        case EventType.ServerMsg:
                            break;
                        default:
                            Debug.LogError("消息未处理，类型："+gameEvent.EventType);
                            break;
                    }
                }
            }
        }

    }
}
