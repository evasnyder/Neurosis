using UnityEngine;
using System.Collections;


public class FirstItemPickup : MonoBehaviour {
	
	public GameObject infoText;
	private bool collision = false;
	public bool pickedUp = false;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (collision & !pickedUp) {
			if (Input.GetMouseButtonDown (0)) {
				pickedUp = true;
			}
		}
		if (pickedUp) {
			infoText.SetActive (false);
		}
	}
	
	void OnTriggerEnter(Collider info)
	{
		
		//	print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		if (!pickedUp & (info.collider.name == "cassetteplayer_model" | info.collider.name=="Room 0 Cassette")) {
			infoText.SetActive(true);
			collision=true;
		}
		
		
	}
	void OnTriggerExit(Collider info){
		if (info.collider.name == "cassetteplayer_model" | info.collider.name=="Room 0 Cassette") {
			infoText.SetActive (false);
			collision=false;
		}
	}
}
