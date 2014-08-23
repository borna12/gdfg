using UnityEngine;
using System;

public class GameHud :MonoBehaviour
		{
	public GUISkin Skin;

    public string tekst="{0:00}:{1:00} with {2} bonus";
    public Color TextColor = Color.black;

 
	public void OnGUI()

	{

        /* 
		GUI.skin = Skin;
        GUILayout.BeginArea(new Rect(20, 200, Screen.width, Screen.height));
		{
            
			GUILayout.BeginVertical(Skin.GetStyle("GameHud"));
		    {
		        GUILayout.Label(string.Format("Points:{0}", GameManager.Instance.Points), Skin.GetStyle("PointsText"));

                
		       var time = LevelManager.Instance.RunningTime;
		        GUILayout.Label(string.Format(
		                tekst,
		                time.Minutes + (time.Hours*60),
		                time.Seconds,
		                LevelManager.Instance.CurrentTimeBonus), Skin.GetStyle("TimeText")
		                );
		    }
			GUILayout.EndVertical();
		}
		GUILayout.EndArea ();
          */

    }
}