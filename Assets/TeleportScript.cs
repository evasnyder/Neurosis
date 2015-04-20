using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	
	private GameObject player;
	private GameObject initialTeleporter;
	private GameObject frontDoor;
	private GameObject backDoor;
	bool teleport;
	public float xDifference;
	public float zDifference;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectsWithTag("Player")[0];

	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position.x > -23f && player.transform.position.x < -7f &&
		    player.transform.position.z > - 53f && player.transform.position.z < -52f) {
			moveRight();
		}

		if (player.transform.position.x > -66f && player.transform.position.x < -63f &&
		    player.transform.position.z > -53.8f && player.transform.position.z < -53.4f) {
			moveBack();
		}
		if (player.transform.position.x > -63f && player.transform.position.x < -60f &&
		    player.transform.position.z > -37.8f && player.transform.position.z < -37.4f) {
			moveForward();
		}
	
	}

	public void moveRight(){
		Vector3 toRight = new Vector3 (player.transform.position.x-50f, player.transform.position.y, player.transform.position.z);
		player.transform.position = toRight;
	}
	
	public void moveBack(){

		Vector3 toBack = new Vector3 (player.transform.position.x + 3.35f, player.transform.position.y, player.transform.position.z + 15.71f);
		player.transform.position = toBack;
	}

	
	public void moveForward(){
		Vector3 toForward = new Vector3 (player.transform.position.x - 3.35f, player.transform.position.y, player.transform.position.z - 15.71f);
		player.transform.position = toForward;
	}

	public void moveLeft(){
		Vector3 toLeft = new Vector3 (player.transform.position.x+50f, player.transform.position.y, player.transform.position.z);
		player.transform.position = toLeft;
	}

	

}


