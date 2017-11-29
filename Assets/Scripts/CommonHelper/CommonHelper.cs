using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通用工具类
/// 提供一些常用功能的接口
/// </summary>
public class CommonHelper
{

    /// <summary>
    /// 通过ID获取国际化文字
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string GetText(int id)
    {
        return I18NHelper.GetInstance().GetI18NText(id);
    }
}