using UnityEngine;
using System.Collections;

public class triggerDoubleDoors : MonoBehaviour {
	public GameObject door;
	public GameObject audio;
	NeurosisAudioManager audioManager;
	
	// Use this for initialization
	void Start () {
		audioManager = audio.GetComponent<NeurosisAudioManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other){
		if (gameObject.name == "DoorDoubleOpen" && other.collider.name == "OVRPlayerController") {
			audioManager.Play (2);//open double doors
			door.animation.Play ("Take 0010");
			print ("doubledoor should open");
		}
		if (gameObject.name == "DoorDoubleShake" && other.collider.name == "OVRPlayerController") {
			audioManager.Play (4);//play scratch
			door.animation.Play ("Take 001");
			print ("doubledoor should shake");
		}

	}

	void OnTriggerExit (Collider other){
		if (gameObject.name == "DoorDoubleOpen" && other.collider.name == "OVRPlayerController") {
			audioManager.Play (3);//close double door
			door.animation.Play("Take 0011");
		}
		if (gameObject.name == "DoorDoubleShake" && other.collider.name == "OVRPlayerController") {
			door.animation.Stop();
			print ("doubledoor should stop shaking");
		}
	}

}
