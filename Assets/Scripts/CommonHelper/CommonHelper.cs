using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    /// <summary>
    /// 给按钮添加点击事件(以后可以往这里添加点击声音)
    /// </summary>
    /// <param name="go"></param>
    /// <param name="callback"></param>
    public static void AddBtnMsg(GameObject go, Action<GameObject> callback)
    {
        if (null != go)
        {
            Button button = go.GetComponent<Button>();
            if (null != button)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    callback(go);
                });
            }
            else
            {
                Debug.LogWarning("该按钮没有挂载button组件！");
            }
        }
        else
        {
            Debug.LogWarning("ButtonObj为空！");
        }
    }

    /// <summary>
    /// 删除一个按钮的点击事件
    /// </summary>
    /// <param name="go"></param>
    /// <param name="callback"></param>
    public static void RemoveBtnMsg(GameObject go, Action<GameObject> callback)
    {
        if (null != go)
        {
            Button button = go.GetComponent<Button>();
            if (null != button)
            {
                button.onClick.RemoveAllListeners();
            }
            else
            {
                Debug.LogWarning("该按钮没有挂载button组件！");
            }
        }
        else
        {
            Debug.LogWarning("ButtonObj为空！");
        }
    }

    /// <summary>
    /// 根据路径实例化一个Prefab
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static GameObject InstantiateGoByPath(string path, GameObject parent)
    {
        ResourceMgr resourceMgr = ResourceMgr.GetInstance();
        GameObject prefab = null;

        if (null != resourceMgr)
        {
            prefab = resourceMgr.
        }
        else
        {
            Debug.LogWarning("检查资源管理器！");
            return null;
        }
    }

    /// <summary>
    /// 根据一个预制实例化一个Prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static GameObject InstantiateGoByPrefab(GameObject prefab, GameObject parent)
    {

    }

    /// <summary>
    /// 给物体添加一个单一组件
    /// </summary>
    /// <typeparam name="T"></typeparam>组件的类型
    /// <param name="go"></param>要添加组件的物体
    /// <returns></returns>
    public static T AddSingleComponent<T>(GameObject go) where T : Component
    {
        if (null != go)
        {
            T component = go.GetComponent<T>();
            if (null == component)
            {
                component = go.AddComponent<T>();
            }
            return component;
        }
        Debug.LogWarning("要添加组件的物体为空！");
        return null;
    }

    /// <summary>
    /// 获取某个物体下对应名字的子物体上的某个类型的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>组件的类型
    /// <param name="go"></param>父物体
    /// <param name="name"></param>子物体的名称
    /// <returns></returns>
    public static T GetComponentByName<T>(GameObject go, string name) where T : Component
    {
        T[] components = go.GetComponentsInChildren<T>(true);
        if (components != null)
        {
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != null && components[i].name == name)
                {
                    return components[i];
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 获取某个物体下子物体上所有的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public static T[] GetComponentsByName<T>(GameObject go) where T : Component
    {
        T[] components = go.GetComponentsInChildren<T>(true);

        return components;
    }

    /// <summary>
    /// 获取某个物体下对应名字的子物体
    /// </summary>
    /// <param name="go"></param>
    /// <param name="childName"></param>
    /// <returns></returns>
    public static GameObject GetGameObjectByName(GameObject go, string childName)
    {
        GameObject ret = null;
        if (go != null)
        {
            Transform[] childrenObj = go.GetComponentsInChildren<Transform>(true);
            if (childrenObj != null)
            {
                for (int i = 0; i < childrenObj.Length; ++i)
                {
                    if ((childrenObj[i].name == childName))
                    {
                        ret = childrenObj[i].gameObject;
                        break;
                    }
                }
            }
        }
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objInput"></param>
    /// <param name="strFindName"></param>
    /// <returns></returns>
    public static List<GameObject> GetGameObjectsByName(GameObject objInput, string strFindName)
    {
        List<GameObject> list = new List<GameObject>();
        Transform[] objChildren = objInput.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < objChildren.Length; ++i)
        {
            if ((objChildren[i].name.Contains(strFindName)))
            {
                list.Add(objChildren[i].gameObject);
            }
        }

        return list;
    }
}