using UnityEngine;
using System.Collections;

public class Knocking : MonoBehaviour {

	public GameObject door;
	firstDoorToOpen opener;

	float countDownTimer = 5.0f;

	// Use this for initialization
	void Start () {
		opener = door.GetComponent<firstDoorToOpen>();
	}
	
	// Update is called once per frame
	void Update () {
		if (opener.doorHit == false) {
			knocking ();
		}
	
	}

	void knocking(){
		if (countDownTimer > 0) {
			countDownTimer -= Time.deltaTime;
		} else {
			audio.Play ();
			countDownTimer = 5.0f;
		}
	}
}
