using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object=UnityEngine.Object;

/// <summary>
/// 资源信息
/// </summary>
public class ResourceInfo
{
    /// <summary>
    /// 实际的资源
    /// </summary>
    public Object Res;

    /// <summary>
    /// 资源的生存时间 -2 永久存在 -1 当前 大于0则按时间删除
    /// </summary>
    public int RemainSec;
}


/// <summary>
/// 资源管理器
/// </summary>
public class ResourceMgr
{
    private static ResourceMgr instance;
    private ResourceLoader resourceLoader;

    public static ResourceMgr GetInstance()
    {
        if (null == instance)
        {
            instance = new ResourceMgr();
        }
        return instance;
    }

    private ResourceMgr()
    {
        GameObject resourceMgrObj = new GameObject();
        GameObject.DontDestroyOnLoad(resourceMgrObj);

        resourceLoader = resourceMgrObj.AddComponent<ResourceLoader>();
    }

    /// <summary>
    /// 加载文本(同步)
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <param name="callback"></param>
    public void LoadText(string path, string fileName, Action<string, string> callback)
    {
        TextAsset textAsset = resourceLoader.Load<TextAsset>(path);
        if (null != callback)
            callback(fileName, textAsset.text);
    }

    public void LoadText(string path, string fileName, Action<string, byte[]> callback)
    {
#if UNITY_ANDROID && !UNITY_EDITOR

#endif
        //支持从Resources以外目录读取
        var bytes = File.ReadAllBytes(path);
        if (null!=callback)
            callback(fileName, bytes);
    }

    /// <summary>
    /// 加载文本(异步)
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <param name="callback"></param>
    public void LoadTextAsync(string path, string fileName, Action<string, string> callback)
    {
        resourceLoader.LoadAsync<TextAsset>(path, (obj, name) =>
        {
            TextAsset textAsset = obj as TextAsset;
            if (null != callback)
                callback(fileName, textAsset.text);
        });
    }
}
