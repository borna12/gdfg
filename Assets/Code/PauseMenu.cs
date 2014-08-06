using System;

using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(AudioSource))]

public class PauseMenu : MonoBehaviour
{
    

    private Rect windowRect;
    private Rect windowRect2;
    private Rect windowRect3;
    private Rect windowRect4;
    private Rect windowRect5;

    private bool editing = true;
    private bool editing2 = true;
    private bool editing3 = true;
    private bool editing4 = true;
    //private bool editing5 = true;

    private string screen;
    private string vsynch;
    //private string texture;

    private float GammaCorrection;



    private void Start()
    {
        

    }

    private void Update()
    {
        //RenderSettings.ambientLight =  Color.Lerp(Color.white, Color.black, GammaCorrection);
        windowRect = new Rect(Screen.width / 2 - 120, Screen.height / 2 - 100, 200, 100);
        windowRect2 = new Rect(Screen.width / 2 - 120, Screen.height / 2 - 100, 200, 130);
        windowRect3 = new Rect(Screen.width / 2 - 120, Screen.height / 2 - 100, 290, 230);
        windowRect4 = new Rect(Screen.width / 2 - 120, Screen.height / 2 - 100, 250, 130);
       // windowRect5 = new Rect(Screen.width / 2 - 120, Screen.height / 2 - 100, 250, 200);

        /* 
        if (Texture2D.masterTextureLimit == 1)
        {
            texture = "Good";
        }
        else
        {
            texture = "Bad";
        }*/

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
            screen = "window view";
        }
        else
        {
            screen = "fullscreen view";
        }

        if (Input.GetKeyDown(KeyCode.P) == true || Input.GetKeyDown(KeyCode.Escape) == true)
        {

            if (Time.timeScale == 1)
            {

                Time.timeScale = 0;
                Screen.showCursor = true;
                var glazba = GameObject.Find("main_music");
                glazba.audio.Pause();
                var Player = GameObject.Find("Player");
                Player.GetComponent<Player>().enabled = false;

               
            }
            else
            {
                Time.timeScale = 1;
                var glazba = GameObject.Find("main_music");
                glazba.audio.PlayScheduled(1);
                var Player = GameObject.Find("Player");
                Player.GetComponent<Player>().enabled = true;
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
            windowRect = GUI.Window(0, windowRect, windowFunc2, "Options Menu");
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

        /*if (editing5 == false)
        {
            windowRect5 = GUI.Window(0, windowRect5, windowFunc6, "Controles");
            if (Input.GetKeyDown(KeyCode.Escape) == true || Input.GetKeyDown(KeyCode.P) == true)
            {
                editing5 = true;
            }
        }*/
    }

    private void windowFunc(int id)
    {
        if (GUILayout.Button("Resume"))
        {
            Time.timeScale = 1;
            var glazba = GameObject.Find("main_music");
            glazba.audio.PlayScheduled(1);
            var Player = GameObject.Find("Player");
            //Player.GetComponent<CharacterController2D>().enabled = true;
            Player.GetComponent<Player>().enabled = true;
        }

        if (GUILayout.Button("Options"))
        {
            editing = false;
        }

        if (GUILayout.Button("Quit"))
        {
            Application.Quit();
        }
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
       /* if (GUILayout.Button("Controls"))
        {
            editing5 = false;
        }*/
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


        GUILayout.Label("SFX Volume: " + Convert.ToInt32(AudioListener.volume*10));

        AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0f, 1f);


        if (GUILayout.Button("Back"))
        {
            editing2 = true;

        }
    }
    /*
    private void windowFunc6(int id)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Move Right");
        if (GUILayout.Button())
        {
        }
        GUILayout.EndHorizontal();

    }*/

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
        GUILayout.Label("Change to "+screen);
        
        if (GUILayout.Toggle(false, ""))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        GUILayout.EndHorizontal();

        //GUILayout.Label("Brightness: " + GammaCorrection.ToString());
        //GammaCorrection = GUILayout.HorizontalSlider(GammaCorrection, 0, 1);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Set VSynch to: ");
        if (GUILayout.Button(vsynch))
        {
            if (QualitySettings.vSyncCount==1)
            QualitySettings.vSyncCount = 0;
            else
            {
                QualitySettings.vSyncCount = 1;
            }

        }
        GUILayout.EndHorizontal();

        /*  GUILayout.BeginHorizontal();
        GUILayout.Label("Texture Quality: ");
        if (GUILayout.Button(texture))
        {
            if (texture == "Bad")
                Texture2D.masterTextureLimit = 1;
            else
            {
                Texture2D.masterTextureLimit = 0;
            }
        }
        
        GUILayout.EndHorizontal();*/

        if (GUILayout.Button("Back"))
        {

            editing4 = true;

        }
    }

    private void windowFunc4(int id)
    {
       
        GUILayout.Label("Screen Resolution: ");

       GUILayout.BeginHorizontal();
       if (GUILayout.Button("640 × 480"))
       {
           Screen.SetResolution(640,480,true);
       }
       if (GUILayout.Button("720 × 400"))
       {
           Screen.SetResolution(720, 400, true);
       }
       if (GUILayout.Button("720 x 576"))
       {
           Screen.SetResolution(720, 576, true);
       }
       GUILayout.EndHorizontal();

       GUILayout.BeginHorizontal();
       if (GUILayout.Button("800 × 600"))
       {
           Screen.SetResolution(800, 600, true);
       }
       if (GUILayout.Button("1024 × 768"))
       {
           Screen.SetResolution(1024, 768, true);
       }
       if (GUILayout.Button("1152 x 864"))
       {
           Screen.SetResolution(1152, 864, true);
       }
       GUILayout.EndHorizontal();

       GUILayout.BeginHorizontal();
       if (GUILayout.Button("1280 × 720"))
       {
           Screen.SetResolution(1280, 720, true);
       }
       if (GUILayout.Button("1280 × 800"))
       {
           Screen.SetResolution(1280, 800, true);
       }
       if (GUILayout.Button("1280 x 960"))
       {
           Screen.SetResolution(1280, 960, true);
       }
       GUILayout.EndHorizontal();



       GUILayout.BeginHorizontal();
       if (GUILayout.Button("1280 × 1024"))
       {
           Screen.SetResolution(1280, 1024, true);
       }
       if (GUILayout.Button("1360 × 768"))
       {
           Screen.SetResolution(1360, 768, true);
       }
       if (GUILayout.Button("1440 x 900"))
       {
           Screen.SetResolution(1440, 900, true);
       }
       GUILayout.EndHorizontal();


       GUILayout.BeginHorizontal();
       if (GUILayout.Button("1600 × 900"))
       {
           Screen.SetResolution(1600, 900, true);
       }
       if (GUILayout.Button("1600 × 1024"))
       {
           Screen.SetResolution(1600, 1024, true);
       }
       if (GUILayout.Button("1600 x 1200"))
       {
           Screen.SetResolution(1600, 1200, true);
       }
       GUILayout.EndHorizontal();



       GUILayout.BeginHorizontal();
       if (GUILayout.Button("1680 × 1050"))
       {
           Screen.SetResolution(1680, 1050, true);
       }
       if (GUILayout.Button("1920 × 1080"))
       {
           Screen.SetResolution(1920, 1080, true);
       }
       if (GUILayout.Button("1920 x 1200"))
       {
           Screen.SetResolution(1920, 1200, true);
       }
       GUILayout.EndHorizontal();

       if (GUILayout.Button("Back"))
       {
           editing3 = true;
           editing4 = false;

       }
    }




}