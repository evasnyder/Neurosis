﻿using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {

	/*	gameObject scares is the little girl that appears behind the desk when hit 
	*	for example, this script could also be attatched to the door and something else could 
	*	appear at the door when you hit it.
	**/
	public GameObject scares;

	/* 
	 *  This is used for the audio.  This boolean is used in PLAYAUDIO.CS to play teh audio when 
	 * 	this is set equal to true. i.e something hit the object and the scare appeared.
	 * */ 
	public bool deskScareHappens = false;

	/* 
	 *	Object that is of type SCARES.CS which holds the code to make the little girl (or any scare) appear
	 *	when the target object was collided with.  
	 * */ 
	Scares jumpScares; 


	// Use this for initialization
	void Start () {

		//initiallizing jumpScares to be of type SCARES.CS 
		jumpScares = scares.GetComponent<Scares> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info)
	{
		print("Detected collision between " + gameObject.name + " and " + info.collider.name);

		//if the object that was collided with was the desk and what collided with it 
		//was the player 
		if ((gameObject.name == "Desk" && info.collider.name == "OVRPlayerController") || ( gameObject.name == "Radiator" && info.collider.name == "OVRPlayerController" )) {
			Debug.Log("boo");

			//call Appear from JUMPSCARES.CS to make the scary object appear 
			jumpScares.Appear();

			//set the boolean equal to true which is used to play the scary audio along 
			//with the girl appearing
			deskScareHappens = true;
		}

		//KEEP THIS.  HANNAH IS WORKING ON GETTING THE KNOCKING WORKING WHEN YOU HIT FRAME02 (aka fred.)
//		if (gameObject.name == "Frame02" && info.collider.name == "OVRPlayerController") {
//			Invoke("Knocking",1.0f);
//		}
	}
//
//	void Knocking(){
//		audio.Play ();
//	}
}
