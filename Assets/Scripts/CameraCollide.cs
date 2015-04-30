using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {

	public bool hasScares; //if the object has scares to trigger
	public GameObject scares; //assign scares
	Scares scareToPerform; //scares to activate
	public GameObject hallBrick;
	public GameObject roomBrick;
	public bool inTheHall = false;
	public bool inRoomOne = false;
	public bool jiggle = false;
	private bool alreadyTriggered;


	public Rigidbody door;  
	private GameObject player;
	ThrowThis ThrowScript;

	//girl booleans
	private bool first_Trig;
	private bool jumpScare_Trig;
	private bool runThrough_Trig;
	private bool stairs_Trig;
	private bool ball_Trig;

	// Use this for initialization
	void Start () {
		//scares triggers
		alreadyTriggered = false;
		first_Trig = false;//
		jumpScare_Trig = false;//
		runThrough_Trig = false;//
		stairs_Trig = false;//
		ball_Trig = false;//

		if (hasScares) {
			//initiallizing jumpScares to be of type SCARES.CS 
			scareToPerform = scares.GetComponent<Scares> ();
		}
		ThrowScript = GameObject.Find("ThrowTrigger").GetComponent<ThrowThis>();
	}


	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider info)
	{
		print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		if (gameObject.name == "ThrowTrigger" && info.collider.name == "OVRPlayerController") {
			ThrowScript.startThrowing();
		}

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

		if (gameObject.name == "Wall_Plain_RunThroughGirl" && info.collider.name == "OVRPlayerController") {
			if (hasScares) {
				if (runThrough_Trig==false) {
				print ("girls runs through the wall");
				//girl that slides away
				scareToPerform.RunThroughGirl();
					runThrough_Trig=true;
				}
			}
		}

		if (gameObject.name == "Wall_Plain_Ball" && info.collider.name == "OVRPlayerController") {
			if (hasScares) {
				if (ball_Trig==false) {
					print ("ball rolled in");
					//girl that slides away
					scareToPerform.Ball ();
					ball_Trig=true;
				}
			}
		}

		if (gameObject.name == "RoomOneBrick" && info.collider.name == "OVRPlayerController") {
			inRoomOne = true;
		}
	

	}

	void OnTriggerStay(Collider player){
		if (gameObject.name == "Wall_Plain_StairsScare" && player.collider.name == "OVRPlayerController"){
			if (hasScares) {
				if (stairs_Trig==false) {
					print("girl appears on stairs");
					//call Appear from JUMPSCARES.CS to make the scary object appear 
					scareToPerform.Appear(true);
					stairs_Trig=true;
				}
			}
		}
		if (gameObject.name == "Wall_PlainFirstScare" && player.collider.name == "OVRPlayerController"){
			if(hasScares){
				if (first_Trig==false) {
					print("girl appears in the hallway");
					//call Appear from JUMPSCARES.CS to make the scary object appear 
					scareToPerform.Appear(false);
					first_Trig=true;
				}
			}

		}
		if (gameObject.name == "DoorLockCube" && player.collider.name == "OVRPlayerController") {
			jiggle = true;

        }
		//girl jumpscare
		if (gameObject.name == "Wall_Plain_OpenMouthScare" && player.collider.name == "OVRPlayerController") { 
			if (hasScares) {
				if (jumpScare_Trig==false) {
					print("girl jumpscares");
					//girl that jumps into the face
					scareToPerform.ScareMe (player.transform);
					jumpScare_Trig=true;
				}
			}
		}

	}

	void OnTriggerExit(Collider player){
		//girl on stairs
		if (gameObject.name == "Wall_Plain_StairsScare" && player.collider.name == "OVRPlayerController") {
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
