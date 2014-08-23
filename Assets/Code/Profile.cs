using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Profile : MonoBehaviour {
	private Rect windowRect;
	public GameObject okvir;
	public GameObject profil1;
	public GameObject profil2;
	public GameObject profil3;

	public GameObject del1;
	public GameObject del2;
	public GameObject del3;
	 
	private bool pro1=false;
	private bool pro2=false;
	private bool pro3=false;

	private bool delp1=false;
	private bool delp2=false;
	private bool delp3=false;

	Vector3 v1= new Vector3(-0.08242416f,-0.2205267f,0);
	Vector3 v2= new Vector3(-0.08242416f,-1.874716f,0);
	Vector3 v3= new Vector3(-0.08242416f,-3.515492f,0);
	int selecteditem=0;
	private string guistring="";
	

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		Screen.showCursor = true;
		var prof = profil1.GetComponent <SpriteRenderer> ();
		prof.color = Color.gray;

		var name1=GameObject.Find("profilename1");
		var text1=name1.GetComponent<TextMesh>();
		if (PlayerPrefs.GetString ("player 1").Length>0) {
			text1.text = PlayerPrefs.GetString ("player 1");
			del1.active=true;
		} else {text1.text = "Profile 1";}
				


		var name2=GameObject.Find("profilename2");
		var text2=name2.GetComponent<TextMesh>();
		if (PlayerPrefs.GetString ("player 2").Length> 0) {
		text2.text = PlayerPrefs.GetString ("player 2");
			del2.active=true;
		}else {text2.text = "Profile 2";}

		var name3=GameObject.Find("profilename3");
		var text3=name3.GetComponent<TextMesh>();
		if (PlayerPrefs.GetString ("player 3").Length > 0) {
			text3.text = PlayerPrefs.GetString ("player 3");
			del3.active=true;
		}else {text3.text = "Profile 3";}
	}
	
	// Update is called once per frame
	void Update () {
		windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 80);
				var prof = profil1.GetComponent <SpriteRenderer> ();
				var prof3 = profil3.GetComponent <SpriteRenderer> ();
				var prof2 = profil2.GetComponent <SpriteRenderer> ();

				if (Input.GetKeyDown (KeyCode.DownArrow) == true) {

						switch (selecteditem) {

						case 0:
								okvir.transform.position = v2;
								selecteditem = 1;
								prof.color = new Color (121, 178, 225, 255);
								prof2.color = Color.gray;
								prof3.color = new Color (121, 178, 225, 255);
								break;

						case 1:
								okvir.transform.position = v3;
								selecteditem = 2;
								prof.color = new Color (121, 178, 225, 255);
								prof2.color = new Color (121, 178, 225, 255);
								prof3.color = Color.gray;
								break;

						case 2:
								okvir.transform.position = v1;
								selecteditem = 0;
								prof.color = Color.gray;
								prof2.color = new Color (121, 178, 225, 255);
								prof3.color = new Color (121, 178, 225, 255);
								break;
			}
			}
				if (Input.GetKeyDown (KeyCode.UpArrow) == true) {
						switch (selecteditem) {
					
						case 0:
								okvir.transform.position = v3;
								selecteditem = 2;
								prof.color = new Color (121, 178, 225, 255);
								prof2.color = new Color (121, 178, 225, 255);
								prof3.color = Color.gray;
								break;
					
						case 1:
								okvir.transform.position = v1;
								selecteditem = 0;
								prof.color = Color.gray;
								prof2.color = new Color (121, 178, 225, 255);
								prof3.color = new Color (121, 178, 225, 255);
								break;
					
						case 2:
								okvir.transform.position = v2;
								selecteditem = 1;
								prof.color = new Color (121, 178, 225, 255);
								prof2.color = Color.gray;
								prof3.color = new Color (121, 178, 225, 255);
								break;
						}
				}
	}

		private void OnMouseEnter()
		{
				
						var prof = profil1.GetComponent <SpriteRenderer> ();
						var prof3 = profil3.GetComponent <SpriteRenderer> ();
						var prof2 = profil2.GetComponent <SpriteRenderer> ();

						if (gameObject.name == "profile selection 1") {
						
								prof.color = Color.gray;
								prof2.color = new Color (121, 178, 225, 255);
								prof3.color = new Color (121, 178, 225, 255);
								okvir.transform.position = v1;
								selecteditem = 0;
						}
			
						if (gameObject.name == "profile selection 2") {
								prof.color = new Color (121, 178, 225, 255);
								prof2.color = Color.gray;
								prof3.color = new Color (121, 178, 225, 255);
								okvir.transform.position = v2;
								selecteditem = 1;
						}

						if (gameObject.name == "profile selection 3") {
								prof.color = new Color (121, 178, 225, 255);
								prof3.color = Color.gray;
								prof2.color = new Color (121, 178, 225, 255);
								okvir.transform.position = v3;
								selecteditem = 2;
				
						}

		}
		
		private void OnMouseDown()
	{

				if (gameObject.name == "profile selection 1") {
						var name1 = GameObject.Find ("profilename1");
						var text1 = name1.GetComponent<TextMesh> ();
						if (text1.text == PlayerPrefs.GetString ("player 1")) {
				var manager=GameObject.Find("profileManager");
				var manager2=manager.GetComponent<ProfileManager>();
				manager2.profile1=true;
				PlayerPrefs.GetInt("player_1_progress");
				Application.DontDestroyOnLoad(manager);
				Application.LoadLevel("menu");
						} 
			else {
				pro1 = true;
				var p2 = profil2.GetComponent<BoxCollider2D> ();
					p2.enabled = false;
				var p3 = profil3.GetComponent<BoxCollider2D> ();
					p3.enabled = false;

				var d1 = del1.GetComponent<BoxCollider2D> ();
				d1.enabled = false;
				var d2 = del2.GetComponent<BoxCollider2D> ();
				d2.enabled = false;
				var d3 = del3.GetComponent<BoxCollider2D> ();
				d3.enabled = false;
				okvir.active = false;
						}
				}

				if (gameObject.name == "profile selection 2") {
						var name2 = GameObject.Find ("profilename2");
						var text2 = name2.GetComponent<TextMesh> ();
						if (text2.text == PlayerPrefs.GetString ("player 2")) {
				var manager=GameObject.Find("profileManager");
				var manager2=manager.GetComponent<ProfileManager>();
				manager2.profile2=true;
				PlayerPrefs.GetInt("player_2_progress");
				Application.DontDestroyOnLoad(manager);
								Application.LoadLevel ("menu");
						} else {
								pro2 = true;
				var p1 = profil1.GetComponent<BoxCollider2D> ();
				p1.enabled = false;
				var p3 = profil3.GetComponent<BoxCollider2D> ();
				p3.enabled = false;

				var d1 = del1.GetComponent<BoxCollider2D> ();
				d1.enabled = false;
				var d2 = del2.GetComponent<BoxCollider2D> ();
				d2.enabled = false;
				var d3 = del3.GetComponent<BoxCollider2D> ();
				d3.enabled = false;
				okvir.active = false;
						}
				}

		if (gameObject.name == "profile selection 3") {
						var name3 = GameObject.Find ("profilename3");
						var text3 = name3.GetComponent<TextMesh> ();
						if (text3.text == PlayerPrefs.GetString ("player 3")) {
						var manager=GameObject.Find("profileManager");
						var manager2=manager.GetComponent<ProfileManager>();
						manager2.profile3=true;
						PlayerPrefs.GetInt("player_3_progress");
						Application.DontDestroyOnLoad(manager);
								Application.LoadLevel ("menu");
						} else {
								pro3 = true;
				var p1 = profil1.GetComponent<BoxCollider2D> ();
				p1.enabled = false;
				var p2 = profil2.GetComponent<BoxCollider2D> ();
				p2.enabled = false;

				var d1 = del1.GetComponent<BoxCollider2D> ();
				d1.enabled = false;
				var d2 = del2.GetComponent<BoxCollider2D> ();
				d2.enabled = false;
				var d3 = del3.GetComponent<BoxCollider2D> ();
				d3.enabled = false;
				okvir.active = false;}}

		if (gameObject.name == "del1") {
			delp1=true;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = false;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = false;

			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = false;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = false;
			okvir.active = false;}

		if (gameObject.name == "del2") {
			delp2=true;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = false;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = false;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = false;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = false;
			okvir.active = false;
		}
		if (gameObject.name == "del3") {
			delp3=true;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = false;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = false;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = false;
			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = false;

			okvir.active = false;}}
		
		private void OnMouseExit()
		{
			var prof1 = gameObject.GetComponent <SpriteRenderer> ();
			prof1.color = new Color (121,178,225,255);
		}

	private void OnGUI(){

		if (pro1 == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc, "Profile Name");}
		if (pro2 == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc2, "Profile Name");}
		if (pro3 == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc3, "Profile Name");}

		if (delp1 == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc4, "Delete Profile");}
		if (delp2 == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc5, "Delete Profile");}
		if (delp3 == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc6, "Delete Profile");}
		}

	private void windowFunc(int id)
	{

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Enter Player Name: ");
		guistring=GUILayout.TextField (guistring);
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button("Confirm")){
			var name1=GameObject.Find("profilename1");
			var text1=name1.GetComponent<TextMesh>();
			text1.text=guistring;
			PlayerPrefs.SetString("player 1",text1.text);
			PlayerPrefs.SetInt("player_1_progress",0);
			var manager=GameObject.Find("profileManager");
			var manager2=manager.GetComponent<ProfileManager>();
			manager2.profile1=true;
			Application.DontDestroyOnLoad(manager);
			pro1 =false;
			Application.LoadLevel("menu");

		}
		if(GUILayout.Button("Cancle")){
			var name1=GameObject.Find("profilename1");
			var text1=name1.GetComponent<TextMesh>();
			text1.text="Profile 1";
			pro1 =false;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = true;;
			okvir.active=true;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;
		}


		if(Input.GetKeyDown(KeyCode.Escape)==true){
			pro1 = false;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = true;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;
			okvir.active = true;
			
			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;
		}
		GUILayout.EndHorizontal ();}



	private void windowFunc2(int id)
	{
				GUILayout.BeginHorizontal ();
		
				GUILayout.Label ("Enter Player Name: ");
				guistring = GUILayout.TextField (guistring);
		
				GUILayout.EndHorizontal ();
		
				GUILayout.BeginHorizontal ();
				if (GUILayout.Button ("Confirm")) {
						var name2 = GameObject.Find ("profilename2");
						var text2 = name2.GetComponent<TextMesh> ();
						text2.text = guistring;
						PlayerPrefs.SetString ("player 2", text2.text);
						PlayerPrefs.SetInt ("player_2_progress", 0);
						var manager = GameObject.Find ("profileManager");
						var manager2 = manager.GetComponent<ProfileManager> ();
						manager2.profile2 = true;
						Application.DontDestroyOnLoad (manager);
						pro2 = false;
						Application.LoadLevel ("menu");
				}
				if (GUILayout.Button ("Cancle")) {
						var name2 = GameObject.Find ("profilename2");
						var text2 = name2.GetComponent<TextMesh> ();
						text2.text = "Profile 2";
						pro2 = false;
						var p3 = profil3.GetComponent<BoxCollider2D> ();
						p3.enabled = true;
						var p1 = profil1.GetComponent<BoxCollider2D> ();
						p1.enabled = true;
						okvir.active = true;
						GUILayout.EndHorizontal ();

						var d1 = del1.GetComponent<BoxCollider2D> ();
						d1.enabled = true;
						var d2 = del2.GetComponent<BoxCollider2D> ();
						d2.enabled = true;
						var d3 = del3.GetComponent<BoxCollider2D> ();
						d3.enabled = true;
							}

						if(Input.GetKeyDown(KeyCode.Escape)==true){
							pro2 = false;
							var p3 = profil3.GetComponent<BoxCollider2D> ();
							p3.enabled = true;
							var p1 = profil1.GetComponent<BoxCollider2D> ();
							p1.enabled = true;
							okvir.active = true;
							
							var d1 = del1.GetComponent<BoxCollider2D> ();
							d1.enabled = true;
							var d2 = del2.GetComponent<BoxCollider2D> ();
							d2.enabled = true;
							var d3 = del3.GetComponent<BoxCollider2D> ();
							d3.enabled = true;
						}
		GUILayout.EndHorizontal ();
						}

