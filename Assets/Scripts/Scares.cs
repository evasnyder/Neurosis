using UnityEngine;
using System.Collections;

public class Scares : MonoBehaviour {

	public GameObject girl;


	// Use this for initialization
	void Start () {
		girl.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Appear(){
		girl.SetActive (true);
	
		Invoke ("Dissapear",.6f);
		
	}

	void Dissapear(){
		girl.SetActive (false);
	}
}
