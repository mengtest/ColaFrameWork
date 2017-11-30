using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{



    public Text text1;
    public Text text2;
    public Text text3;

    private Button button;
	// Use this for initialization
	void Start ()
	{
        LocalDataMgr.GetInstance().LoadStartConfig(() =>
        {

        });
	    StartCoroutine(ttt());
	}

    IEnumerator ttt()
    {
        yield return new WaitForSeconds(5f);
        text1.text = CommonHelper.GetText(10000);
        text2.text = CommonHelper.GetText(10001);
        text3.text = CommonHelper.GetText(10002);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
