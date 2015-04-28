using UnityEngine;
using System.Collections;

public class DoorLock : MonoBehaviour {

	public GameObject door;
	public GameObject doorLock;
	public GameObject audio;
	NeurosisAudioManager audioManager;
	private bool fogOn;
	private int counter = 0;
	private bool isColliding;
	
	public bool doorHit = false; //used for playaudio.cs
	public bool doorSlammed = false; //also used for audi
	public PaperPickUp cassette;

	public GameObject cameraCol;
	CameraCollide cameraCollide;

	public GameObject pickUp;
	PaperPickUp paperPickUp;

	
	// Use this for initialization
	void Start () {
		audioManager = audio.GetComponent<NeurosisAudioManager> ();
		cameraCollide = cameraCol.GetComponent<CameraCollide>();
		paperPickUp = pickUp.GetComponent<PaperPickUp> ();
		fogOn = false;
		//cassette = (PaperPickUp)GameObject.Find("Room 0 Cassette").GetComponent("PaperPickUp");
		//cassetteplayer = (PaperPickUp)GameObject.Find ("cassetteplayer_model").GetComponent("PaperPickUp");
		doorLock.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (fogOn) {
			// Enable fog
			RenderSettings.fog = true;
		}
		Lock ();
	}
	
	IEnumerator OnTriggerEnter (Collider other){
		if((other.collider.name == "OVRPlayerController")){
			audioManager.Play (1);
			doorHit = true;
			print ("open door");
			door.animation ["Take 001"].speed = 1;
			door.animation.Play ("Take 001");
			fogOn = true;
			
			yield return new WaitForSeconds(5);
			
			/*print ("close door");
			door.animation ["Take 001"].speed = -1;    
			door.animation.Play ("Take 001");
			doorSlammed = true;*/
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

	void Lock(){
		if (cameraCollide.inRoomOne) {
			Debug.Log ("IN ROOM ONE IS NOW TRUE");
		}
		if (paperPickUp.pickedUp) {
			Debug.Log ("PICKED UP I SNOW TURE");
		}
		if (cameraCollide.inRoomOne && paperPickUp.pickedUp) {
			doorLock.SetActive (false);
			Debug.Log ("THE DOOR SHOULD BE UNLOCKED NOW");
		} else if(cameraCollide.inRoomOne) {
			Debug.Log ("lock is locked");
			doorLock.SetActive (true);
		}
	}
}
