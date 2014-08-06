using System;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public string tekst = "{0:00}:{1:00} with {2} bonus";
	// Use this for initialization
    private int time;
  
	void Start () {
	
	}
	
	// Update is called once per frame
    private void Update()
    {
          time=(int) Time.timeSinceLevelLoad;

        var minute =  (int) Mathf.Abs(time/60);
        var seconds =time%60;



        TextMesh tajme = (TextMesh)GetComponent(typeof(TextMesh));
        tajme.text = string.Format(
            tekst,
            minute,
            seconds,
            LevelManager.Instance.CurrentTimeBonus)
            ;
        
           
        }
    





}
