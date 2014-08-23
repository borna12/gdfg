using UnityEngine;


public class FollowObject : MonoBehaviour {

	public Vector2 offset;
	public Transform following;

	public void Update()
	{
		transform.position = following.transform.position + (Vector3)offset;
	}

}
