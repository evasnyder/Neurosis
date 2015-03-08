﻿using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {

	public bool hasScares; //if the object has scares to trigger
	public GameObject scares; //assign scares
	Scares scareToPerform; //scares to activate
	public GameObject hallBrick;
	public bool inTheHall = false;

	// Use this for initialization
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
		print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		//if the object that was collided with was the desk and what collided with it 
	 if (gameObject.name == "RespawnPoint" && info.collider.name == "OVRPlayerController") { 
			print ("player should respawn");
			StartCoroutine (respawn (info)); 
			//Destroy (gameObject);
		}
		if(gameObject.name == "hallBrick" && info.collider.name == "OVRPlayerController"){ 
			inTheHall = true;
			Debug.Log ("halling around");
		   }
		if (gameObject.name == "DoorDoubleScare" && info.collider.name == "OVRPlayerController") { 
			if (hasScares) {
				scareToPerform.ScareMe(info.transform.position, info.transform.rotation);
			}
		}
	}

	void OnTriggerStay(Collider player){
		if (gameObject.name == "RadiatorScare" && player.collider.name == "OVRPlayerController") {
			if (hasScares) {
			print ("girls appears");
			//call Appear from JUMPSCARES.CS to make the scary object appear 
			scareToPerform.Appear();
			}
		}
	}

	void OnTriggerExit(Collider player){
		if (gameObject.name == "RadiatorScare" && player.collider.name == "OVRPlayerController") {
			if (hasScares) {
				print ("girls disappears");
				//scareToPerform.ScareMe(player.transform.position);
				scareToPerform.Dissapear ();
			}
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
