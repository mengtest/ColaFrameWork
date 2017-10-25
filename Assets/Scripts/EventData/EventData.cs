using System.Collections;
using System.Collections.Generic;
using EventType = ColaFrame.EventType;

/// <summary>
/// 接收消息后触发的回调
/// </summary>
/// <param name="data"></param>
public delegate void MsgHandler(EventData data);

/// <summary>
/// 事件处理器的接口
/// </summary>
public interface IEventHandler
{
    bool HandleMessage(GameEvent evt);

    bool IsHasHandler(GameEvent evt);
}

/// <summary>
/// 事件消息传递的数据
/// </summary>
public class EventData
{
    
}

/// <summary>
/// 游戏中的事件
/// </summary>
public class GameEvent
{
    public EventType EventType { get; set; }
}


namespace ColaFrame
{
    /// <summary>
    /// 事件的类型
    /// </summary>
    public enum EventType : byte
    {
        /// <summary>
        /// 系统的消息
        /// </summary>
        SystemMsg = 0,
        /// <summary>
        /// 来自服务器推送的消息
        /// </summary>
        ServerMsg = 1,
        /// <summary>
        /// 跳转系统的消息
        /// </summary>
        ChangeSys = 2,
    }
}

