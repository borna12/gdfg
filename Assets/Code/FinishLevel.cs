using UnityEngine;
using System.Collections;
using System;

public class FinishLevel : MonoBehaviour
{
    public string LevelName;
	public GameObject Pistol;
	public GameObject Rifle;
	public int LevelComplited;
	public bool Finish;
	public TextMesh LifeText;
	void Awake(){

	}
	void Start(){

	}
	void Update(){
				if (Finish == true) {
						Pistol.GetComponent<WeaponPickUp> ().canShoot = false;
			Rifle.GetComponent<WeaponPickUp2>().canShoot=false;
				}
		}
    public void OnTriggerEnter2D(Collider2D other)
{
    if (other.GetComponent<Player>() == null)
        return;
	var profileManager=GameObject.Find("profileManager");
	var profileMana=profileManager.GetComponent<ProfileManager>();
	Finish = true;

	if (profileMana.profile1 == true) {
				PlayerPrefs.SetInt ("player_1_progress", LevelComplited);
				PlayerPrefs.SetString ("Current Life1", LifeText.text);
			PlayerPrefs.SetInt("ammo count1",Pistol.GetComponent<WeaponPickUp> ().ammo);
			PlayerPrefs.SetInt("rifle count1",Rifle.GetComponent<WeaponPickUp2> ().ammo);
			}

	if (profileMana.profile2 == true) {
				PlayerPrefs.SetInt ("player_2_progress", LevelComplited);
				PlayerPrefs.SetString ("Current Life2", LifeText.text);
			PlayerPrefs.SetInt("ammo count2",Pistol.GetComponent<WeaponPickUp> ().ammo);
			PlayerPrefs.SetInt("rifle count2",Rifle.GetComponent<WeaponPickUp2> ().ammo);
		}

	if (profileMana.profile3 == true) {
				PlayerPrefs.SetInt ("player_3_progress", LevelComplited);
				PlayerPrefs.SetString ("Current Life3", LifeText.text);
			PlayerPrefs.SetInt("ammo count3",Pistol.GetComponent<WeaponPickUp> ().ammo);
			PlayerPrefs.SetInt("rifle count3",Rifle.GetComponent<WeaponPickUp2> ().ammo);
		}

	LevelManager.Instance.GoToNextLevel(LevelName);
	PlayerPrefs.SetInt ("Points", GameManager.Instance.Points);
	

var music = GameObject.Find("main_music");
DontDestroyOnLoad(music);
DontDestroyOnLoad(profileManager);



			}		
}
