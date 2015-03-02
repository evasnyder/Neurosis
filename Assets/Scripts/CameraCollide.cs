using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {

	/*	gameObject scares is the little girl that appears behind the desk when hit 
	*	for example, this script could also be attatched to the door and something else could 
	*	appear at the door when you hit it.
	**/
	public GameObject scares;
	public bool hasScares;
	/* 
	 *  This is used for the audio.  This boolean is used in PLAYAUDIO.CS to play teh audio when 
	 * 	this is set equal to true. i.e something hit the object and the scare appeared.
	 * */ 
	public bool deskScareHappens = false;

	/* 
	 *	Object that is of type SCARES.CS which holds the code to make the little girl (or any scare) appear
	 *	when the target object was collided with.  
	 * */ 
	Scares jumpScares; 

	// Use this for initialization
	void Start () {
		if (hasScares) {
			//initiallizing jumpScares to be of type SCARES.CS 
			jumpScares = scares.GetComponent<Scares> ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info)
	{
			print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		//if the object that was collided with was the desk and what collided with it 
		//was the player 
		if ((gameObject.name == "Desk" && info.collider.name == "OVRPlayerController") || (gameObject.name == "Radiator" && info.collider.name == "OVRPlayerController")) {

			//call Appear from JUMPSCARES.CS to make the scary object appear 
			jumpScares.Appear ();
			//set the boolean equal to true which is used to play the scary audio along 
			//with the girl appearing
			deskScareHappens = true;
		} else if (gameObject.name == "RespawnPoint" && info.collider.name == "OVRPlayerController") { 
			print ("player should respawn");
			StartCoroutine (respawn (info)); 
		}
		/*	//KEEP THIS.  HANNAH IS WORKING ON GETTING THE KNOCKING WORKING WHEN YOU HIT FRAME02 (aka fred.)
		if (gameObject.name == "Frame02" && info.collider.name == "OVRPlayerController") 
			
			Invoke ("Knocking", 1.0f);
		}
	}

	void Knocking(){
		audio.Play ();
	}
	*/
	}


	IEnumerator respawn(Collider toRespawn){
		renderer.enabled = false;
		yield return new WaitForSeconds(2.0f);
		toRespawn.transform.position = new Vector3(0.04833326f, 3.980667f, 0.0f);
		toRespawn.transform.rotation = Quaternion.identity;
		renderer.enabled = true;
	}
}
