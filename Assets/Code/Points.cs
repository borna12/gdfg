using UnityEngine;
using System.Collections;
using System;
public class Points : MonoBehaviour {
	public TextMesh LifeText;
	int LifePoints;
	int LifePoints2;
	// Use this for initialization
	void Awake(){
	var profileManager=GameObject.Find("profileManager");
	var profileMana=profileManager.GetComponent<ProfileManager>();
		if (profileMana.profile1 == true) {
						LifeText.text = PlayerPrefs.GetString ("Current Life1");}
		if (profileMana.profile2 == true) {
			LifeText.text = PlayerPrefs.GetString ("Current Life2");}
		if (profileMana.profile3 == true) {
			LifeText.text = PlayerPrefs.GetString ("Current Life3");}}
	void Start () {	
		LifePoints = 0;
		LifePoints2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		LifePoints = GameManager.Instance.Points-LifePoints2; 
        TextMesh point = (TextMesh)GetComponent(typeof(TextMesh));
		point.text = string.Format("Points:{0}",GameManager.Instance.Points);

		if (LifePoints>=100) {
			int lifes = Convert.ToInt32(LifeText.text);
			lifes = lifes + 1;
			LifeText.text = lifes.ToString ();
			LifePoints2+=100;
			LifePoints-=100;
			FloatingText.Show(string.Format("Life Up"), "CheckpointText",
			                  new FromWorldPointTextPositioner(Camera.main, GameObject.Find("igrac").transform.position, 1.5f, 50));
				}
		if (GameManager.Instance.Points == 0) {
			LifePoints2=0;
			LifePoints=0;	
		}
	}
	


}
