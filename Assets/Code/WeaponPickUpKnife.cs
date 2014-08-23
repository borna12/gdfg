using UnityEngine;
using System.Collections;

public class WeaponPickUpKnife : MonoBehaviour {

	public GameObject player;
	public AudioClip weaponSound;
	public GameObject FireProjectileEffect;
	public float x_position_of_weapon;
	public float y_position_of_weapon;
	public GameObject Player_hand;
	public GameObject AmmoSymbolForGUI;
	public float FireRate;
	public bool _isFacingRight;
	private float _canFireIn;
	private float _normalizedHorizontalSpeed;
	private bool collided;
	public bool canShoot=false;
	public int Damage;
	public int PointsToGiveToPlayer;
	
	void Awake(){
		var profileManager=GameObject.Find("profileManager");
		var profile = profileManager.GetComponent<ProfileManager> ();

		_isFacingRight = transform.localScale.x > 0;


		if (Application.loadedLevelName == "level2"||Application.loadedLevelName == "level3") {
			collided =true;
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



				_canFireIn -= Time.deltaTime;
		
				if (collided == true) {
						gameObject.transform.parent = Player_hand.transform;
						gameObject.transform.position = Player_hand.transform.position;
						gameObject.transform.rotation = (Player_hand.transform.rotation);

						if (Input.GetMouseButtonDown (0)) {
								WeaponFire ();
						}
		
			if (player.GetComponent<Player> ().CurrentWeapon == gameObject) {
				AmmoSymbolForGUI.SetActive (true);
			}else {
				AmmoSymbolForGUI.SetActive (false);
				gameObject.SetActive(false);
			}
		}else {
			AmmoSymbolForGUI.SetActive (false);
			
		}


		}

		
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (collided == true) {
						if (other.tag == "enemy") {
								GameManager.Instance.AddPoints (20);
								FloatingText.Show (string.Format ("+{0}!", 20), "PointStarText",
		new FromWorldPointTextPositioner (Camera.main, transform.position, 1.5f, 50));
								Instantiate (other.GetComponent<SimpleEnemyAi> ().DestroyedEffect, other.transform.position, other.transform.rotation);
								other.gameObject.SetActive (false);
						}
		}
		if (other.name == player.name) {
			if (player.transform.localScale.x < 0) {
				Flip ();
				gameObject.transform.position = player.transform.position - new Vector3 (x_position_of_weapon, y_position_of_weapon + 0.3f);
			} 
			player.GetComponent<Player>().CurrentWeapon=gameObject;
			collided = true;
			canShoot = true;
		} else {return;
		}

	}
	
	private void Flip()
	{
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		_isFacingRight = transform.localScale.x > 0;
	}
	private void WeaponFire()
	{


		

		var play = player.GetComponent<Player> ();
		var direction = play._isFacingRight ? Vector2.right : -Vector2.right;
		_canFireIn = FireRate;
		
		player.GetComponent<Animator>().SetTrigger("knife");
		AudioSource.PlayClipAtPoint(weaponSound,transform.position);
	}

}
