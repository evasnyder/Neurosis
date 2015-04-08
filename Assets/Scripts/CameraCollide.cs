using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {

	public bool hasScares; //if the object has scares to trigger
	public GameObject scares; //assign scares
	Scares scareToPerform; //scares to activate
	public GameObject hallBrick;
	public bool inTheHall = false;
	public bool jiggle = false;
	private bool alreadyTriggered;

	// Use this for initialization
	void Start () {
		alreadyTriggered = false;
		if (hasScares) {
			//initiallizing jumpScares to be of type SCARES.CS 
			scareToPerform = scares.GetComponent<Scares> ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info)
	{
		print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		//if the object that was collided with was the desk and what collided with it 
		if (gameObject.name == "RespawnPoint" && info.collider.name == "OVRPlayerController") { 
			print ("player should respawn");
			StartCoroutine (respawn (info)); 
			//Destroy (gameObject);
		}
		if (gameObject.name == "hallBrick" && info.collider.name == "OVRPlayerController") { 
			inTheHall = true;
			Debug.Log ("halling around");
		}
	

	}

	void OnTriggerStay(Collider player){
		if (gameObject.name == "RadiatorScare" && player.collider.name == "OVRPlayerController"){
			print("girl appears on stairs");
			if (hasScares) {
			//call Appear from JUMPSCARES.CS to make the scary object appear 
			scareToPerform.Appear();
			}
		}
		if (gameObject.name == "Wall_PlainFirstScare" && player.collider.name == "OVRPlayerController"){
			print("girl appears in the hallway");
			if(hasScares){
				if (alreadyTriggered==false) {
					//call Appear from JUMPSCARES.CS to make the scary object appear 
					scareToPerform.Appear();
					alreadyTriggered=true;
				}
			}

		}
		if (gameObject.name == "DoorLockCube" && player.collider.name == "OVRPlayerController") {
			jiggle = true;
			Debug.Log ("fuuuuuuuuck");
        }
		//girl jumpscare
		if (gameObject.name == "BedFrameJumpScare" && player.collider.name == "OVRPlayerController") { 
			if (hasScares) {
				print("girl jumpscares at double doors");
				//girl that jumps into the face
				scareToPerform.ScareMe (player.transform.position, player.transform.rotation);
			}
		}

	}

	void OnTriggerExit(Collider player){
		//girl on stairs
		if (gameObject.name == "RadiatorScare" && player.collider.name == "OVRPlayerController") {
			if (hasScares) {
				print ("girls disappears at stairs");
				scareToPerform.Dissapear ();
			}
		}
		if (gameObject.name == "Wall_PlainFirstScare" && player.collider.name == "OVRPlayerController") {
			if (hasScares) {
				print ("girls slides away in hall");
				//girl that slides away
				scareToPerform.SlidingGirl();
			}
		}
	}

	/*Called to respawn the player back in the first room*/
	IEnumerator respawn(Collider toRespawn){
		renderer.enabled = false;
		RenderSettings.fogDensity = 1.0f;
		yield return new WaitForSeconds(2.0f);
		toRespawn.transform.position = new Vector3(0.04833326f, 3.980667f, 0.0f);
		toRespawn.transform.rotation = Quaternion.identity;
		RenderSettings.fogDensity = 0.25f;
		renderer.enabled = true;
	}
}
