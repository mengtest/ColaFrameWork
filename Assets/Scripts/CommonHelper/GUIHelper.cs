using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GUI工具类
/// </summary>
public class GUIHelper
{
    /// <summary>
    /// UI画布的根节点
    /// </summary>
    private static GameObject uiRootObj = null;

    /// <summary>
    /// 相机节点
    /// </summary>
    private static GameObject uiCameraObj = null;

    /// <summary>
    /// UI相机
    /// </summary>
    private static Camera uiCamera = null;

    /// <summary>
    /// UI画布
    /// </summary>
    private static Canvas uiRoot = null;

    /// <summary>
    /// 3D物体的根节点
    /// </summary>
    private static GameObject ui3DRootObj = null;

    private static void UGUICreate()
    {
        if (null == uiRootObj)
        {
            //创建画布根节点，相机节点，3D物体根节点
            int uiLayer = LayerMask.NameToLayer("UI");
            GameObject rootObj = new GameObject("UGUIRoot");
            rootObj.layer = uiLayer;

            ui3DRootObj = new GameObject("ui3DRoot");
            ui3DRootObj.transform.parent = rootObj.transform;
            ui3DRootObj.layer = LayerMask.NameToLayer("UI_Model");

            uiRootObj = new GameObject("Canvas");
        }
    }
}
