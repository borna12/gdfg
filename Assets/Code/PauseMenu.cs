using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    //parametri za određene gui prozore
    private Rect windowRect;
    private Rect windowRect2;
    private Rect windowRect3;
    private Rect windowRect4;
    private Rect windowRect5;
    private Rect windowRect6;
	
    //booleanove vrijednosti koje kada su istinite otvaraju određene gui prozore s različitim opcijama
    private bool editing = true;
    private bool editing2 = true;
    private bool editing3 = true;
    private bool editing4 = true;
    private bool editing5 = true;
    private bool editing6 = true;
	
    //stringovi za gumbe koji se mjenjaju(recimo on/off)
    private string screen;
    private string vsynch;
    private string fps;

    //guitext koji prikazuje fps
    private GameObject guitext;

    //veličina prozora za prikaz rezolucija monitora
	private int lister=49;
	List<string> iList=new List<string>();
    private float GammaCorrection;




	void Awake(){

        guitext = GameObject.Find("FPSCOUNTER");

        //sve rezolucije stavi u liastu
		Resolution [] resolutions= Screen.resolutions;
		foreach (Resolution res in resolutions) {
			iList.Add (res.width + " x " + res.height);
			lister=lister-1;}


		Screen.showCursor = false;
		var profileMan = GameObject.Find ("profileManager");
		var profile = profileMan.GetComponent<ProfileManager> ();

        //zabilježi na kojem je trenutnom levelu igrać
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

        //gleda jeli u opcijama uključen fpscounter
        if (PlayerPrefs.GetInt("fpscounter") == 1)
        {
            guitext.active = true;
        }
        else
        {
            guitext.active = false;
        }
    }

    private void Update()
    {
        //širina, visina i pozicija određenih gui prozora
        windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180);
        windowRect2 = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 130);
		windowRect3 = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 300, 250, iList.Count*lister);
		windowRect4 = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 130);
        windowRect5 = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100);
        windowRect6 = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 150);

        //provjerava uključenost vsyncha -samo za prikaz teksta gumba u gui-u
        if (QualitySettings.vSyncCount == 1)
        {
            vsynch = "Off";
        }
        else
        {
            vsynch = "On";
        }

        //provjerava je li u window modu prikaz -samo za prikaz teksta gumba u gui-u
        if (Screen.fullScreen == true)
        {
            screen = "Window";
        }
        else
        {
            screen = "Fullscreen";
        }
        //provjerava je li u fpscounter uključen -samo za prikaz teksta gumba u gui-u
        if (guitext.activeInHierarchy == false)
        {
            fps = "On";
        }
        else
        {
            fps = "Off";
        }


        // funkcija za pauzu koja se pokreće pritiskom na p ili esc
        if (Input.GetKeyDown(KeyCode.P) == true || Input.GetKeyDown(KeyCode.Escape) == true)
        {

            if (Time.timeScale == 1)
            {

                Time.timeScale = 0;
               
                //zaustavljanje glazbe
                var glazba = GameObject.Find("main_music");
                glazba.audio.Pause();


                //onemogučavanje okretanja lika
				gameObject.GetComponent<Player>().enabled = false;


                //onemogučavanje pucanja iz oružja. ime svoj kod napiši tu umjesto mojeg
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

                //nastavlja svirati glazbu
                var glazba = GameObject.Find("main_music");
                glazba.audio.PlayScheduled(1);

				gameObject.GetComponent<Player>().enabled = true;

                //omoguči korisštenje oružja, ime opet zamjeni svojim kodom
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUp>().enabled=true;
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUpKnife>().enabled=true;
				gameObject.GetComponent<Player>().CurrentWeapon.GetComponent<WeaponPickUp2>().enabled=true;

            }
        }
    }

    private void OnGUI()
    {
        //Gui prozorčići pauza menija

        //glavni prozor
        if (Time.timeScale == 0)
        {

            windowRect = GUI.Window(0, windowRect, windowFunc, "Pause Menu");
           
        }

        //prozori za zvuk i grafiku
        if (editing == false)
        {
            windowRect5 = GUI.Window(0, windowRect5, windowFunc2, "Options Menu");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing = true; //kada je editing true vodi do drugoog prozora i zatvra trenutni
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
            windowRect6 = GUI.Window(0, windowRect6, windowFunc5, "Graphics Options");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing4= true;
            }
        }

        //prozor za kontrole čemo ispuniti dok sredimo glavnog lika i otkrijemo što sve želimo imati u igri
        if (editing5 == false)
        {
            windowRect4 = GUI.Window(0, windowRect4, windowFunc8, "Controls");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing5 = true;
            }
        }

        // za biranje nivoa
        if (editing6 == false)
        {
            windowRect4 = GUI.Window(0, windowRect4, windowFunc7, "Load Options");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing6 = true;
            }
        }
    }


    //funkcije koje pokreću određeni gumbi unutar prozora

    //funkcija za glavni prozor
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

    //funkcija za zvuk
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

    //funkcija za rezolucije i grafiku
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

        GUILayout.BeginHorizontal();
        GUILayout.Label("FPS Counter");
        if (GUILayout.Button(fps))
        {
            if (guitext.active == true)
            {
                guitext.SetActive(false);
                PlayerPrefs.SetInt("fpscounter", 0);
            }
            else
            {
                guitext.SetActive(true);
                PlayerPrefs.SetInt("fpscounter", 1);
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

    //funkcija u slučaju izbora drugog nivoa(stavlja život i municiju po defaultu)
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




}