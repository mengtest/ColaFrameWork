using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void LoadText(string path,string fileName,)
}
