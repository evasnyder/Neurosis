﻿using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {

	public bool hasScares; //if the object has scares to trigger
	public GameObject scares; //assign scares
	Scares scareToPerform; //scares to activate
	public GameObject hallBrick;
	public bool inTheHall = false;

	// Use this for initialization

	public bool inHall = false;

	void Start () {
		if (hasScares) {
			//initiallizing jumpScares to be of type SCARES.CS 
			scareToPerform = scares.GetComponent<Scares> ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info)
	{
		//print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		//if the object that was collided with was the desk and what collided with it 
		/*if (gameObject.name == "Radiator" && info.collider.name == "OVRPlayerController") {
			//call Appear from JUMPSCARES.CS to make the scary object appear 
			scareToPerform.Appear (info.transform.position);

		} else*/ if (gameObject.name == "RespawnPoint" && info.collider.name == "OVRPlayerController") { 
			print ("player should respawn");
			StartCoroutine (respawn (info)); 
			//Destroy (gameObject);
		}
<<<<<<< HEAD

		if (gameObject.name == "HallTrigger" && info.collider.name == "OVRPlayerController") {
			inHall = true;
			Debug.Log ("WEEEE");
		}
		/*	//KEEP THIS.  HANNAH IS WORKING ON GETTING THE KNOCKING WORKING WHEN YOU HIT FRAME02 (aka fred.)
		if (gameObject.name == "Frame02" && info.collider.name == "OVRPlayerController") 
			
			Invoke ("Knocking", 1.0f);
		}
=======
		if(gameObject.name == "hallBrick" && info.collider.name == "OVRPlayerController"){ 
			inTheHall = true;
			Debug.Log ("halling around");
		   }
>>>>>>> master
	}

	void OnTriggerStay(Collider player){
		if (gameObject.name == "Radiator" && player.collider.name == "OVRPlayerController") {
			if (hasScares) {
			//call Appear from JUMPSCARES.CS to make the scary object appear 
			scareToPerform.Appear();
			}
		}
	}

	void OnTriggerExit(Collider player){
		if (hasScares) {
			scareToPerform.ScareMe(player.transform.position);
		}
	}

	/*Called to respawn the player back in the first room*/
	IEnumerator respawn(Collider toRespawn){
		renderer.enabled = false;
		yield return new WaitForSeconds(2.0f);
		toRespawn.transform.position = new Vector3(0.04833326f, 3.980667f, 0.0f);
		toRespawn.transform.rotation = Quaternion.identity;
		renderer.enabled = true;
	}
}
