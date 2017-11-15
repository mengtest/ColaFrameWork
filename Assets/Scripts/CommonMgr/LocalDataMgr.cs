using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 本地数据集管理类
/// </summary>
public class LocalDataMgr
{
    private static LocalDataMgr instance;

    /// <summary>
    /// 存储各种表格数据集的字典
    /// </summary>
    private Dictionary<Type,ILocalDataMapBase> dataMap = new Dictionary<Type, ILocalDataMapBase>();
    /// <summary>
    /// 存储表格名称对应的解析类的字典
    /// </summary>
    private static readonly Dictionary<string,Type> name2TypeDic = new Dictionary<string, Type>();

    public static LocalDataMgr GetInstance()
    {
        if (null == instance)
        {
            instance = new LocalDataMgr();
        }
        return instance;
    }

    static LocalDataMgr()
    {
        name2TypeDic= new Dictionary<string, Type>()
        {
            {"Language",typeof(I18NDataMap)},
        };

    }
}
