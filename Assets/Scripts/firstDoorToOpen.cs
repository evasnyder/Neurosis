﻿using UnityEngine;
using System.Collections;

public class firstDoorToOpen : MonoBehaviour {

	public GameObject door;
	public GameObject audio;
	NeurosisAudioManager audioManager;
	private bool fogOn;
	private int counter = 0;

	public bool doorHit = false; //used for knocking.cs(audio)
	
	// Use this for initialization
	void Start () {
		audioManager = audio.GetComponent<NeurosisAudioManager> ();
		fogOn = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fogOn) {
			// Enable fog
			RenderSettings.fog = true;
		}
	}
	
	IEnumerator OnTriggerEnter (Collider other){
		audioManager.Play (1);
		Invoke ("DoorSlam", 2.0f);
		doorHit = true;
		print("open door");
		door.animation["Take 001"].speed = 1;
		door.animation.Play("Take 001");
		fogOn = true;
		yield return new WaitForSeconds(5);


		print("close door");
		door.animation["Take 001"].speed = -1;    
		door.animation.Play("Take 001");
	}

	void DoorSlam(){
		audioManager.Play (18);
		Debug.Log ("slam");
	}
}
