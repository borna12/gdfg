using UnityEngine;
using System.Collections;

public class AmmoPickUp1 : MonoBehaviour, IPlayerRespawnListener 
{

	public GameObject Weapon;
	public int IncreaseAmmo;
	public GameObject Player;
	public ParticleSystem DestroyEffect;
	public AudioClip PickUpSound;
	private bool _isCollected;
	
	
	public void OnPlayerRespawnInThicCheckpoint(Checkpoint Checkpoint, Player player)
	{
		gameObject.SetActive(true);
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == Player.name) {
			Weapon.GetComponent<WeaponPickUp> ().ammo += IncreaseAmmo;
			Instantiate (DestroyEffect, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint (PickUpSound, transform.position);
			gameObject.SetActive (false);
			FloatingText.Show(string.Format("Pistol ammo +{0}!", IncreaseAmmo), "AmmoPickUp",
			                  new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));
		}
		
	}

}
