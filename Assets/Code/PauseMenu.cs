using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    private Rect windowRect;
    private Rect windowRect2;
    private Rect windowRect3;
    private Rect windowRect4;
    private Rect windowRect5;
    private Rect windowRect6;
	
    private bool editing = true;
    private bool editing2 = true;
    private bool editing3 = true;
    private bool editing4 = true;
    private bool editing5 = true;
    private bool editing6 = true;
	
    private string screen;
    private string vsynch;

	private int lister=49;
	List<string> iList=new List<string>();
    private float GammaCorrection;


	void Awake(){
		Resolution [] resolutions= Screen.resolutions;
		foreach (Resolution res in resolutions) {
			iList.Add (res.width + " x " + res.height);
			lister=lister-1;}
		Screen.showCursor = false;
		var profileMan = GameObject.Find ("profileManager");
		var profile = profileMan.GetComponent<ProfileManager> ();

		if (profile.profile1 == true) {
			PlayerPrefs.SetString ("CurrentLevelPlayer1",Application.loadedLevelName.ToString());
		}
		if (profile.profile2 == true) {
			PlayerPrefs.SetString ("CurrentLevelPlayer2",Application.loadedLevelName.ToString());
		}
		if (profile.profile3 == true) {
			PlayerPrefs.SetString ("CurrentLevelPlayer3",Application.loadedLevelName.ToString());
		}

	}

    private void Start()
    {
        
		Time.timeScale = 1;
		var glaz = GameObject.Find("main_music");
		if (glaz.audio.isPlaying == false)
		{
			AudioClip clip = Resources.Load("Theme") as AudioClip;
			glaz.audio.clip = clip;
			glaz.audio.Play();
		}
    }

    private void Update()
    {
        //RenderSettings.ambientLight =  Color.Lerp(Color.white, Color.black, GammaCorrection);
        windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180);
        windowRect2 = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 130);
		windowRect3 = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 300, 250, iList.Count*lister);
		windowRect4 = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 130);
        windowRect5 = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100);

        if (QualitySettings.vSyncCount == 1)
        {
            vsynch = "Off";
        }
        else
        {
            vsynch = "On";
        }

        if (Screen.fullScreen == true)
        {
            screen = "Window";
        }
        else
        {
            screen = "Fullscreen";
        }

        if (Input.GetKeyDown(KeyCode.P) == true || Input.GetKeyDown(KeyCode.Escape) == true)
        {

            if (Time.timeScale == 1)
            {

                Time.timeScale = 0;
                Screen.showCursor = true;
                var glazba = GameObject.Find("main_music");
                glazba.audio.Pause();
				gameObject.GetComponent<Player>().enabled = false;

				if(gameObject.GetComponent<Player>().CurrentWeapon==gameObject.GetComponent<Player>().Weapon2)
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUp>().enabled=false;
				if(gameObject.GetComponent<Player>().CurrentWeapon==gameObject.GetComponent<Player>().Weapon1)
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUpKnife>().enabled=false;
				if(gameObject.GetComponent<Player>().CurrentWeapon==gameObject.GetComponent<Player>().Weapon3)
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUp2>().enabled=false;


               
            }
            else
            {
                Time.timeScale = 1;
                var glazba = GameObject.Find("main_music");
                glazba.audio.PlayScheduled(1);

				gameObject.GetComponent<Player>().enabled = true;
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUp>().enabled=true;
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUpKnife>().enabled=true;
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUp2>().enabled=true;
                Screen.showCursor = false;
            }
        }
    }

    private void OnGUI()
    {
        if (Time.timeScale == 0)
            windowRect = GUI.Window(0, windowRect, windowFunc, "Pause Menu");

        if (editing == false)
        {
            windowRect5 = GUI.Window(0, windowRect5, windowFunc2, "Options Menu");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing = true;
            }
        }
        if (editing2 == false)
        {
            windowRect2 = GUI.Window(0, windowRect2, windowFunc3, "Sound Options");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing2 = true;
            }
        }
        if (editing3 == false)
        {
            windowRect3 = GUI.Window(0, windowRect3, windowFunc4, "Resolution Options");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing3 = true;
            }
        }
        if (editing4 == false)
        {
            windowRect4 = GUI.Window(0, windowRect4, windowFunc5, "Graphics Options");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing4= true;
            }
        }


        if (editing5 == false)
        {
            windowRect4 = GUI.Window(0, windowRect4, windowFunc8, "Controls");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing5 = true;
            }
        }
        if (editing6 == false)
        {
            windowRect4 = GUI.Window(0, windowRect4, windowFunc7, "Load Options");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing6 = true;
            }
        }
    }

    private void windowFunc(int id)
    {
		GUILayout.FlexibleSpace ();
        if (GUILayout.Button("Resume"))
        {
            Time.timeScale = 1;
            var glazba = GameObject.Find("main_music");
            glazba.audio.PlayScheduled(1);
            gameObject.GetComponent<Player>().enabled = true;
        }

        if (GUILayout.Button("Change level"))
        {

            editing6 = false;
        }

        if (GUILayout.Button("Controls"))
        {

            editing5 = false;
        } 

        if (GUILayout.Button("Options"))
        {
            editing = false;
        }

		if (GUILayout.Button("Back to main menu"))
		{
			Application.LoadLevel("menu");
			GameManager.Instance.ResetPoints(0);
			var glazba = GameObject.Find("main_music");
			AudioClip clip = Resources.Load("wicked") as AudioClip;
			DontDestroyOnLoad(glazba);
			DontDestroyOnLoad(GameObject.Find ("profileManager"));
			glazba.audio.clip = clip;
			glazba.audio.Play();

		}

        if (GUILayout.Button("Quit"))
        {
            Application.Quit();
        }
		GUILayout.FlexibleSpace ();
    }

    private void windowFunc2(int id)
    {
        if (GUILayout.Button("Sound"))
        {
            editing2 = false;
        }
        if (GUILayout.Button("Graphics"))
        {
            editing4 = false;
        }
 
        if (GUILayout.Button("Back"))
        {
            editing = true;
        }
    }

    private void windowFunc3(int id)
    {
        var glazba = GameObject.Find("main_music");
        glazba.audio.ignoreListenerVolume = true;
        GUILayout.Label("Music Volume: " + Convert.ToInt32(glazba.audio.volume*10).ToString());
        glazba.audio.volume = GUILayout.HorizontalSlider(glazba.audio.volume, 0f, 1f);
		PlayerPrefs.SetFloat("main_music",glazba.audio.volume);

        GUILayout.Label("SFX Volume: " + Convert.ToInt32(AudioListener.volume*10));

        AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0f, 1f);
		PlayerPrefs.SetFloat("sfx_music",AudioListener.volume);

        if (GUILayout.Button("Back"))
        {
            editing2 = true;

        }
    }
 

    private void windowFunc5(int id)
    {
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Resolution: ");
        
        if (GUILayout.Button(Screen.currentResolution.width.ToString() + "x" + Screen.currentResolution.height.ToString()))
        {
            editing4 = true;
            editing3 = false;
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Change to:");
        
		if (GUILayout.Button(screen))
        {
			if(Screen.fullScreen==true){
				Screen.fullScreen= !Screen.fullScreen;
			} 
			if(Screen.fullScreen!=true){
				Screen.fullScreen= true;
			}
        }
        GUILayout.EndHorizontal();

        //GUILayout.Label("Brightness: " + GammaCorrection.ToString());
        //GammaCorrection = GUILayout.HorizontalSlider(GammaCorrection, 0, 1);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Set VSynch to: ");
        if (GUILayout.Button(vsynch))
        {
            if (QualitySettings.vSyncCount==1){
				QualitySettings.vSyncCount = 0;
				PlayerPrefs.SetInt("vsynch",QualitySettings.vSyncCount = 0);
			}
            else
            {
                QualitySettings.vSyncCount = 1;
				PlayerPrefs.SetInt("vsynch",QualitySettings.vSyncCount = 1);
            }

        }
        GUILayout.EndHorizontal();


        if (GUILayout.Button("Back"))
        {

            editing4 = true;

        }
    }

    private void windowFunc4(int id)
    {
       
        GUILayout.Label("Screen Resolution: ");
		GUILayout.FlexibleSpace ();
		foreach(string x in iList)
		{		GUILayout.FlexibleSpace ();
			if (GUILayout.Button(x))

			{
				int y=x.IndexOf("x");
				
				int width=Convert.ToInt32(x.Remove(y-1));
				int height=Convert.ToInt32(x.Substring(y+1));

				Screen.SetResolution(width,height,true);
			}


		}

       if (GUILayout.Button("Back"))
       {
           editing3 = true;
           editing4 = false;

       }
		GUILayout.FlexibleSpace ();
    }


    private void windowFunc7(int id)
    {


				GUILayout.FlexibleSpace ();

				var profileManager = GameObject.Find ("profileManager");
				var profileMana = profileManager.GetComponent<ProfileManager> ();
        
				if (GUILayout.Button ("Level1")) {
			GameManager.Instance.ResetPoints(0);
						Application.LoadLevel ("level1");

			if (profileMana.profile1 == true) {
				PlayerPrefs.SetInt("ammo count1",0);
				PlayerPrefs.SetInt("rifle count1",0);}
			if (profileMana.profile2 == true) {
				PlayerPrefs.SetInt("ammo count2",0);}
			PlayerPrefs.SetInt("rifle count2",0);
			if (profileMana.profile3 == true) {
				PlayerPrefs.SetInt("ammo count3",0);
				PlayerPrefs.SetInt("rifle count3",0);}
			return;
				}

				if (profileMana.profile1 == true) {
						if (PlayerPrefs.GetInt ("player_1_progress") >= 1) {
								if (GUILayout.Button ("Level2")) {
					GameManager.Instance.ResetPoints(0);
										Application.LoadLevel ("level2");
					PlayerPrefs.SetInt("ammo count1",0);
					PlayerPrefs.SetInt("rifle count1",0);
					return;

								}
						}
				}
				if (profileMana.profile2 == true) {
						if (PlayerPrefs.GetInt ("player_2_progress") >= 1) {
								if (GUILayout.Button ("Level2")) {
					GameManager.Instance.ResetPoints(0);
										Application.LoadLevel ("level2");
					PlayerPrefs.SetInt("ammo count2",0);
					PlayerPrefs.SetInt("rifle count2",0);

					return;
								}
			
						}
				}
				if (profileMana.profile3 == true) {
						if (PlayerPrefs.GetInt ("player_3_progress") >= 1) {
								if (GUILayout.Button ("Level2")) {
					GameManager.Instance.ResetPoints(0);
										Application.LoadLevel ("level2");
					PlayerPrefs.SetInt("ammo count3",0);
					PlayerPrefs.SetInt("rifle count3",0);
					return;

								}
						}
				}


		if (profileMana.profile1 == true) {
			if (PlayerPrefs.GetInt ("player_1_progress") >= 2) {
				if (GUILayout.Button ("Level3")) {
					GameManager.Instance.ResetPoints(0);
					Application.LoadLevel ("level3");
					PlayerPrefs.SetInt("ammo count1",0);
					PlayerPrefs.SetInt("rifle count1",0);
					return;
					
				}
			}
		}
		if (profileMana.profile2 == true) {
			if (PlayerPrefs.GetInt ("player_2_progress") >= 2) {
				if (GUILayout.Button ("Level3")) {
					GameManager.Instance.ResetPoints(0);
					Application.LoadLevel ("level3");
					PlayerPrefs.SetInt("ammo count2",0);
					PlayerPrefs.SetInt("rifle count2",0);
					
					return;
				}
				
			}
		}
		if (profileMana.profile3 == true) {
			if (PlayerPrefs.GetInt ("player_3_progress") >= 2) {
				if (GUILayout.Button ("Level3")) {
					GameManager.Instance.ResetPoints(0);
					Application.LoadLevel ("level3");
					PlayerPrefs.SetInt("ammo count3",0);
					PlayerPrefs.SetInt("rifle count3",0);
					return;
					
				}
			}
		}



		if (GUILayout.Button("Back"))
		{
			
			editing6 = true;
			
		}
				GUILayout.FlexibleSpace ();
		}


    private void windowFunc8(int id)
    {
        GUILayout.Label("" +
        	"Control Options");
        GUILayout.Button("");
    }


    private void LoadLevel1(int levelnumb)
{

}

    private void LoadLevel2(int levelnumb)
    {

    }


}