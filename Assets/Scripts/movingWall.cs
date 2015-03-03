using UnityEngine;
using System.Collections;

public class movingWall : MonoBehaviour {
	public GameObject wallToMove;
	private bool triggered;
	private bool alreadyTriggered;
	private Vector3 endPosition = new Vector3(15f, 8f, -47.9f);


	// Use this for initialization
	void Start () {
		wallToMove.active = false;
		triggered = false;
		alreadyTriggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered == true && alreadyTriggered == false)
		{
			alreadyTriggered= true;
			//StartCoroutine(WaitAndMove(1));
			Invoke ("StartCoRoutine", 3);
			}
			if (wallToMove.transform.position == endPosition)
			{
				print ("wall reached end position");
				//Destroy (gameObject);
			}
		}
	void StartCoRoutine(){
		StartCoroutine(WaitAndMove ());

	}

	IEnumerator WaitAndMove(){
		float i = 0.0f;
		//float rate = 1.0f/100f;
		while (i < 100f) {
		//	i += Time.deltaTime * rate;
			wallToMove.transform.position = Vector3.Lerp(wallToMove.transform.position, endPosition, 0.001f);			
			yield return 1; 
		}
			
	}

	void OnTriggerEnter(Collider info)
	{
		if (gameObject.name == "Radiator2Floor" && info.collider.name == "OVRPlayerController") { 
		print ("stairs shut down");
			wallToMove.active = true;

		}
		if (gameObject.name == "HangingLight_MoveWall" && info.collider.name == "OVRPlayerController") { 
			print ("wall should start moving");
			triggered= true;
		}
		if (gameObject.name == "Wall_Moving" && info.collider.name == "OVRPlayerController") { 
			print ("player should be moved");
			//info.transform.Translate(new Vector3( -0.5f, 0.0f, 0.0f));
			//info.transform.rotation = Quaternion.identity;

		}
	}
}