private void windowFunc3(int id)
	{
		GUILayout.BeginHorizontal ();
		
		GUILayout.Label ("Enter Player Name: ");
		guistring=GUILayout.TextField (guistring);
		
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button("Confirm")){
			var name3=GameObject.Find("profilename3");
			var text3=name3.GetComponent<TextMesh>();
			text3.text=guistring;
			PlayerPrefs.SetString("player 3",text3.text);
			PlayerPrefs.SetInt("player_3_progress",0);
			var manager=GameObject.Find("profileManager");
			var manager2=manager.GetComponent<ProfileManager>();
			manager2.profile3=true;
			Application.DontDestroyOnLoad(manager);
			pro3 =false;

			Application.LoadLevel("menu");
		}
		if(GUILayout.Button("Cancle")){
			var name3=GameObject.Find("profilename3");
			var text3=name3.GetComponent<TextMesh>();
			text3.text="Profile 3";

			pro3 =false;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = true;;
			okvir.active=true;


			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;
		}
		GUILayout.EndHorizontal ();
		if(Input.GetKeyDown(KeyCode.Escape)==true){
			pro3 =false;

			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = true;

			okvir.active=true;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;

		}
}
		
	private void windowFunc4(int id)
	{
		var p1 = profil1.GetComponent<BoxCollider2D> ();
		p1.enabled = false;
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Are you sure you wnat to delete this profile?");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button ("Yes")) {
			PlayerPrefs.DeleteKey("player 1");
			PlayerPrefs.DeleteKey("player_1_progress");
			PlayerPrefs.DeleteKey ("CurrentLevelPlayer1");
			PlayerPrefs.DeleteKey ("Current Life1");
			delp1=false;
			okvir.active = true;
			var name1=GameObject.Find("profilename1");
			var text1=name1.GetComponent<TextMesh>();
			text1.text="Profile 1";
			del1.active=false;
			p1.enabled = true;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = true;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;

			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;


		}
		if (GUILayout.Button ("No")) {

			delp1=false;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = true;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;
			okvir.active = true;
			p1.enabled = true;

			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;

		}
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace ();
		}
	private void windowFunc5(int id)
	{

		var p2 = profil2.GetComponent<BoxCollider2D> ();
		p2.enabled = false;
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Are you sure you wnat to delete this profile?");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button ("Yes")) {
			PlayerPrefs.DeleteKey("player 2");
			PlayerPrefs.DeleteKey("player_2_progress");
			PlayerPrefs.DeleteKey ("CurrentLevelPlayer2");
			PlayerPrefs.DeleteKey ("Current Life2");
			delp2=false;
			okvir.active = true;
			var name2=GameObject.Find("profilename2");
			var text2=name2.GetComponent<TextMesh>();
			text2.text="Profile 2";
			del2.active=false;
			p2.enabled = true;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = true;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = true;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;
		}
		if (GUILayout.Button ("No")) {

			delp2=false;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = true;
			var p3 = profil3.GetComponent<BoxCollider2D> ();
			p3.enabled = true;;
			okvir.active = true;
			p2.enabled = true;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d3 = del3.GetComponent<BoxCollider2D> ();
			d3.enabled = true;

		}
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace ();
		
	}
	private void windowFunc6(int id)
	{
		var p3 = profil3.GetComponent<BoxCollider2D> ();
		p3.enabled = false;
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Are you sure you wnat to delete this profile?");
		GUILayout.BeginHorizontal();
		if (GUILayout.Button ("Yes")) {
			PlayerPrefs.DeleteKey("player 3");
			PlayerPrefs.DeleteKey("player_3_progress");
			PlayerPrefs.DeleteKey ("CurrentLevelPlayer3");
			PlayerPrefs.DeleteKey ("Current Life3");
			delp3=false;
			okvir.active = true;
			var name3=GameObject.Find("profilename3");
			var text3=name3.GetComponent<TextMesh>();
			text3.text="Profile 3";
			del3.active=false;
			p3.enabled = true;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = true;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
		
		}
		if (GUILayout.Button ("No")) {
			delp3=false;
			okvir.active = true;
			p3.enabled = true;
			var p1 = profil1.GetComponent<BoxCollider2D> ();
			p1.enabled = true;
			var p2 = profil2.GetComponent<BoxCollider2D> ();
			p2.enabled = true;

			var d1 = del1.GetComponent<BoxCollider2D> ();
			d1.enabled = true;
			var d2 = del2.GetComponent<BoxCollider2D> ();
			d2.enabled = true;
		

		}
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace ();
		
	}
}