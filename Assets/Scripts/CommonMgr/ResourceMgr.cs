using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源管理器
/// </summary>
public class ResourceMgr
{
    private static ResourceMgr instance;

    public static ResourceMgr GetInstance()
    {
        if (null == instance)
        {
            instance= new ResourceMgr();
        }
        return instance;
    }
}
