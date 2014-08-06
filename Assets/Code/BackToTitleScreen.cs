using UnityEngine;
using System.Collections;

public class BackToTitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var glazba = GameObject.Find("main_music");
	    if (glazba.audio.isPlaying==false)
	    {
            glazba.audio.Play();
	    }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.LoadLevel("title");
            var glazba = GameObject.Find("main_music");
            glazba.audio.Stop();

        }
	}
}
