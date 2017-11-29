using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 国际化助手类
/// </summary>
public class I18NHelper
{
    private static I18NHelper instance;
    private static I18NDataMap i18NDataMap;

    private I18NHelper()
    {
        i18NDataMap = LocalDataMgr.GetLocalDataMap<I18NDataMap>();
    }

    public static I18NHelper GetInstance()
    {
        if (null == instance)
        {
            instance = new I18NHelper();
        }
        return instance;
    }

    /// <summary>
    /// 根据ID获取对应的国际化文字
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetI18NText(int id)
    {
        if (null != i18NDataMap)
        {
            I18NData i18NData = i18NDataMap.GetDataById(id);
            if (null != i18NData)
            {
                return i18NData.desStr;
            }
            else
            {
                Debug.LogWarning(string.Format("ID{0}没有包含在国际化表中！", id));
            }
        }
        else
        {
            Debug.LogWarning("国际化表格加载失败！");
        }
        return null;
    }

    /// <summary>
    /// 根据ID获取对应的国际化文字(静态方法，方便调用)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string GetText(int id)
    {
        return GetInstance().GetI18NText(id);
    }

    /// <summary>
    /// 重新加载数据文件
    /// </summary>
    public void ReloadI18NConfig()
    {
        i18NDataMap = LocalDataMgr.GetLocalDataMap<I18NDataMap>();
    }
}
