using UnityEngine;
using System.Collections;

public class SortParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.renderer.sortingLayerName = "Particles";
		particleSystem.renderer.sortingOrder = 10;
	}
}
