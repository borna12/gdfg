using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	
	public bool _isFacingRight;
	public CharacterController2D _controller;
	private float _normalizedHorizontalSpeed;

	public float MaxSpeed=8;
	public float SpeedAccelerationOnGround =10f;
	public float SpeedAccelerationInAir=5f;
	public int MaxHealth=100;
	public GameObject OuchEffect;
	public GameObject HealthBody;
	public GameObject DeathFace;
	public GameObject CurrentWeapon;
	public GameObject Weapon1;
	public GameObject Weapon2;
	public GameObject Weapon3;
	public ParticleSystem HealthBarParticle;
	public TextMesh LifeText;
    public AudioClip PlayerHitsound;
    public AudioClip PlayerHealthsound;
    public Animator Animator;


	public int Health { get; private set;}
	public bool IsDead { get; private set;}

	

	private Rect windowRect;
	private bool editing = false;

	public void Awake(){
		PlayerPrefs.SetString("IsDeath","no");
        _controller = GetComponent<CharacterController2D>();
		_isFacingRight = transform.localScale.x > 0;
		Health = MaxHealth;


	}
	public void Update(){
		Debug.Log (LifeText.text);
		if (!IsDead) {
						HandleInput ();
		}
		var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;

		if (IsDead) {
						_controller.SetHorizontalForce (0);
			CurrentWeapon.SetActive(false);
	
				} else {
						_controller.SetHorizontalForce (Mathf.Lerp (_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, Time.deltaTime * movementFactor));
				
		}
        Animator.SetBool("IsGrounded",_controller.State.IsGrounded);
        Animator.SetBool("IsDead",IsDead);
        Animator.SetFloat("Speed",Mathf.Abs(_controller.Velocity.x)/MaxSpeed);

    }

    public void FinishLevel()
    {
        enabled = false;
        _controller.enabled = false;
        collider2D.enabled = false;
		Animator.SetTrigger("win");
    }

    public void Kill()
	{
		_controller.HandleCollisions = false;
		collider2D.enabled = false;
		IsDead = true;
		Health = 0;
		int lifes = Convert.ToInt32(LifeText.text);
		lifes = lifes - 1;
		LifeText.text = lifes.ToString ();
		if (lifes == 0) {
			HealthBarParticle.Play();
			windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 80);
			editing=true;
			PlayerPrefs.SetString("IsDeath","yes");
			Screen.showCursor = true;
			Destroy(HealthBody);
			DeathFace.SetActive(true);

		}
		_controller.SetForce (new Vector2 (0, 20));
		}
	public void RespawnAt(Transform spawnPoint)
	{
		CurrentWeapon.SetActive (true);
		if (editing == true) 
			return;
		if (!_isFacingRight)
						Flip ();
		IsDead = false;
		collider2D.enabled = true;
		_controller.HandleCollisions = true;
		Health = MaxHealth;

		transform.position = spawnPoint.position;

		}
	public void TakeDamage(int damage, GameObject instigator)
	{
        AudioSource.PlayClipAtPoint(PlayerHitsound, transform.position);
		FloatingText.Show (string.Format ("-{0}", damage), "PlayerTakeDamageText", new FromWorldPointTextPositioner (Camera.main, transform.position, 2f, 60f));
		Instantiate (OuchEffect, transform.position, transform.rotation);
		Health -= damage;

		if (Health <= 0)
						LevelManager.Instance.KillPlayer ();
		}

    public void giveHealth(int health, GameObject instagator)
    {
        AudioSource.PlayClipAtPoint(PlayerHealthsound,transform.position);
        FloatingText.Show(string.Format("+{0}", health), "PlayerGotHealthText",
            new FromWorldPointTextPositioner(Camera.main, transform.position, 2f, 60f));

        Health = Mathf.Min(Health +health,MaxHealth);
    }

    private void HandleInput()
	{
		if (Input.GetKey (KeyCode.D)) {
						_normalizedHorizontalSpeed = 1;
						if (!_isFacingRight)
								Flip ();} 
		else if (Input.GetKey (KeyCode.A)) {
						_normalizedHorizontalSpeed = -1;
						if (_isFacingRight)
								Flip ();} 
		else {
			_normalizedHorizontalSpeed=0;	
		}

		if (_controller.CanJump && Input.GetKeyDown (KeyCode.Space)) {
			_controller.Jump();		
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			
						CurrentWeapon = Weapon1;
						Weapon1.SetActive (true);

				}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			CurrentWeapon=Weapon2;
			Weapon2.SetActive(true);
	
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			CurrentWeapon=Weapon3;
			Weapon3.SetActive(true);

		}

		}




	private void Flip(){
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		_isFacingRight = transform.localScale.x > 0;
	}
    
	private void windowFunc(int id){
		CurrentWeapon.SetActive (false);

		GUILayout.FlexibleSpace ();
		if (GUILayout.Button ("Retry")) {
			Application.LoadLevel(Application.loadedLevelName);
			GameManager.Instance.ResetPoints(0);}

		if (GUILayout.Button ("Back to Main Menu")) {
			var glazba = GameObject.Find("main_music");
			AudioClip clip = Resources.Load("wicked") as AudioClip;
			DontDestroyOnLoad(glazba);
			glazba.audio.clip = clip;
			glazba.audio.Play();
			Application.LoadLevel("menu");
			GameManager.Instance.ResetPoints(0);
				}
		GUILayout.FlexibleSpace ();
	}

	private void OnGUI(){
		if (editing == true) {
			windowRect = GUI.Window (0, windowRect, windowFunc,"Game Over Man! Game Over!");
		}}

}







			
