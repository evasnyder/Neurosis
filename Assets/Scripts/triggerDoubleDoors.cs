using UnityEngine;
using System.Collections;

public class triggerDoubleDoors : MonoBehaviour {
	public GameObject door;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other){
		if (gameObject.name == "DoorDoubleOpen" && other.collider.name == "OVRPlayerController") {
			door.animation.Play ("Take 0010");
			print ("doubledoor should open");
		}
		if (gameObject.name == "DoorDoubleShake" && other.collider.name == "OVRPlayerController") {
			door.animation.Play ("Take 001");
		}

	}

	void OnTriggerExit (Collider other){
		if (gameObject.name == "DoorDoubleOpen" && other.collider.name == "OVRPlayerController") {
			door.animation.Play("Take 0011");
		}
	}

}
