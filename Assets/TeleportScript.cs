using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	
	private GameObject player;
	private GameObject initialTeleporter;
	private GameObject frontDoor;
	private GameObject backDoor;
	bool teleport;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		//initial teleporter
		initialTeleporter = GameObject.FindGameObjectsWithTag("TeleportTrigger")[3];
		//door in front of middle room
		frontDoor = GameObject.FindGameObjectsWithTag("TeleportTrigger")[1];
		//door in back of middle room
		backDoor = GameObject.FindGameObjectsWithTag("TeleportTrigger")[2];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			//player.renderer.enabled = false;
			//float y1 = player.transform.position.y;
			//player.rigidbody.Sleep();
			//player.rigidbody.useGravity = false;
		//	Vector3 toRight = new Vector3 (player.transform.position.x-50f, player.transform.position.y, player.transform.position.z);
			//Vector3 toRight = new Vector3 (-63.94f, 1.93f, -48.3f);
			//float y2 = player.transform.position.y;
			//print ("Y: " + (y2));
		//	player.transform.position = toRight;
			moveRight();
			//player.renderer.enabled = true;
			
		}
		if (Input.GetKeyDown(KeyCode.N)){
			print ("X: " + player.transform.position.x);
			print ("Y: " + player.transform.position.y);
			print ("Z: " + player.transform.position.z);
		}
	}

	public void moveRight(){
		Vector3 toRight = new Vector3 (player.transform.position.x-50f, player.transform.position.y, player.transform.position.z);
		player.transform.position = toRight;

	}
	
	void onTriggerEnter(Collider info){
		Vector3 teleportTo;
		if (gameObject.name == "TeleportTrigger" && info.collider.name == "OVRPlayerController") { 
			print ("TRIGGEREDTOTELEPORT1");
			teleportTo = new Vector3 (player.transform.position.x - 50f, player.transform.position.y, player.transform.position.z);
		} else if (info == frontDoor) {
			teleportTo = new Vector3 (backDoor.transform.position.x, backDoor.transform.position.y, backDoor.transform.position.z);
			print ("TRIGGEREDTOTELEPORT2");
		} else if (info == backDoor) {
			print ("TRIGGEREDTOTELEPORT3");
			teleportTo = new Vector3 (frontDoor.transform.position.x, frontDoor.transform.position.y, frontDoor.transform.position.z);
		} else {
			print ("TRIGGEREDTOTELEPORT?");
			teleportTo = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		}
		player.transform.position = teleportTo;
	}

	/*IEnumerator respawn(Collider toRespawn){
		renderer.enabled = false;
		RenderSettings.fogDensity = 1.0f;
		yield return new WaitForSeconds(2.0f);
		toRespawn.transform.position = new Vector3(0.04833326f, 3.980667f, 0.0f);
		toRespawn.transform.rotation = Quaternion.identity;
		RenderSettings.fogDensity = 0.25f;
		renderer.enabled = true;
	}*/
}


