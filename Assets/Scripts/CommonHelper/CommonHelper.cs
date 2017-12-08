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
    /// 变更一个按钮的点击事件
    /// </summary>
    /// <param name="go"></param>
    /// <param name="callback"></param>
    public static void ChangeBtnMsg(GameObject go, Action<GameObject> callback)
    {

    }

    /// <summary>
    /// 删除一个按钮的点击事件
    /// </summary>
    /// <param name="go"></param>
    /// <param name="callback"></param>
    public static void RemoveBtnMsg(GameObject go, Action<GameObject> callback)
    {

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
}