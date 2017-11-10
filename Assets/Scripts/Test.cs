using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    //TimeHelper.SetTimer(() => { Debug.LogError("时间到！"); }, 1f, false);
	    TimeHelper.SetRepeatTimer(() => { Debug.Log("1s打印一次"); }, 0.5f);
        //InvokeRepeating("Log",1f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
