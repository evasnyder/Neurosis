using UnityEngine;
using System.Collections;


//Hannah! I am leaving you comments about how I think the lights need to be handled in room1 
//I can do it, I'm just not sure if this script is done and I don't want to change something
//and fuck it up...

public class PaperPickUp : MonoBehaviour {

	public GameObject note;
	public GameObject player;
	//public GameObject light;

	bool pickedUp = false;

	// Use this for initialization
	void Start () {
		Debug.Log ("lmao");
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

			//TURN ONLY ONE LIGHT OFF 
			//light.intensity = 0.0f; 
		}
            
}
}
