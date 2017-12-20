using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏入口:游戏启动器类
/// </summary>
public class GameLauncher : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject fpsHelperObj;
    private FPSHelper fpsHelper;

    void Awake()
    {
        gameManager = GameManager.GetInstance();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        DontDestroyOnLoad(gameObject);

#if SHOW_FPS
        fpsHelperObj = new GameObject("FpsHelperObj");
        fpsHelper = fpsHelperObj.AddComponent<FPSHelper>();
        GameObject.DontDestroyOnLoad(fpsHelperObj);
#endif
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(InitGameCore());
    }

    void Update()
    {
        gameManager.Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        gameManager.LateUpdate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        gameManager.FixedUpdate(Time.fixedDeltaTime);
    }


    private void OnApplicationQuit()
    {
        gameManager.OnApplicationQuit();
    }

    private void OnApplicationPause(bool pause)
    {
        gameManager.OnApplicationPause(pause);
    }

    private void OnApplicationFocus(bool focus)
    {
        gameManager.OnApplicationFocus(focus);
    }

    IEnumerator InitGameCore()
    {
        yield return new WaitForEndOfFrame();
        gameManager.InitGameCore();
    }
}
