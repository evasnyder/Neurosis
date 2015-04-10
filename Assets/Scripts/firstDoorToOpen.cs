using UnityEngine;
using System.Collections;

public class firstDoorToOpen : MonoBehaviour {

	public GameObject door;
	public GameObject audio;
	NeurosisAudioManager audioManager;
	private bool fogOn;
	private int counter = 0;
	private bool isColliding;

	public bool doorHit = false; //used for playaudio.cs
	public bool doorSlammed = false; //also used for audio
	public PaperPickUp cassette;
	public PaperPickUp cassetteplayer;
	
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
		if((other.collider.name == "OVRPlayerController")&(cassette.pickedUp)&(cassetteplayer.pickedUp)){
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
}
