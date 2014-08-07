using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

public class JetPack : MonoBehaviour
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




    public void OnTriggerEnter2D(Collider2D player)
    {


        if (player.gameObject.name == "igrac")
        {
            gameObject.transform.parent = player.transform;
            gameObject.transform.position = player.transform.position - new Vector3(1, 0, 0);
            var play = player.GetComponent<CharacterController2D>();
            play.DefaultParameters.JumpRestrictions = ControllerParameters2D.JumpBehavior.CanJumpAnywhere;
            play.DefaultParameters.JumpMagnitude = 20;

            took_time = (int) Time.time;

            
            if (player.transform.localScale.x < 0)
            {
                Flip();
                gameObject.transform.position = player.transform.position - new Vector3(-1, 0, 0);
            }


           
        }


    }

    // Use this for initialization
    private void Start()
    {
        _isFacingRight = transform.localScale.x > 0;
        
        Effect.Stop();
        Destroyeffect.Stop();
    }

    // Update is called once per frame
    private void Update()
    {

        int time = (int) Time.time;
        
        if (gameObject.transform.parent == player.transform)
        {

            Effect.Stop();
            if (Input.GetKey(KeyCode.Space) == true)
            {
                
                Effect.Play();
                audio.Play();
  
            }

            int timecount = 0;
             timecount+=(int) Time.time - took_time;

            Debug.Log((int) timecount);
            if ((int) timecount > secondsToDestroy)
            {
                destroyed = true;
            }
        }


        if (destroyed == true)
        {
            var play = player.GetComponent<CharacterController2D>();
            play.DefaultParameters.JumpRestrictions = ControllerParameters2D.JumpBehavior.CanJumpOnGround;
            play.DefaultParameters.JumpMagnitude = 15;

            Instantiate(Destroyeffect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight=transform.localScale.x > 0;
    }


        
    }








    

