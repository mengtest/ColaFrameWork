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
    private static readonly Dictionary<string, Type> name2TypeDic;

    /// 存储一些在游戏一开始运行便加载的数据字典
    /// </summary>
    private static readonly Dictionary<string, Type> startLoadDic;

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
        startLoadDic= new Dictionary<string, Type>()
        {
            {"Language",typeof(I18NDataMap) },
        };
        name2TypeDic= new Dictionary<string, Type>()
        {
        };

    }

    /// <summary>
    /// 加载游戏一开始便需要加载的数据
    /// </summary>
    /// <param name="callback"></param>
    public void LoadStartConfig(Action callback)
    {
        if (null != startLoadDic)
        {
            using (var enumerator = startLoadDic.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ResourceMgr.GetInstance().LoadText(GetFilePath(enumerator.Current.Key),enumerator.Current.Key,TextLoadCallBack);
                }
            }
        }
    }

    /// <summary>
    /// 文本加载完成后的回调函数
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="content"></param>
    private void TextLoadCallBack(string fileName,string content)
    {
        if (!string.IsNullOrEmpty(content))
        {

        }
        else
        {
            Debug.LogWarning(string.Format("读取%s文件数据为空！",fileName));
        }
    }

    /// <summary>
    /// 获取数据文件的存放路径
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private string GetFilePath(string fileName)
    {
        return fileName;
    }
}
