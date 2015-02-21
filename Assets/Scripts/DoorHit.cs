using UnityEngine;
using System.Collections;

public class DoorHit : MonoBehaviour {
	public GameObject scare;
	public GameObject camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		Debug.Log ("it is hit");
		scare.transform.position = new Vector3 (camera.transform.position.x + 1, camera.transform.position.y + 1, camera.transform.position.z);

	}
}