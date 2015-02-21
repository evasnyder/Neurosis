﻿using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {
	public GameObject scares;
	Scares jumpScares; 
	// Use this for initialization
	void Start () {
		Debug.Log ("start");

		jumpScares = scares.GetComponent<Scares> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info)
	{
		print("Detected collision between " + gameObject.name + " and " + info.collider.name);

		if (gameObject.name == "Desk" && info.collider.name == "OVRPlayerController") {
			Debug.Log("boo");
			jumpScares.Appear();
		}
	}
}
