using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 接收消息后触发的回调
/// </summary>
/// <param name="data"></param>
public delegate void MsgHander(MsgHandlerData data);

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
public class MsgHandlerData
{
    
}

/// <summary>
/// 游戏中的事件
/// </summary>
public class GameEvent
{
    
}
