using UnityEngine;
using System.Collections;

public class ThrowThis : MonoBehaviour {

	//controls how hard the object will be thrown
	//changing the mass of the object is key, mass should be about 0.1
	private float force = 400;
	//keeps track of if the thing has been thrown or not
	private GameObject throwObject;
	private GameObject player;


	// Use this for initialization
	void Start () {
		//invokeRepeating to throw again, look up documentation for parameters
		Invoke ("shakeObj", 20f);
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		throwObject = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void throwObj (){
		print ("Kicked");
		throwObject.transform.LookAt (player.transform.up);
		throwObject.rigidbody.AddForce (transform.forward * force);
		}

	void shakeObj (){
		Vector3 startPosition = throwObject.transform.position;
		Vector3 floatPosition = throwObject.transform.up;


		//float a bit
		throwObject.transform.position = Vector3.Lerp (startPosition, floatPosition, 0.5f);

		Invoke ("throwObj", 0.7f);
	}
	

}
