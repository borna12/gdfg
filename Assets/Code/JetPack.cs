using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

public class JetPack : MonoBehaviour,  IPlayerRespawnListener
{

    private bool _isFacingRight;
    public ParticleSystem Effect;
    public Animator Animator;
    public GameObject player;
    public ParticleSystem Destroyeffect;
    public int secondsToDestroy;
    private bool destroyed = false;
    private int took_time;
    private int timecount;
	private int PlayerJumpMagnitude;
	public int JumpMagnitude;
	public TextMesh TimeLeftShow;
	private Vector2 respawnJetpack;

	void Awake(){
		respawnJetpack = transform.position;
	}
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "igrac") {

						gameObject.transform.parent = player.transform;
						gameObject.transform.position = player.transform.position - new Vector3 (1, 0, 0);
						var play = player.GetComponent<CharacterController2D> ();
						play.DefaultParameters.JumpRestrictions = ControllerParameters2D.JumpBehavior.CanJumpAnywhere;
						play.DefaultParameters.JumpMagnitude = JumpMagnitude;

						took_time = (int)Time.time;
   
						if (player.transform.localScale.x < 0) {
								Flip ();
								gameObject.transform.position = player.transform.position - new Vector3 (-1, 0, 0);
						}



				} 
		if(other.name=="jetpack_fuel"){
			other.gameObject.SetActive(false);
			secondsToDestroy+=5;
		
		}


	
    }



    // Use this for initialization
    private void Start()
    {
        _isFacingRight = transform.localScale.x > 0;
        
        Effect.Stop();
        Destroyeffect.Stop();
		var play = player.GetComponent<CharacterController2D>();
		PlayerJumpMagnitude = Convert.ToInt32(play.DefaultParameters.JumpMagnitude);
    }

    // Update is called once per frame
    private void Update()
    {

        int time = (int) Time.time;
        


        if (gameObject.transform.parent == player.transform)
        {
          

             timecount = 0;
             timecount+=(int) Time.time - took_time;
			TimeLeftShow.text=(secondsToDestroy-timecount).ToString();
			if(Convert.ToInt32(TimeLeftShow.text)<3)
			{TimeLeftShow.renderer.material.color=Color.red;}
			if(Convert.ToInt32(TimeLeftShow.text)>3)
			{TimeLeftShow.renderer.material.color=Color.white;}
            if ((int) timecount > secondsToDestroy)
            {
                destroyed = true;

            }
			if (Input.GetKeyDown(KeyCode.Space) == true)
			{
				Effect.Play();
				audio.Play();
				Effect.renderer.enabled=true;
			}
			if (Input.GetKeyUp(KeyCode.Space) == true){
				Effect.Stop();
			}

		}	



        if (destroyed == true)
        {
			gameObject.transform.parent = null;
			gameObject.SetActive(false);
			Instantiate(Destroyeffect, transform.position, transform.rotation);

            var play = player.GetComponent<CharacterController2D>();
            play.DefaultParameters.JumpRestrictions = ControllerParameters2D.JumpBehavior.CanJumpOnGround;
			play.DefaultParameters.JumpMagnitude = PlayerJumpMagnitude;

			Effect.Stop();
			destroyed=false;
        }

		if (player.GetComponent<Player> ().IsDead == true) {
			if(gameObject.transform.parent == player.transform){
				destroyed=true;

			}
			else {return;}
				}


    }
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight=transform.localScale.x > 0;
    }

	public void OnPlayerRespawnInThicCheckpoint(Checkpoint Checkpoint, Player player)
	{
		gameObject.SetActive(true);
		Effect.Stop();
		Effect.Clear();
		transform.position = respawnJetpack;
		if (transform.localScale.x < 0) {
						Flip ();
				}
		TimeLeftShow.text="";
		TimeLeftShow.renderer.material.color = Color.white;
		secondsToDestroy = 5;
	}
        
    }