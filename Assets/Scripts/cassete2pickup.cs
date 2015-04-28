using UnityEngine;
using System.Collections;

public class cassete2pickup : MonoBehaviour
{

		
	public GameObject note;
	public GameObject player;
	//public GameObject light;
	//public GameObject doorLock;
	public GameObject infoText;
	private bool collision = false;
	public bool pickedUp = false;
	public GameObject hand;
	private TeleportScript tScript;
		
	// Use this for initialization
	void Start ()
	{
		//infoText = GameObject.Find ("InstructionPlane");
		infoText.SetActive (false);
		tScript = GameObject.Find("TeleportTrigger").GetComponent<TeleportScript>();
	}
		
	// Update is called once per frame
	void Update ()
	{
		if (collision & !pickedUp) {
			if (Input.GetMouseButtonDown (0)) {
				//if (Input.GetKey (KeyCode.X)) {
					
				note.transform.parent = player.transform;
				//if(!pickedUp){
				//note.transform.Translate (player.transform.position.x+1, 0, player.transform.position.z+1); //= 
				note.transform.localPosition = new Vector3 (.44f, -.498f, .65f);
				//hand.transform.parent = player.transform;
				//hand.transform.localPosition = new Vector3(.44f, -.498f, .65f);
					
				//new Vector3(-.17f, -.498f,.65f);
				pickedUp = true;
				GameObject.Find("TeleportTrigger").GetComponent<TeleportScript>().goLeft = true;
				Debug.Log ("it should work");
					
				//doorLock.SetActive (false);
			}
		}
	}
		
	void OnTriggerEnter (Collider info)
	{
			
		//	print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
			
		if (info.collider.name == "OVRPlayerController") {
			//infoText.SetActive(true);
			collision = true;
			//}
				
			//TURN ONLY ONE LIGHT OFF 
			//light.intensity = 0.0f; 
		}
			
			
	}

	void OnTriggerExit (Collider info)
	{
		if (info.collider.name == "OVRPlayerController") {
			//infoText.SetActive (false);
			collision = false;
		}
	}

}
