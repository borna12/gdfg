using UnityEngine;
using System.Collections;

public class ChangeColorBackgroundInTitleScreen : MonoBehaviour
{

	// Use this for initialization
    void Awake()
    {
		QualitySettings.vSyncCount =PlayerPrefs.GetInt ("vsynch");
        camera.backgroundColor = Color.white;
		Time.timeScale = 1;
    }


    void Start () {
        camera.backgroundColor = Color.white;
        Screen.showCursor = false;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Time.time);
	if (Time.timeSinceLevelLoad> 1)
	    {
	        camera.backgroundColor = Color.black;
	    }
	}
}
