using UnityEngine;
using System.Collections;

public class KnifFight : MonoBehaviour
{
    public GameObject player;
    public AudioClip knifesond;

    private bool _isFacingRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.name == "igrac")
        {
            var ruka = GameObject.Find("projektil");
            gameObject.transform.parent = ruka.transform;
            gameObject.transform.position = ruka.transform.position - new Vector3(-0.21f, -0.38f, 0);


            if (player.transform.localScale.x < 0)
            {
                Flip();
                gameObject.transform.position = player.transform.position - new Vector3(0.21f, 0.38f, 0);
            }
        }
    }


    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }
}
