using System;
using System.Net.Mime;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolumeMeni : MonoBehaviour
{

    private TextMesh tm;
	private TextMesh tm2;
	private TextMesh tm3;
	private GameObject checkbox;
	public GameObject x;
	public GameObject x2;
	private GameObject checkbox2;

	List<string> iList=new List<string>();
	// Use this for initialization

     void Awake()
    {

				var glazba = GameObject.Find ("main_music");
				glazba.audio.ignoreListenerVolume = true;
				tm = (TextMesh)GameObject.Find ("volume").GetComponent<TextMesh> ();
				float cjeli;
				cjeli = glazba.audio.volume * 10;
				cjeli = Convert.ToInt32 (cjeli);
				tm.text = cjeli.ToString ();

				tm2 = (TextMesh)GameObject.Find ("volume2").GetComponent<TextMesh> ();
				float cjeli2;
				cjeli2 = AudioListener.volume * 10;
				cjeli2 = Convert.ToInt32 (cjeli2);
				tm2.text = cjeli2.ToString ();

				tm3 = (TextMesh)GameObject.Find ("res").GetComponent<TextMesh> ();
				tm3.text = Screen.currentResolution.width.ToString () + " x " + Screen.currentResolution.height.ToString ();
				Resolution [] resolutions= Screen.resolutions;
				foreach (Resolution res in resolutions) {
						iList.Add (res.width + " x " + res.height);}

				checkbox = GameObject.Find ("vsynch_on_off");
				checkbox2 = GameObject.Find ("window_on_off");

		}

    void Start () {
		}


	
	// Update is called once per frame
	void Update () {
		if (QualitySettings.vSyncCount == 1) {
			x.active=true;
		}
		if (QualitySettings.vSyncCount == 0) {
			x.active=false;
		}


		if(Screen.fullScreen==true){
			x2.active=false;
		} 
		else{
			Screen.fullScreen= Screen.fullScreen;
			x2.active=true;
		}

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
			PlayerPrefs.SetFloat("main_music",glazba.audio.volume);
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
			PlayerPrefs.SetFloat("main_music",glazba.audio.volume);
            }

		
		if (gameObject.name == "arrow-left2")
		{
			AudioListener.volume -= .1f;
			int a = int.Parse(tm2.text);
			if(AudioListener.volume<0f)
				AudioListener.volume += .1f;
			
			if (a == 10||a>0){
				a = a - 1;    
			}
			tm2.text = a.ToString();
			PlayerPrefs.SetFloat("sfx_music",AudioListener.volume);
		}

		
		if (gameObject.name == "arrow-right2")
		{

			AudioListener.volume += .1f;
			int a = int.Parse(tm2.text);
			if(AudioListener.volume>1f)
				AudioListener.volume -= .1f;
			if (a < 10)
			{ 
				a = a + 1;
			}
			tm2.text = a.ToString();
			PlayerPrefs.SetFloat("sfx_music",AudioListener.volume);
		}


		if (gameObject.name == "arrow-right3")
		{

			for(int i=0;i<=iList.Count; i++)
			{
				if(iList[i]==tm3.text){
					tm3.text=iList[i+1];
					return;
				}
			}
		}

		if (gameObject.name == "arrow-left3")
		{
			
			for(int i=0;i<=iList.Count; i++)
			{
				if(iList[i]==tm3.text){
					tm3.text=iList[i-1];
					return;
				}
			}
		}

		if (gameObject.name == "res_set")
		{


			int x=tm3.text.IndexOf("x");

			int width=Convert.ToInt32(tm3.text.Remove(x-1));
			int height=Convert.ToInt32(tm3.text.Substring(x+1));



			Screen.SetResolution(width,height,true);
		}

		if (gameObject.name == "vsynch_on_off")
		{
			if (QualitySettings.vSyncCount==1)
			{QualitySettings.vSyncCount = 0;
				PlayerPrefs.SetInt("vsynch",QualitySettings.vSyncCount = 0);}
			else
			{
				QualitySettings.vSyncCount = 1;
				PlayerPrefs.SetInt("vsynch",QualitySettings.vSyncCount = 1);}
			}

		if (gameObject.name == "window_on_off")
		{
			if(Screen.fullScreen==true){
				Screen.fullScreen= !Screen.fullScreen;
			} 
			if(Screen.fullScreen!=true){
				Screen.fullScreen= true;
			}
		}
	}
		




        
    


    void OnMouseExit()
    {

        renderer.material.color = Color.white;
    }

  
}
