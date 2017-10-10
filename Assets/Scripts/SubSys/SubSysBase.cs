using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 系统的类型
/// </summary>
public enum SubSysType : byte
{

}

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

/// <summary>
/// 所有子系统的抽象基类
/// </summary>
public abstract class SubSysBase : IEventHandler
{
    /// <summary>
    /// 当前系统的类型
    /// </summary>
    public readonly SubSysType subSysType;
    /// <summary>
    /// 消息-回调函数字典，接收到消息后调用字典中的回调方法
    /// </summary>
    protected Dictionary<string, MsgHander> msgHanderDic;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="subSysType"></param>系统类型
    public SubSysBase(SubSysType subSysType)
    {
        this.subSysType = subSysType;
        msgHanderDic = null;
    }

    public virtual void EnterSys()
    {

    }

    /// <summary>
    /// 更新系统，每帧调用一次
    /// </summary>
    /// <param name="time"></param>间隔时间
    public virtual void UpdateSys(double deltaTime)
    {

    }

    /// <summary>
    /// 退出系统
    /// </summary>
    public virtual void ExitSys()
    {

    }

    /// <summary>
    /// 注册消息/事件回调
    /// </summary>
    protected virtual void RegisterHander()
    {

    }

    /// <summary>
    /// 反注册消息/事件回调
    /// </summary>
    protected virtual void UnRegisterHander()
    {

    }

    /// <summary>
    /// 处理消息的函数的实现
    /// </summary>
    /// <param name="gameEvent"></param>事件
    /// <returns></returns>是否处理成功
    protected virtual bool HandleMessageImpl(GameEvent gameEvent)
    {

    }

    /// <summary>
    /// 是否处理了该消息的函数的实现
    /// </summary>
    /// <returns></returns>是否处理
    protected virtual bool IsHandlerImpl(GameEvent gmaEvent)
    {

    }


    public bool HandleMessage(GameEvent evt)
    {
        return HandleMessageImpl(evt);
    }

    public bool IsHasHandler(GameEvent evt)
    {
        return IsHandlerImpl(evt);
    }
}
