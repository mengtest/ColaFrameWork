using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI的接口
/// </summary>
public interface IViewBase
{
    
}


/// <summary>
/// UI的类型枚举
/// </summary>
public enum UIType : byte
{
    Top = 0,
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
    Common = 4,
}