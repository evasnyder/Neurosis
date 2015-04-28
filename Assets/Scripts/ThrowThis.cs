using UnityEngine;
using System.Collections;

public class ThrowThis : MonoBehaviour {

	//controls how hard the object will be thrown
	//changing the mass of the object is key, mass should be about 0.1
	private float force = 50;
	//keeps track of if the thing has been thrown or not
	private GameObject throwObject;
	private GameObject player;
	int i = 0;


	// Use this for initialization
	void Start () {
		//invokeRepeating to throw again, look up documentation for parameters
		player = GameObject.FindGameObjectsWithTag("Player")[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void startThrowing (){
		InvokeRepeating ("throwObj", 10f, 15f);

	}


	void throwObj (){
		print ("Kicked");
		throwObject = GameObject.FindGameObjectsWithTag("ThrowThis")[i];
		throwObject.transform.LookAt (player.transform.up);
		throwObject.rigidbody.useGravity = true;
		throwObject.rigidbody.AddForce (transform.forward * force);
		i++;
		if (i == 6) {
			i=0;
		}
		}

	void shakeObj (){
		Vector3 startPosition = throwObject.transform.position;
		Vector3 floatPosition = throwObject.transform.up;


		//float a bit
		throwObject.transform.position = Vector3.Lerp (startPosition, floatPosition, 0.5f);

		Invoke ("throwObj", 0.7f);
	}
	

}
