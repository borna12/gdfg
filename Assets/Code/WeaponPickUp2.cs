using UnityEngine;
using System.Collections;
using System;

public class WeaponPickUp2 : MonoBehaviour {
	public GameObject player;
	public AudioClip weaponSound;
	public GameObject FireProjectileEffect;
	public float x_position_of_weapon;
	public float y_position_of_weapon;
	public GameObject Player_hand;
	public GameObject AmmoCountGUI;
	public GameObject AmmoSymbolForGUI;
	public Projectile Projectile;
	public float FireRate;
	public Transform SpawnShoot;
	public bool _isFacingRight;
	private float _canFireIn;
	private float _normalizedHorizontalSpeed;
	private bool collided;
	public bool canShoot=false;
	public int ammo;
	
	void Awake(){
				var profileManager = GameObject.Find ("profileManager");
				var profile = profileManager.GetComponent<ProfileManager> ();
		
				_isFacingRight = transform.localScale.x > 0;
		

				if (profile.profile1 == true)
						ammo = PlayerPrefs.GetInt ("rifle count1");
		
				if (profile.profile2 == true)
						ammo = PlayerPrefs.GetInt ("rifle count2");
		
				if (profile.profile3 == true)
						ammo = PlayerPrefs.GetInt ("rifle count3");
		
				if (Application.loadedLevelName == "level3") {
						collided = true;
				}
		}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		_canFireIn -= Time.deltaTime;
		
		if (collided == true) {
			player.GetComponent<Player>().CurrentWeapon=gameObject;
			gameObject.transform.parent = Player_hand.transform;
			gameObject.transform.position = Player_hand.transform.position;
			gameObject.transform.rotation = (Player_hand.transform.rotation);
			player.GetComponent<Player>().CurrentWeapon=gameObject;

			if(player.GetComponent<Player>().CurrentWeapon==gameObject){player.GetComponent<Player>().Weapon2.SetActive(false);
			player.GetComponent<Player>().Weapon2.GetComponent<WeaponPickUp>().AmmoSymbolForGUI.SetActive(false);
			}
		
			
			if (Input.GetMouseButton (0)) {
				WeaponFire();
			}
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				if(player.GetComponent<Player>().CurrentWeapon==gameObject)
					gameObject.SetActive(false);
				player.GetComponent<Player>().CurrentWeapon=player.GetComponent<Player>().Weapon1;
				AmmoCountGUI.GetComponent<TextMesh> ().text ="";
			}
			
			
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				if(player.GetComponent<Player>().CurrentWeapon==gameObject)
					gameObject.SetActive(false);
				player.GetComponent<Player>().CurrentWeapon=player.GetComponent<Player>().Weapon2;
				player.GetComponent<Player>().Weapon2.SetActive(true);

			}
			if (player.GetComponent<Player> ().CurrentWeapon == gameObject) {
				AmmoSymbolForGUI.SetActive (true);
				AmmoCountGUI.GetComponent<TextMesh> ().text ="x" + ammo.ToString ();
			}else {
				AmmoSymbolForGUI.SetActive (false);
				gameObject.SetActive(false);
			}
			if (player.GetComponent<Player> ().CurrentWeapon == gameObject) {
				AmmoSymbolForGUI.SetActive (true);
				AmmoCountGUI.GetComponent<TextMesh> ().text ="x" + ammo.ToString ();
			}else {
				AmmoSymbolForGUI.SetActive (false);
				gameObject.SetActive(false);
			}
			
		} 

		else {
			AmmoSymbolForGUI.SetActive (false);

		}

		if (ammo == 0) {
			canShoot = false;
		} else {
			canShoot = true;
		}
		
		
		
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.name == player.name) {
			if (player.transform.localScale.x < 0) {
				Flip ();
				gameObject.transform.position = player.transform.position - new Vector3 (x_position_of_weapon, y_position_of_weapon + 0.3f);
			} 
			player.GetComponent<Player>().Weapon2.SetActive(false);
			player.GetComponent<Player>().Weapon2.GetComponent<WeaponPickUp>().AmmoSymbolForGUI.SetActive(false);

			collided = true;
			canShoot = true;

		}	
				
		else {return;
		}
	}
	
	private void Flip()
	{
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		_isFacingRight = transform.localScale.x > 0;
	}
	private void WeaponFire()
	{
		if (canShoot == false)
			return;
		if (_canFireIn > 0)
			return;
		if (FireProjectileEffect != null) {
			var effect=(GameObject)Instantiate (FireProjectileEffect, SpawnShoot.position, SpawnShoot.rotation);
			effect.transform.parent=transform;
		}
		
		var projectile = (Projectile)Instantiate (Projectile, SpawnShoot.position, SpawnShoot.rotation);
		var play = player.GetComponent<Player> ();
		var direction = play._isFacingRight ? Vector2.right : -Vector2.right;
		projectile.Initialize (gameObject, direction,play._controller.Velocity);
		_canFireIn = FireRate;
		
		player.GetComponent<Animator>().SetTrigger("fire");
		AudioSource.PlayClipAtPoint(weaponSound,transform.position);
		ammo -= 1;
	}
	
	

}
