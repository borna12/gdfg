using System;
using System.Net.Mime;
using UnityEngine;
using System.Collections;

public class VolumeMeni : MonoBehaviour
{

    private TextMesh tm;


	// Use this for initialization

     void Awake()
    {
        var glazba = GameObject.Find("main_music");
        tm = (TextMesh)GameObject.Find("volume").GetComponent<TextMesh>();
         float cjeli;
         cjeli = glazba.audio.volume*10;
         cjeli = Convert.ToInt32(cjeli);
         tm.text = cjeli.ToString();


    }

    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseEnter()
    {
        renderer.material.color = Color.gray;

    }

    private void OnMouseDown()
    {
        if (gameObject.name == "arrow-right")
        {
            
            var glazba = GameObject.Find("main_music".ToString());
            glazba.audio.volume += .1f;
            int a = int.Parse(tm.text);
            if (a < 10)
            { 
                a = a + 1;
            }
            tm.text = a.ToString();
        }





            if (gameObject.name == "arrow-left")
            {


                var glazba = GameObject.Find("main_music".ToString());
                glazba.audio.volume -= .1f;
               int a = int.Parse(tm.text);

                if (a == 10||a>0){
                  a = a - 1;    
                    }
                tm.text = a.ToString();
            }
        }
    


    void OnMouseExit()
    {

        renderer.material.color = Color.white;
        /*
        Time.timeScale = 1;
        var glazba = GameObject.Find("main_music");
        glazba.audio.PlayScheduled(1);
        gameObject.SetActive(false);*/
    }

  
}
