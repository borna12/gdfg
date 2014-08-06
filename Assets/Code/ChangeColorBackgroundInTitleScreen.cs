using UnityEngine;
using System.Collections;

public class ChangeColorBackgroundInTitleScreen : MonoBehaviour
{

	// Use this for initialization
    void Awake()
    {
        
        camera.backgroundColor = Color.white;
    }


    void Start () {
        camera.backgroundColor = Color.white;
        Screen.showCursor = false;

	}
	
	// Update is called once per frame
	void Update () {
	if (Time.timeSinceLevelLoad> 1)
	    {
	        camera.backgroundColor = Color.black;
	    }
	}
}
