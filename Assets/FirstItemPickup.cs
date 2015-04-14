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

	}
	
	void OnTriggerEnter(Collider info)
	{
		
		//	print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		if (!pickedUp & (info.collider.name == "cassetteplayer_model" | info.collider.name=="Room 0 Cassette")) {
			infoText.SetActive(true);
			pickedUp=true;

		}
		
		
	}
	void OnTriggerExit(Collider info){
		if (info.collider.name == "cassetteplayer_model" | info.collider.name=="Room 0 Cassette") {
			infoText.SetActive (false);

		}
	}
}
