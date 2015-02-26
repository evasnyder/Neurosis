using UnityEngine;
using System.Collections;

public class triggerDoorOpen : MonoBehaviour {
	public GameObject door;

	public GameObject audio;
	NeurosisAudioManager audioManager;
    
	// Use this for initialization
	void Start () {
		audioManager = audio.GetComponent<NeurosisAudioManager> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		audioManager.Play (1);
		Debug.Log ("collision is detected");
		print("Detected collision between " + gameObject.name + " and " + other.collider.name);
		door.animation.Play("Take 001");
	}
}
