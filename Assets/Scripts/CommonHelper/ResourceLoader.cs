using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object =UnityEngine.Object;

/// <summary>
/// 资源加载助手类
/// </summary>
public class ResourceLoader : MonoBehaviour {

    /// <summary>
    /// 根据类型和路径返回相应的资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary>
    /// 根据类型和路径返回相应的资源
    /// </summary>
    /// <param name="path"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public Object Load(string path, Type type)
    {
        return Resources.Load(path, type);
    }
}
