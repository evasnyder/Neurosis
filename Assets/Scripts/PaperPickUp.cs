using UnityEngine;
using System.Collections;

public class PaperPickUp : MonoBehaviour {

	public GameObject note;
	public GameObject player;

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
		print ("woopie!");
		print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");

		if (info.collider.name == "OVRPlayerController") {
			note.transform.parent = player.transform;
			//if(!pickedUp){
			//note.transform.Translate (player.transform.position.x+1, 0, player.transform.position.z+1); //= 
			note.transform.localPosition= new Vector3(.44f,-.498f,.65f);

				//new Vector3(-.17f, -.498f,.65f);
			//	pickedUp = true;
			//}
		}
            
}
}
