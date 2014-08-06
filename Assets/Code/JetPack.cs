using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class JetPack : MonoBehaviour
{


    public GameObject Effect;
    public AudioClip jetpacMotors;
    public Animator Animator;


    public void OnTriggerEnter2D(Collider2D other)
    {

     
        if (other.gameObject.name == "igrac")
        {
            
            gameObject.transform.parent = other.transform;
            gameObject.transform.position = other.transform.position - new Vector3(1, 0, 0);

        }
        /*
       var player = other.GetComponent<CharacterController2D>();
        player.DefaultParameters.JumpRestrictions = ControllerParameters2D.JumpBehavior.CanJumpAnywhere;

        Debug.Log(Time.deltaTime > 5);
        if(Time.deltaTime>5)
        player.DefaultParameters.JumpRestrictions = ControllerParameters2D.JumpBehavior.CanJumpOnGround;
        */
    }








    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

        

	}
}
