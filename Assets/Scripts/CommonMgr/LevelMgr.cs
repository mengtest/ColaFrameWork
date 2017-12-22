using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 不同场景/关卡对应的scene索引
/// </summary>
public enum LevelIndex : int
{
    Login = 1,
    Loading = 2,
    Lobby = 3,
}

public delegate void OnLevelLoaded(int levelIndex);

public delegate void OnAdditiveLevelLoaded(string levelName);


/// <summary>
/// 场景/关卡管理器
/// </summary>
public class LevelMgr : MonoBehaviour
{

    public Scene currentScene;

	// Use this for initialization
	void Start () {
		
	}

    /// <summary>
    /// 以异步-叠加方式加载场景
    /// </summary>
    /// <param name="levelName"></param>
    /// <param name="onAdditiveLevelLoaded"></param>
    public void LoadAdditiveLevelAsync(string levelName, OnAdditiveLevelLoaded onAdditiveLevelLoaded)
    {
        StartCoroutine(LoadTargetLevelAdditiveAsync(levelName, onAdditiveLevelLoaded));
    }

    /// <summary>
    /// 以异步-叠加方式加载场景(携程调用)
    /// </summary>
    /// <param name="levelName"></param>
    /// <param name="onAdditiveLevelLoaded"></param>
    /// <returns></returns>
    private IEnumerator LoadTargetLevelAdditiveAsync(string levelName, OnAdditiveLevelLoaded onAdditiveLevelLoaded)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        while (!asyncOperation.isDone)
        {
            yield return asyncOperation;
        }
        currentScene=SceneManager.GetActiveScene();
        onAdditiveLevelLoaded(levelName);
        Scene scene = SceneManager.GetSceneByName(levelName);
        SceneManager.SetActiveScene(scene);
    }
}
