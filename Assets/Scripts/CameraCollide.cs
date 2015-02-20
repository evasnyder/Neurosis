using UnityEngine;
using System.Collections;

public class CameraCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info)
	{
		print("Detected collision between " + gameObject.name + " and " + info.collider.name);
	}
}
