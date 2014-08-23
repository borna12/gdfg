using UnityEngine;
using System.Collections;

public class SortParticalsystem : MonoBehaviour {


	public void Start()
	{
	}

	void Update () {
		particleSystem.renderer.sortingLayerName = "igrac i protivnik";
		particleSystem.renderer.sortingOrder = 10;
	}
}
