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
	public GameObject camera;

	float firstTapeTimer = 16.6f;
	float secondTapeTimer = 20.5f;
	float thirdTapeTimer = 18.5f;
	float tapePause = 1.0f; //time for pressing the button on the cassette before audio starts

	int tapeOneLoc;
	int tapeTwoLoc;
	int tapeThreeLoc;

	bool placed = false;

	public bool handUp = false;





	//	this is the gameObject appear which is set to "Desk" in the inspector 
	// 	because it has to pull out the CameraCollide from whatever object was collided with
	//	creating an instance of the desk in the code to reach the cameraCollide code associated 
	//	with it
	public GameObject appear;
	//	getting cameraCollide scipt 
	CameraCollide cameraCollide;
    
    // Use this for initialization
    void Start () {
		tapeOneLoc = Random.Range (1, 4);
		tapeTwoLoc = Random.Range (1, 4);
		tapeThreeLoc = Random.Range (1, 4);
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

		if (!placed) {
			placeTapes();
		}

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
			handAppear (firstTapeTimer, 24);
			firstTapeTimer-=Time.deltaTime;
			}

		if (tapePickUp2.pickedUp == true) {
			handAppear (secondTapeTimer,25);
            secondTapeTimer-=Time.deltaTime;
        }

		if (tapePickUp3.pickedUp == true) {
			handAppear (thirdTapeTimer, 26);
            thirdTapeTimer-=Time.deltaTime;
   }

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

	void handAppear(float timer,int track){
		if (timer > 0) {
			handComing ();
			if(handUp){
			if (timer > 13) {
					if(tapePause >0){
						tapePause-=Time.deltaTime;
					}else{
				hand.animation.Play ("TurningOn");
					if(!paperSound){
						audioManager.Play(track);
					}
					paperSound = true;
					}
			} else if (timer > 1) {
				hand.animation.CrossFade ("playing");
			} else {
				hand.animation.CrossFade ("turning it off");
			}
			timer -= Time.deltaTime;
			}

		} else {

			handLeaving ();
			paperSound = false;
			tapePause = 1.0f;
			
		}
	}

	void handComing(){
		if (hand.transform.localPosition.x > .81f) {
			Vector3 temp = hand.transform.localPosition;
			temp.x-=.1f;
			hand.transform.localPosition = temp;
			handUp = false;
		}
		if (hand.transform.localPosition.y < -2.19f) {
			Vector3 temp = hand.transform.localPosition;
			temp.y+=.1f;
			hand.transform.localPosition = temp;
			handUp = false;
		}


		if (hand.transform.localPosition.x <= .81f && hand.transform.localPosition.y >= -2.19f) {
			handUp = true;
		}

	}

	void handLeaving(){
		handUp = false;
		if (hand.transform.localPosition.x < 2.12f) {
			Vector3 temp = hand.transform.localPosition;
			temp.x+=.1f;
			hand.transform.localPosition = temp;

		}
		if (hand.transform.localPosition.y > -3.96f) {
			Vector3 temp = hand.transform.position;
			temp.x-=.1f;
			hand.transform.localPosition = temp;

		}
	}





	void placeTapes(){
		if (tapeOneLoc == 1) {
			firstTape.transform.position = new Vector3(5.442f,2.641f,1.309f);
		}
		if (tapeOneLoc == 2) {
			firstTape.transform.position = new Vector3(-1.785f,2.038f,5.43f);
		}
		
		if (tapeTwoLoc == 1) {
			secondTape.transform.position = new Vector3(62.41f,.023f,-33.6f);
		}
		if (tapeTwoLoc == 2) {
			secondTape.transform.position = new Vector3(53.98f, .957f, -24.28f);
        }
		if (tapeThreeLoc == 1) {
			thirdTape.transform.position = new Vector3(-60.28f, .029f, -53.16f);
		}
		if (tapeThreeLoc == 2) {
			thirdTape.transform.position = new Vector3(-61.54f, .707f, -42.97f);
		}
		placed = true;
    }
}
