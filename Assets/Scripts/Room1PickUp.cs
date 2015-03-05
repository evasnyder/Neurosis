using UnityEngine;
using System.Collections;

public class Room1PickUp : MonoBehaviour {

	public GameObject note;
	public GameObject player;
	public GameObject lightTest;
	//public Light myLight;

	float lightStep = .05f;
	bool pickedUp = false;
	
	// Use this for initialization
	void Start () {
		light.GetComponent("Light");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info)
	{
		
		print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		if (info.collider.name == "OVRPlayerController") {
			note.transform.parent = player.transform;
			//if(!pickedUp){
			//note.transform.Translate (player.transform.position.x+1, 0, player.transform.position.z+1); //= 
			note.transform.localPosition= new Vector3(.44f,-.498f,.65f);
			
			//new Vector3(-.17f, -.498f,.65f);
			//	pickedUp = true;
			//}
			
			//TURN THE LIGHT OFF SLOWLY
			lightTest.light.intensity -= lightStep * Time.deltaTime;
			//lightTest.light.intensity = 0.0f;
			print ("lights off");
			print ("intensity: " + lightTest.light.intensity);
		}
		
	}
}
