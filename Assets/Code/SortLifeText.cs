using UnityEngine;
using System.Collections;

public class SortLifeText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.sortingLayerName="igrac i protivnik";
		gameObject.renderer.sortingOrder =10;
	}
}
