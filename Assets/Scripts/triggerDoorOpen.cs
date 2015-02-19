using UnityEngine;
using System.Collections;

public class triggerDoorOpen : MonoBehaviour {
	public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		Debug.Log ("collision is detected");
		if(other.gameObject.tag == "OVRPlayerController"){
			Debug.Log ("the door should open NOW");
			door.animation.Play("Take 001");
			
		}
	}
}
