
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class OptionsMenu : MonoBehaviour
{

    // Use this for initialization
    private TextMesh tm;
    private Renderer textRenderer;
    private void Awake()
    {

	}
    

    private void Start()
    {
        var glazba = GameObject.Find("main_music");
        glazba.audio.ignoreListenerVolume = true;
        Screen.showCursor = true;

		var profileManager=GameObject.Find("profileManager");
		var profile=profileManager.GetComponent<ProfileManager>();
		if (Application.loadedLevelName == "menu") {
						if (profile.profile1 == true) {
			
								if (PlayerPrefs.GetInt ("player_1_progress") == 0) {
										var ContinueButton = GameObject.Find ("continue");
										var ColorButton = ContinueButton.renderer.material;
										ColorButton.color = Color.gray;
								} 
			
								if (PlayerPrefs.GetInt ("player_1_progress") > 0) {
										var ContinueButton = GameObject.Find ("continue");
										var ColorButton = ContinueButton.renderer.material;
										ColorButton.color = Color.yellow;

								}
						} 
		
		
						if (profile.profile2 == true) {
								if (PlayerPrefs.GetInt ("player_2_progress") == 0) {
										var ContinueButton = GameObject.Find ("continue");
										var ColorButton = ContinueButton.renderer.material;
										ColorButton.color = Color.gray;

								}
								if (PlayerPrefs.GetInt ("player_2_progress") > 0) {
										var ContinueButton = GameObject.Find ("continue");
										var ColorButton = ContinueButton.renderer.material;
										ColorButton.color = Color.yellow;
								}
						}
						if (profile.profile3 == true) {
								if (PlayerPrefs.GetInt ("player_3_progress") == 0) {
										var ContinueButton = GameObject.Find ("continue");
										var ColorButton = ContinueButton.renderer.material;
										ColorButton.color = Color.gray;
								}
								if (PlayerPrefs.GetInt ("player_3_progress") > 0) {
										var ContinueButton = GameObject.Find ("continue");
										var ColorButton = ContinueButton.renderer.material;
										ColorButton.color = Color.yellow;
								}
						}
				}
    }

    // Update is called once per frame
    private void Update()
    {
    }


    private void OnMouseEnter()
    {
        gameObject.renderer.material.color = Color.gray;

    }

    private void OnMouseDown()
    {
				if (gameObject.name == "new_game") {
						Application.LoadLevel ("level1");
						var profilemanager = GameObject.Find ("profileManager");
						var profileMa = profilemanager.GetComponent<ProfileManager> ();
						DontDestroyOnLoad (profilemanager);
						var glazba = GameObject.Find ("main_music");
						AudioClip clip = Resources.Load ("Theme") as AudioClip;
						DontDestroyOnLoad (glazba);
						glazba.audio.clip = clip;
						glazba.audio.Play ();
;
			if (profileMa.profile1 == true) {
				PlayerPrefs.SetString ("Current Life1","3");
				PlayerPrefs.SetInt("ammo count1",0);
				PlayerPrefs.SetInt("rifle count1",0);
			}
			if (profileMa.profile2 == true) {
				PlayerPrefs.SetString ("Current Life2","3");
				PlayerPrefs.SetInt("rifle count2",0);
				PlayerPrefs.SetInt("ammo count2",0);
			}
			if (profileMa.profile3 == true) {
				PlayerPrefs.SetString ("Current Life3","3");
				PlayerPrefs.SetInt("ammo count3",0);
				PlayerPrefs.SetInt("rifle count3",0);
			}

				}
				if (gameObject.name == "exit")
						Application.Quit ();

				if (gameObject.name == "options") {
						var prof = GameObject.Find ("profile");
						Application.DontDestroyOnLoad (prof);
						Application.LoadLevel ("options");
						var glazba = GameObject.Find ("main_music");
						DontDestroyOnLoad (glazba);

				}
				if (gameObject.name == "back") {
						Application.LoadLevel ("menu");
						var glazba = GameObject.Find ("main_music");
						DontDestroyOnLoad (glazba);
				}

				if (gameObject.name == "level_select") {
						Application.LoadLevel ("Select_level");
						var glazba = GameObject.Find ("main_music");
						DontDestroyOnLoad (glazba);
						var profile = GameObject.Find ("profile");
						DontDestroyOnLoad (profile);

				}

				if (gameObject.name == "level1") {
						Application.LoadLevel ("level1");
						var glazba = GameObject.Find ("main_music");
						AudioClip clip = Resources.Load ("Theme") as AudioClip;
						glazba.audio.clip = clip;
						glazba.audio.Play ();
			
						var profilemanager = GameObject.Find ("profileManager");
						var profileMan = profilemanager.GetComponent<ProfileManager> ();
						DontDestroyOnLoad (profilemanager);


			if (profileMan.profile1 == true) {
				PlayerPrefs.SetString ("Current Life1","3");
				PlayerPrefs.SetInt("ammo count1",0);
				PlayerPrefs.SetInt("rifle count1",0);

			}
			if (profileMan.profile2 == true) {
				PlayerPrefs.SetString ("Current Life2","3");
				PlayerPrefs.SetInt("ammo count2",0);
				PlayerPrefs.SetInt("rifle count2",0);
			}
			if (profileMan.profile3 == true) {
				PlayerPrefs.SetString ("Current Life3","3");
				PlayerPrefs.SetInt("ammo count3",0);
				PlayerPrefs.SetInt("rifle count3",0);
			}
				}

				if (gameObject.name == "level2") {
						var profileManar = GameObject.Find ("profileManager");
						var profileManr = profileManar.GetComponent<ProfileManager> ();

						if (profileManr.profile1 == true) {
								if (PlayerPrefs.GetInt ("player_1_progress") >= 1) {
										Application.LoadLevel ("level2");
										var glazba = GameObject.Find ("main_music");
										AudioClip clip = Resources.Load ("Theme") as AudioClip;
										glazba.audio.clip = clip;
										glazba.audio.Play ();
										DontDestroyOnLoad (profileManar);
						PlayerPrefs.SetString ("Current Life1","3");
					PlayerPrefs.SetInt("ammo count1",0);
					PlayerPrefs.SetInt("rifle count1",0);
					
								}
						}
			
			
						if (profileManr.profile2 == true) {
								if (PlayerPrefs.GetInt ("player_2_progress") >= 1) {
										Application.LoadLevel ("level2");
										var glazba = GameObject.Find ("main_music");
										AudioClip clip = Resources.Load ("Theme") as AudioClip;
										glazba.audio.clip = clip;
										glazba.audio.Play ();
										DontDestroyOnLoad (profileManar);
					PlayerPrefs.SetString ("Current Life2", "3");
					PlayerPrefs.SetInt("ammo count2",0);
					PlayerPrefs.SetInt("rifle count2",0);
								}
						}
			
						if (profileManr.profile3 == true) {
								if (PlayerPrefs.GetInt ("player_3_progress") >= 1) {
										Application.LoadLevel ("level2");
										var glazba = GameObject.Find ("main_music");
										AudioClip clip = Resources.Load ("Theme") as AudioClip;
										glazba.audio.clip = clip;
										glazba.audio.Play ();
										DontDestroyOnLoad (profileManar);
					PlayerPrefs.SetString ("Current Life3", "3");
					PlayerPrefs.SetInt("ammo count3",0);
					PlayerPrefs.SetInt("rifle count3",0);
								}
						}
				}



		if (gameObject.name == "level3") {
			var profileManar = GameObject.Find ("profileManager");
			var profileManr = profileManar.GetComponent<ProfileManager> ();
			
			if (profileManr.profile1 == true) {
				if (PlayerPrefs.GetInt ("player_1_progress") >= 2) {
					Application.LoadLevel ("level3");
					var glazba = GameObject.Find ("main_music");
					AudioClip clip = Resources.Load ("Theme") as AudioClip;
					glazba.audio.clip = clip;
					glazba.audio.Play ();
					DontDestroyOnLoad (profileManar);
					PlayerPrefs.SetString ("Current Life1","3");
					PlayerPrefs.SetInt("ammo count1",0);
					PlayerPrefs.SetInt("rifle count1",0);
					
				}
			}
			
			
			if (profileManr.profile2 == true) {
				if (PlayerPrefs.GetInt ("player_2_progress") >= 2) {
					Application.LoadLevel ("level3");
					var glazba = GameObject.Find ("main_music");
					AudioClip clip = Resources.Load ("Theme") as AudioClip;
					glazba.audio.clip = clip;
					glazba.audio.Play ();
					DontDestroyOnLoad (profileManar);
					PlayerPrefs.SetString ("Current Life2", "3");
					PlayerPrefs.SetInt("ammo count2",0);
					PlayerPrefs.SetInt("rifle count2",0);
				}
			}
			
			if (profileManr.profile3 == true) {
				if (PlayerPrefs.GetInt ("player_3_progress") >= 2) {
					Application.LoadLevel ("level3");
					var glazba = GameObject.Find ("main_music");
					AudioClip clip = Resources.Load ("Theme") as AudioClip;
					glazba.audio.clip = clip;
					glazba.audio.Play ();
					DontDestroyOnLoad (profileManar);
					PlayerPrefs.SetString ("Current Life3", "3");
					PlayerPrefs.SetInt("ammo count3",0);
					PlayerPrefs.SetInt("rifle count3",0);
				}
			}
		}

		if (gameObject.name == "Change_Profile") {
			Application.LoadLevel("profile_select");
			var glazba = GameObject.Find ("main_music");
			Destroy(glazba);
			var profileManager=GameObject.Find("profileManager");
			var profile=profileManager.GetComponent<ProfileManager>();
			profile.profile1=false;
			profile.profile2=false;
			profile.profile3=false;
				}

				if (gameObject.name == "continue") {


						var profileManar = GameObject.Find ("profileManager");
						var profileManr = profileManar.GetComponent<ProfileManager> ();
						var ContinueButton = GameObject.Find ("continue");
						
							if (profileManr.profile1 == true) {
				if(PlayerPrefs.GetInt("player_1_progress")>0){
										Application.LoadLevel (PlayerPrefs.GetString ("CurrentLevelPlayer1"));

										var glazba = GameObject.Find ("main_music");
										AudioClip clip = Resources.Load ("Theme") as AudioClip;
										glazba.audio.clip = clip;
										glazba.audio.Play ();
										DontDestroyOnLoad (profileManr);
					DontDestroyOnLoad (glazba);}
				else{return;}
								}

								if (profileManr.profile2 == true) {
				if(PlayerPrefs.GetInt("player_2_progress")>0){
										Application.LoadLevel (PlayerPrefs.GetString ("CurrentLevelPlayer2"));
										var glazba = GameObject.Find ("main_music");
										AudioClip clip = Resources.Load ("Theme") as AudioClip;
										glazba.audio.clip = clip;
										glazba.audio.Play ();
					DontDestroyOnLoad (profileManr);				DontDestroyOnLoad (glazba);}

				else{return;}
						
								}
								if (profileManr.profile3 == true) {
				if(PlayerPrefs.GetInt("player_3_progress")>0){
										Application.LoadLevel (PlayerPrefs.GetString ("CurrentLevelPlayer3"));
										var glazba = GameObject.Find ("main_music");
										AudioClip clip = Resources.Load ("Theme") as AudioClip;
										glazba.audio.clip = clip;
										glazba.audio.Play ();
					DontDestroyOnLoad (profileManr);
					DontDestroyOnLoad (glazba);}
				else{return;}
								}
						
						
				}
		}

        void OnMouseExit ()
        {
		var profileManager=GameObject.Find("profileManager");
		var profile=profileManager.GetComponent<ProfileManager>();

		if(Application.loadedLevelName=="Select_level"){
			if (gameObject.name == "level3") {
				if(profile.profile1==true){
					if (PlayerPrefs.GetInt ("player_1_progress") < 2 ) {
						return;}
					else{gameObject.renderer.material.color = Color.yellow;}}
				
				if(profile.profile2==true){			
					if (PlayerPrefs.GetInt ("player_2_progress") < 2) {
						return;
					}
					else{gameObject.renderer.material.color = Color.yellow;}}
				
				if(profile.profile3==true){					
					if (PlayerPrefs.GetInt ("player_3_progress") < 2) {
						return;
					}
					else{gameObject.renderer.material.color = Color.yellow;}
				}
			} 

		if (gameObject.name == "level2") {
			if(profile.profile1==true){
				if (PlayerPrefs.GetInt ("player_1_progress") == 0 ) {return;}
				else{gameObject.renderer.material.color = Color.yellow;}}
			
			if(profile.profile2==true){			
				if (PlayerPrefs.GetInt ("player_2_progress") == 0) {
					return;
				}
				else{gameObject.renderer.material.color = Color.yellow;}}
			
			if(profile.profile3==true){					
				if (PlayerPrefs.GetInt ("player_3_progress") == 0) {
					return;
				}
				else{gameObject.renderer.material.color = Color.yellow;}}
			}else{gameObject.renderer.material.color = Color.white;}}


		if (gameObject.name == "continue") {
			if(profile.profile1==true){
						if (PlayerPrefs.GetInt ("player_1_progress") == 0 ) {
								return;}
				else{gameObject.renderer.material.color = Color.yellow;}}

			if(profile.profile2==true){			
			if (PlayerPrefs.GetInt ("player_2_progress") == 0) {
								return;}
				else{gameObject.renderer.material.color = Color.yellow;}}

			if(profile.profile3==true){					
			if (PlayerPrefs.GetInt ("player_3_progress") == 0) {
								return;}
					else{gameObject.renderer.material.color = Color.yellow;}}}
		else {gameObject.renderer.material.color = Color.white;}	
	}


}


    