using UnityEngine;
using System.Collections;

public class Scares : MonoBehaviour {

	//creating an instance of the little girl
	public GameObject girl;


	// Use this for initialization
	void Start () {
		//begin by setting the little girl equal to false so she cannot be seen in the room
		girl.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* 
	 *  Method is called when the desk is collided with by the camera 
	 * 	Makes the litlte girl appear 
	 * */ 
	public void Appear(){
		//	make the little girl appear 
		girl.SetActive (true);
	
		//invoke the Dissapear() method below after .6 seconds 
		Invoke ("Dissapear",.6f);
		
	}

	//	Makes the little girl dissapear 
	void Dissapear(){
		girl.SetActive (false);
	}
}
