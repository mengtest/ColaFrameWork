using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            uiRootObj.transform.parent = rootObj.transform;
            uiRootObj.layer = uiLayer;

            uiCameraObj=new GameObject("UICamera");
            uiCameraObj.layer = uiLayer;
            uiCameraObj.transform.parent = uiRootObj.transform;
            uiCamera=uiCameraObj.AddComponent<Camera>();
            uiCamera.depth = 6;
            uiCamera.backgroundColor = Color.black;
            uiCamera.cullingMask = uiLayer;
            uiCamera.clearFlags = CameraClearFlags.Depth;

            //使用2D相机
            uiCamera.orthographicSize = 1.0f;
            uiCamera.orthographic = true;
            uiCamera.nearClipPlane = -1000f;
            uiCamera.farClipPlane = 1000f;
            //uiCameraObj.AddComponent<CameraAdapter>();

            Canvas uguiRoot = uiRootObj.AddComponent<Canvas>();
            uguiRoot.renderMode = RenderMode.ScreenSpaceCamera;
            uguiRoot.worldCamera = uiCamera;

            CanvasScaler canvasScaler = uiRootObj.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            canvasScaler.matchWidthOrHeight = 0;
            canvasScaler.referenceResolution = new Vector2(1280,720);

            uiRootObj.AddComponent<GraphicRaycaster>();
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();

            uiRoot = uguiRoot;

        }
    }

    /// <summary>
    /// 返回UI画布的根节点
    /// </summary>
    /// <returns></returns>
    public GameObject GetUIRootObj()
    {
        UGUICreate();
        return uiRootObj;
    }

    /// <summary>
    /// 返回相机节点
    /// </summary>
    /// <returns></returns>
    public GameObject GetUICameraObj()
    {
        UGUICreate();
        return uiCameraObj;
    }

    /// <summary>
    /// 返回UI画布
    /// </summary>
    /// <returns></returns>
    public Canvas GetUIRoot()
    {
        UGUICreate();
        return uiRoot;
    }

    /// <summary>
    /// 返回UI相机
    /// </summary>
    /// <returns></returns>
    public Camera GetUICamera()
    {
        UGUICreate();
        return uiCamera;
    }

    /// <summary>
    /// 返回3D物体的根节点
    /// </summary>
    /// <returns></returns>
    public GameObject Get3DRootObj()
    {
        UGUICreate();
        return ui3DRootObj;
    }
}
