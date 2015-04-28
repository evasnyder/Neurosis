using UnityEngine;
using System.Collections;

public class axScript : MonoBehaviour {

	public GameObject axPrefab;

	bool triggered = false;

	public Vector3 startPos = new Vector3(9,9,-47);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnTriggerEnter(){

		if (!triggered) {

			Instantiate (axPrefab, startPos, Quaternion.identity);

			triggered = true;

			
		}

	}
}
