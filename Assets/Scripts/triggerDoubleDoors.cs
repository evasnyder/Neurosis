using UnityEngine;
using System.Collections;

public class triggerDoubleDoors : MonoBehaviour {
	public GameObject door;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other){
		print("shake double doors");
		door.animation.Play ("Take 001");
	}
}
