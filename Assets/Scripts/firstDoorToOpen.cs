﻿using UnityEngine;
using System.Collections;

public class firstDoorToOpen : MonoBehaviour {

	public GameObject door;
	public GameObject doorLock;
	public GameObject audio;
	NeurosisAudioManager audioManager;
	private bool fogOn;
	private int counter = 0;
	private bool isColliding;

	public bool doorHit = false; //used for playaudio.cs
	public bool doorSlammed = false; //also used for audio
	public PaperPickUp cassette;
	public PaperPickUp cassetteplayer;

	public bool doorLocked = true;
	public bool doorUnlocked = false;
	
	// Use this for initialization
	void Start () {
		audioManager = audio.GetComponent<NeurosisAudioManager> ();
		fogOn = false;
		//cassette = (PaperPickUp)GameObject.Find("Room 0 Cassette").GetComponent("PaperPickUp");
		//cassetteplayer = (PaperPickUp)GameObject.Find ("cassetteplayer_model").GetComponent("PaperPickUp");
	}
	
	// Update is called once per frame
	void Update () {
		if (fogOn) {
			// Enable fog
			RenderSettings.fog = true;
		}
	}
	
	IEnumerator OnTriggerEnter (Collider other){
		if ((other.collider.name == "OVRPlayerController") & doorUnlocked) {
			audioManager.Play (1);
			doorHit = true;
			doorLock.SetActive (false);
			print ("open door");
			door.animation ["Take 001"].speed = 1;
			door.animation.Play ("Take 001");
			fogOn = true;
			
			yield return new WaitForSeconds (5);
			
			/*print ("close door");
			door.animation ["Take 001"].speed = -1;    
			door.animation.Play ("Take 001");
			doorSlammed = true;*/
		} else if( other.collider.name == "OVRPlayerController"){
			doorLocked = false;
		}
		
	}

	void OnTriggerExit (Collider other){
		if (other.collider.name == "OVRPlayerController") {
			print ("close door");
			door.animation ["Take 001"].speed = -1;    
			door.animation.Play ("Take 001");
			doorSlammed = true;
		}
	}

	void DoorSlam(){
		audioManager.Play (18);
		Debug.Log ("slam");
	}
}
