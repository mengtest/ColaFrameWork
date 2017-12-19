using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSHelper : MonoBehaviour {

    public float f_UpdateInterval = 0.5F;

    private float f_LastInterval;

    private int i_Frames = 0;

    private float f_Fps;

    void Start()
    {
        //Application.targetFrameRate=60;

        f_LastInterval = Time.realtimeSinceStartup;

        i_Frames = 0;
    }

    void OnGUI()
    {
        GUI.color = new Color(0, 1, 0);
        GUI.skin.label.fontSize = 20;
        GUI.Label(new Rect(Screen.width - 330, 0, 330, 300), "MemoryAllocated:" + GetMemoryMB(UnityEngine.Profiling.Profiler.GetTotalAllocatedMemory())
                                                             + "  MemoryReserved:" + GetMemoryMB(UnityEngine.Profiling.Profiler.GetTotalReservedMemory())
                                                             + " MemoryUnusedReserved:" + GetMemoryMB(UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemory())
                                                             + "  usedHeapSize:" + GetMemoryMB(UnityEngine.Profiling.Profiler.usedHeapSize)
                                                             + "  MonoHeapSize:" + GetMemoryMB(UnityEngine.Profiling.Profiler.GetMonoHeapSize())
                                                             + "  MonoUsedSize:" + GetMemoryMB(UnityEngine.Profiling.Profiler.GetMonoUsedSize())
        );
        string version_str = GameClient.getClientVersion();
        version_str = System.String.Format("版本号:{0}", version_str);
        GUI.Label(new Rect(0, 100, 200, 200), version_str);
        if (f_Fps > 50)
        {
            GUI.color = new Color(0, 1, 0);
        }
        else if (f_Fps > 25)
        {
            GUI.color = new Color(1, 1, 0);
        }
        else
        {
            GUI.color = new Color(1.0f, 0, 0);
        }

        GUI.Label(new Rect(0, 50, 300, 300), "FPS:" + f_Fps.ToString("f2"));

    }

    private string GetMemoryMB(uint curSize)
    {
        float mbSize = curSize / (1024f * 1024f);
        return mbSize.ToString("f2") + "MB";
    }

    void Update()
    {
        ++i_Frames;

        if (Time.realtimeSinceStartup > f_LastInterval + f_UpdateInterval)
        {
            f_Fps = i_Frames / (Time.realtimeSinceStartup - f_LastInterval);

            i_Frames = 0;

            f_LastInterval = Time.realtimeSinceStartup;
        }
    }
}
