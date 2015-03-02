using UnityEngine;
using System.Collections;

public class movingWall : MonoBehaviour {
	public GameObject wallToMove;
	private bool triggered;
	private Vector3 endPosition = new Vector3(15f, 8f, -47.9f);


	// Use this for initialization
	void Start () {
		wallToMove.active = false;
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered == true)
		{
			StartCoroutine(WaitAndMove(1));
			}
			if (wallToMove.transform.position == endPosition)
			{
				print ("wall reached end position");
				//Destroy (gameObject);
			}
		}

	IEnumerator WaitAndMove(float delayTime){
		yield return new WaitForSeconds(delayTime); // start at time X
		float startTime=Time.time; // Time.time contains current frame time, so remember starting point
		while(Time.time-startTime<=100){ // until one second passed
			wallToMove.transform.position = Vector3.Lerp(wallToMove.transform.position, endPosition,Time.time-startTime); // lerp from A to B in one second
			yield return 1; // wait for next frame
		}
	}

	void OnTriggerEnter(Collider info)
	{
		if (gameObject.name == "Radiator2Floor" && info.collider.name == "OVRPlayerController") { 
		print ("stairs shut down");
			wallToMove.active = true;

		}
		if (gameObject.name == "HangingLight_MoveWall" && info.collider.name == "OVRPlayerController") { 
			print ("wall starts moving");
			triggered= true;
		}
	}
}
