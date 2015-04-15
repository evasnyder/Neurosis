using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {
    
	//	this is the game object that holds the audio manager
    public GameObject audio;
	//	this is the actual audio manager of type NeurosisAudioManager
    NeurosisAudioManager audioManager;
	bool radioOn = false;
	bool radioHit = false;

	public GameObject door;
	firstDoorToOpen opener;

	public GameObject tapePlayer;
	PaperPickUp tapePlayerPickup;

	public GameObject firstTape;
	PaperPickUp tapePickup;

	public GameObject secondTape;
	PaperPickUp tapePickUp2;

	public GameObject thirdTape;
	PaperPickUp tapePickUp3;

	bool banged;
	bool paperSound = false;
	bool paperSound2 = false;
	bool paperSound3 = false;

	float knockTime = 2.0f;

	//public GameObject paper2;
	//Room1PickUp pickPaper2;

	public GameObject hand;
	public GameObject player;

	float firstTapeTimer = 15.0f;
	float secondTapeTimer = 19.0f;
	float thirdTapeTimer = 17.0f;



	//	this is the gameObject appear which is set to "Desk" in the inspector 
	// 	because it has to pull out the CameraCollide from whatever object was collided with
	//	creating an instance of the desk in the code to reach the cameraCollide code associated 
	//	with it
	public GameObject appear;
	//	getting cameraCollide scipt 
	CameraCollide cameraCollide;
    
    // Use this for initialization
    void Start () {

		//	setting the audioManager to type NeurosisAudioManager
        audioManager = audio.GetComponent<NeurosisAudioManager> ();
		//	setting the cameraCollide to type CameraCollide 
		cameraCollide = appear.GetComponent<CameraCollide> ();
		audioManager.SetVolume (11, 0.0f);
		opener = door.GetComponent<firstDoorToOpen>();
		tapePlayerPickup = tapePlayer.GetComponent<PaperPickUp>();
		tapePickup = firstTape.GetComponent<PaperPickUp> ();
		tapePickUp2 = secondTape.GetComponent<PaperPickUp> ();
		tapePickUp3 = thirdTape.GetComponent<PaperPickUp> ();
		//pickPaper2 = paper2.GetComponent<Room1PickUp>();
		audioManager.SetPriority (11, 0);
    }
    
    // Update is called once per frame
    void Update () {

		if (cameraCollide.jiggle) {
			audioManager.Play (28);
		}
		if (cameraCollide.inTheHall== false) {
			audioManager.SetVolume (11, .5f);
		}
		audioManager.PlayLoop (11);
		audioManager.PlayLoop (8);
	

       // knocking();
        
		if (cameraCollide.inTheHall == true) {
            audioManager.FadeOut (11);
			Debug.Log ("FADE TEH FUCK OUT");
			audioManager.FadeOut (8);
            audioManager.FadeIn (7);
           // audioManager.FadeIn (8);
			if (!banged && opener.doorSlammed) {
				audioManager.Play (18);
				banged = true;
			}
        } else {
            audioManager.SetVolume (7, 0.0f);
            audioManager.SetVolume (8, 0.0f);
            audioManager.Play (7);
            audioManager.Play (8);

        }

		if (tapePlayerPickup.pickedUp == true && tapePickup.pickedUp == true) {
			if(!paperSound){
			audioManager.Play (24);
			}
			paperSound = true;
			handAppear (firstTapeTimer);
			firstTapeTimer-=Time.deltaTime;
			}

		if (tapePickUp2.pickedUp == true) {
			if(!paperSound2){
				audioManager.Play (25);
			}
			paperSound2 = true;
			handAppear (secondTapeTimer);
            secondTapeTimer-=Time.deltaTime;
        }

		if (tapePickUp3.pickedUp == true) {
			if(!paperSound3){
				audioManager.Play (26);
			}
			paperSound3 = true;
			handAppear (thirdTapeTimer);
            thirdTapeTimer-=Time.deltaTime;
        }


	/*	if (pickPaper2.pickedUp == true) {
			if(paperSound2 == false){
				audioManager.Play (15);
				audioManager.Play (25);
				paperSound2 = true;
			}
		}
	*/
	}
    
void knocking(){
		if(opener.doorHit == false && tapePickup.pickedUp && tapePlayerPickup.pickedUp){
			if(knockTime > 0){
				knockTime -= Time.deltaTime;
			}
			else{
				audioManager.Play(6);
				knockTime = 10.0f;
			}
		}


		}

	void handAppear(float timer){
		if (timer > 0) {
			hand.transform.parent = player.transform;
			hand.transform.localPosition = new Vector3 (.44f, -1.27f, .65f);
			if(timer>14){
			hand.animation.Play ("TurningOn");
			}
					else if(timer>1){
			hand.animation.Play ("playing");
					}
					else{
						hand.animation.Play("turning it off");
					}
			timer-=Time.deltaTime;

		} else{

			hand.transform.localPosition = new Vector3 (0.0f, 0.0f, 50.0f);
			
		}
	}
}
