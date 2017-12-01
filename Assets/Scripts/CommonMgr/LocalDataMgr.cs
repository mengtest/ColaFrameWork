using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// 本地数据集管理类
/// 一些游戏启动的时候必须的预先数据在startLoadDic中注册，这些数据会在游戏已启动的时候加载
/// 一些其它的数据在name2TypeDic中注册，这些数据将采用懒加载的方式
/// </summary>
public class LocalDataMgr
{
    private static LocalDataMgr instance;

    /// <summary>
    /// 存储各种表格数据集的字典
    /// </summary>
    private Dictionary<Type, ILocalDataMapBase> dataMap = new Dictionary<Type, ILocalDataMapBase>();

    /// <summary>
    /// 存储表格名称对应的解析类的字典(K:表名,V：解析类),需手动填写
    /// </summary>
    private static readonly Dictionary<string, Type> name2TypeDic;

    /// <summary>
    /// 存储解析类对应表名的字典(K:解析类,V：表名)，只需要填写上面的name2Type即可，此字典程序会在运行时自动拷贝
    /// </summary>
    private static readonly Dictionary<Type, string> type2NameDic;

    /// 存储游戏一开始就需加载的表格名称对应的解析类的字典(K:表名,V：解析类)
    /// </summary>
    private static readonly Dictionary<string, Type> startLoadDic;

    /// <summary>
    /// 要加载的表格的数量
    /// </summary>
    private int loadedConfigCount = -1;

    /// <summary>
    /// 同步异步标识
    /// </summary>
    //private bool isAsync = false;

    /// <summary>
    /// 资源加载完成后的回调
    /// </summary>
    //private Action callback;


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
        startLoadDic = new Dictionary<string, Type>()
        {
            {"Language",typeof(I18NDataMap) },
        };
        name2TypeDic = new Dictionary<string, Type>()
        {
        };
        type2NameDic = new Dictionary<Type, string>();

        //运行时，将name2TypeDic中的数据拷贝过来，毋须手动填写
        using (var enumerator = name2TypeDic.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                type2NameDic.Add(enumerator.Current.Value, enumerator.Current.Key);
            }
        }
    }

    /// <summary>
    /// 加载游戏一开始便需要加载的数据(同步)
    /// </summary>
    /// <param name="callback"></param>
    public void LoadStartConfig(Action callback)
    {
        //this.callback = callback;
        //this.isAsync = false;

        if (null != startLoadDic)
        {
            using (var enumerator = startLoadDic.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ResourceMgr.GetInstance().LoadText(GetFilePath(enumerator.Current.Key), enumerator.Current.Key, TextLoadCallBack);
                }
            }

            if (null != callback)
            {
                callback();
            }
        }
    }

    /// <summary>
    /// 文本加载完成后的回调函数
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="content"></param>
    private void TextLoadCallBack(string fileName, string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            //去除最后的\n
            if (content.EndsWith("\n"))
            {
                content = content.Substring(0, content.Length - 1);
            }
            string[] csvContent = content.Split('\n');

            //选择实例化解析类
            Type dataType = null;
            if (startLoadDic.ContainsKey(fileName))
            {
                dataType = startLoadDic[fileName];
            }
            else if (name2TypeDic.ContainsKey(fileName))
            {
                dataType = name2TypeDic[fileName];
            }
            if (null != dataType)
            {
                ILocalDataMapBase data;
                if (dataType.BaseType == typeof(ScriptableObject) ||
                    dataType.BaseType.BaseType == typeof(ScriptableObject))
                {
                    data = ScriptableObject.CreateInstance(dataType) as ILocalDataMapBase;
                }
                else
                {
                    data = dataType.Assembly.CreateInstance(dataType.ToString()) as ILocalDataMapBase;
                }

                try
                {
                    data.SetMapCsv(csvContent);
                    dataMap.Add(dataType, data);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e.ToString());
                }
            }
            else
            {
                Debug.LogWarning(string.Format("没有找到{0}对应的解析类", fileName));
            }

        }
        else
        {
            Debug.LogWarning(string.Format("读取{0}文件数据为空！", fileName));
        }

        //异步的时候才走这个，异步资源加载完成后执行回调
        //if (isAsync)
        //{
        //    --loadedConfigCount;
        //    if (0 == loadedConfigCount)
        //    {
        //        if (null != this.callback)
        //        {
        //            this.callback();
        //        }
        //    }
        //}
    }

    /// <summary>
    /// 获取数据文件的存放路径
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private string GetFilePath(string fileName)
    {
        return "CsvData/" + fileName;
    }

    /// <summary>
    /// 获取数据集类，如果数据集不存在，则懒加载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetDataMap<T>() where T : class, ILocalDataMapBase
    {
        if (null != dataMap)
        {
            //如果数据已经加载过，直接返回数据，否则懒加载数据集
            if (dataMap.ContainsKey(typeof(T)))
            {
                if (null != dataMap[typeof(T)])
                {
                    return (T)dataMap[typeof(T)];
                }
                Debug.LogWarning(string.Format("LocalData 键{0}对应的值为空！", typeof(T)));
            }
            else
            {
                if (type2NameDic.ContainsKey(typeof(T)))
                {
                    LoadConfigByName(type2NameDic[typeof(T)]);
                    return (T)dataMap[typeof(T)];
                }
                else
                {
                    Debug.LogWarning(string.Format("{0}类型的数据表不存在！", typeof(T)));
                }
            }
        }
        Debug.LogWarning("LocalDataMapManager初始化错误！");
        return null;
    }

    /// <summary>
    ///  获取数据集类，如果数据集不存在，则懒加载（静态方法，方便调用）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetLocalDataMap<T>() where T : class, ILocalDataMapBase
    {
        return GetInstance().GetDataMap<T>();
    }

    /// <summary>
    /// 加载指定文件名的数据同步
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="callback"></param>
    private void LoadConfigByName(string fileName)
    {
        ResourceMgr.GetInstance().LoadText(GetFilePath(fileName), fileName, TextLoadCallBack);
    }
}
