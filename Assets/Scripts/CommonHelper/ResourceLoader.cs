using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object =UnityEngine.Object;

/// <summary>
/// 资源加载助手类
/// </summary>
public class ResourceLoader : MonoBehaviour {

    /// <summary>
    /// 根据类型和路径返回相应的资源(同步方法)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary>
    /// 根据类型和路径返回相应的资源(同步方法)
    /// </summary>
    /// <param name="path"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public Object Load(string path, Type type)
    {
        return Resources.Load(path, type);
    }

    /// <summary>
    /// 编辑器模式下加载资源
    /// </summary>
    /// <param name="path"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public Object LoadAssetAtPath(string path, Type type)
    {
#if UNITY_EDITOR
        return AssetDatabase.LoadAssetAtPath(path, type);
#else
        return null
#endif
    }

    /// <summary>
    /// 延迟一帧以后加载资源
    /// </summary>
    /// <param name="path"></param>
    /// <param name="callback"></param>
    public void LoadWaitOneFrame(string path, Action<Object, string> callback)
    {
        StartCoroutine(WaitOneFrameCall(path, callback));
    }

    private IEnumerator WaitOneFrameCall(string path, Action<Object, string> callback)
    {
        yield return 1;
        Object result = Resources.Load<Object>(path);
        if (null != callback) callback(result, path);
    }

    /// <summary>
    /// 根据类型和路径返回相应的资源(异步方法)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="callback"></param>
    public void LoadAsync<T>(string path, Action<Object, string> callback) where T : Object
    {
        StartCoroutine(LoadAsyncCall<T>(path, callback));
    }

    private IEnumerator LoadAsyncCall<T>(string path, Action<Object, string> callback) where T : Object
    {
        ResourceRequest request = Resources.LoadAsync<T>(path);
        yield return request;
        if (null != callback)
        {
            callback(request.asset, path);
        }
    }

    /// <summary>
    /// 根据类型和路径返回相应的资源(异步方法)
    /// </summary>
    /// <param name="path"></param>
    /// <param name="t"></param>
    public void LoadAsync(string path, Type type, Action<Object, string> callback)
    {
        StartCoroutine(LoadAsyncCall(path, type, callback));
    }

    private IEnumerator LoadAsyncCall(string path, Type type, Action<Object, string> callback)
    {
        ResourceRequest request = Resources.LoadAsync(path, type);
        yield return request;
        if (null != callback)
        {
            callback(request.asset, path);
        }
    }
}
