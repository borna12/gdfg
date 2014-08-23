using UnityEngine;
using System.Collections;

public class ProfileManager : MonoBehaviour {

	// Use this for initialization
	public bool profile1=false;
	public bool profile2=false;
	public bool profile3=false;
	void Awake () {

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (profile1 == true) {
			if(Application.loadedLevelName=="menu"||Application.loadedLevelName=="options"||Application.loadedLevelName=="Select_level"){
			var profiler=GameObject.Find("profile");
			var text1=profiler.GetComponent<TextMesh>();
			text1.text="Profile: "+ PlayerPrefs.GetString("player 1");}
			if (PlayerPrefs.GetInt("prof1_unlock_level 2", 0) == 1){

			}
		}

		if (profile2 == true) {
			if(Application.loadedLevelName=="menu"){
			var profiler=GameObject.Find("profile");
			var text1=profiler.GetComponent<TextMesh>();
				text1.text="Profile: "+ PlayerPrefs.GetString("player 2");}
			if (PlayerPrefs.GetInt("prof2_unlock_level 2", 0) == 1){
				
			}
		}

		if (profile3 == true) {
			if(Application.loadedLevelName=="menu"){
			var profiler=GameObject.Find("profile");
			var text1=profiler.GetComponent<TextMesh>();
			text1.text="Profile: "+ PlayerPrefs.GetString("player 3");
			if (PlayerPrefs.GetInt("prof3_unlock_level 2", 0) == 1){
				
			}

	
		}
	}
	}}
