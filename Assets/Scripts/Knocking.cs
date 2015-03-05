using UnityEngine;
using System.Collections;

public class Knocking : MonoBehaviour {

	public GameObject door;
	firstDoorToOpen opener;

	float countDownTimer = 2.0f;

	public GameObject paper;
	PaperPickUp pickPaper;

	// Use this for initialization
	void Start () {
		opener = door.GetComponent<firstDoorToOpen>();
		pickPaper = paper.GetComponent<PaperPickUp>();
	}
	
	// Update is called once per frame
	void Update () {
		if (opener.doorHit == false && pickPaper.pickedUp) {
			print ("kcock kcock");
			knocking ();
		}
	
	}

	void knocking(){
		if (countDownTimer > 0) {
			countDownTimer -= Time.deltaTime;
		} else {
			audio.Play ();
			countDownTimer = 10.0f;
		}
	}
}
