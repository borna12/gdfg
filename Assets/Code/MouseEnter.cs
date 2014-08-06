using UnityEngine;
using System.Collections;

public class MouseEnter : MonoBehaviour
{

    // Use this for initialization
    private TextMesh tm;
    private Renderer textRenderer;

    private void Awake()
    {

    }

    private void Start()
    {
        Screen.showCursor = true;

    }

    // Update is called once per frame
    private void Update()
    {

    }


    private void OnMouseEnter()
    {
        renderer.material.color = Color.gray;

    }

    private void OnMouseDown()
    {
        if (gameObject.name == "exit")
            Application.Quit();

        if (gameObject.name == "options")
        {
            Application.LoadLevel("options");
            var glazba = GameObject.Find("main_music");
            DontDestroyOnLoad(glazba);
        }


        if (gameObject.name == "back")
        {
            Application.LoadLevel("menu");
            var glazba = GameObject.Find("main_music");
            DontDestroyOnLoad(glazba);
        }

        if (gameObject.name == "new_game")
            {
                Application.LoadLevel("level1");
                var glazba = GameObject.Find("main_music");
                
                
               
                AudioClip clip = Resources.Load("Theme") as AudioClip;
                glazba.audio.clip = clip;
                glazba.audio.Play();
                
            }
        }


        void OnMouseExit ()
        {

            renderer.material.color = Color.white;
        }


    
}