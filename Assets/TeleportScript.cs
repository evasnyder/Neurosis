using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectsWithTag("Player")[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			//player.renderer.enabled = false;
			//float y1 = player.transform.position.y;
			//player.rigidbody.Sleep();
			//player.rigidbody.useGravity = false;
			Vector3 toRight = new Vector3 (player.transform.position.x-50f, player.transform.position.y, player.transform.position.z);
			//Vector3 toRight = new Vector3 (-63.94f, 1.93f, -48.3f);
			//float y2 = player.transform.position.y;
			//print ("Y: " + (y2));
			player.transform.position = toRight;

			//player.renderer.enabled = true;
			
		}
		if (Input.GetKeyDown(KeyCode.N)){
			print ("X: " + player.transform.position.x);
			print ("Y: " + player.transform.position.y);
			print ("Z: " + player.transform.position.z);
		}
	}
	
	void onTriggerStay(Collider other){
		print ("TRIGGERED");
		Vector3 toRight = new Vector3 (player.transform.position.x - 50, 0, 0);
		player.transform.position += toRight;
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


