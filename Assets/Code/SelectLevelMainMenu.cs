using UnityEngine;
using System.Collections;

public class SelectLevelMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		var profileManager=GameObject.Find("profileManager");
		var profile=profileManager.GetComponent<ProfileManager>();

		if (profile.profile1 == true) {
			
			if (PlayerPrefs.GetInt ("player_1_progress") == 0) {
				
				var level2 = GameObject.Find ("level2");
				level2.renderer.material.color = Color.gray;
				
				var level3 = GameObject.Find ("level3");
				level3.renderer.material.color = Color.gray;
			}
			if (PlayerPrefs.GetInt ("player_1_progress") == 1) {
				var level2=GameObject.Find("level2");
				level2.renderer.material.color=Color.white;
				
				var level3=GameObject.Find("level3");
				level3.renderer.material.color=Color.gray;
			}
			
			if (PlayerPrefs.GetInt ("player_1_progress") == 2) {
				var level2=GameObject.Find("level2");
				level2.renderer.material.color=Color.white;
				
				var level3=GameObject.Find("level3");
				level3.renderer.material.color=Color.white;
			}
		}


		if (profile.profile2 == true) {
			
			if (PlayerPrefs.GetInt ("player_2_progress") == 0) {
				
				var level2 = GameObject.Find ("level2");
				level2.renderer.material.color = Color.gray;
				
				var level3 = GameObject.Find ("level3");
				level3.renderer.material.color = Color.gray;
			}
			if (PlayerPrefs.GetInt ("player_2_progress") == 1) {
				var level2=GameObject.Find("level2");
				level2.renderer.material.color=Color.white;
				
				var level3=GameObject.Find("level3");
				level3.renderer.material.color=Color.gray;
			}
			
			if (PlayerPrefs.GetInt ("player_2_progress") == 2) {
				var level2=GameObject.Find("level2");
				level2.renderer.material.color=Color.white;
				
				var level3=GameObject.Find("level3");
				level3.renderer.material.color=Color.white;
			}
		}

		if (profile.profile3 == true) {
			
			if (PlayerPrefs.GetInt ("player_3_progress") == 0) {
				
				var level2 = GameObject.Find ("level2");
				level2.renderer.material.color = Color.gray;
				
				var level3 = GameObject.Find ("level3");
				level3.renderer.material.color = Color.gray;
			}
			if (PlayerPrefs.GetInt ("player_3_progress") == 1) {
				var level2=GameObject.Find("level2");
				level2.renderer.material.color=Color.white;
				
				var level3=GameObject.Find("level3");
				level3.renderer.material.color=Color.gray;
			}
			
			if (PlayerPrefs.GetInt ("player_3_progress") == 2) {
				var level2=GameObject.Find("level2");
				level2.renderer.material.color=Color.white;
				
				var level3=GameObject.Find("level3");
				level3.renderer.material.color=Color.white;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	}

