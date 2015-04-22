using UnityEngine;
using System.Collections;

public class triggerDoubleDoors : MonoBehaviour {
	public GameObject door;
	public bool opened;
	public bool closed; 
	public bool shake; 
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other){
		opened = false;
		closed = false;
		shake = false;
		if (gameObject.name == "DoorDoubleOpen" && other.collider.name == "OVRPlayerController") {
			door.animation.Play ("Take 0010");
			print ("doubledoor should open");
			opened = true;
		}
		if (gameObject.name == "DoorDoubleShake" && other.collider.name == "OVRPlayerController") {
			door.animation.Play ("Take 001");
			shake = true;
		}

	}

	void OnTriggerExit (Collider other){
		if (gameObject.name == "DoorDoubleOpen" && other.collider.name == "OVRPlayerController") {
			door.animation.Play("Take 0011");
			closed = true;
		}
	}

}
