using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {
		
		//	this is the game object that holds the audio manager
		public GameObject audio;
		//	this is the actual audio manager of type NeurosisAudioManager
		NeurosisAudioManager audioManager;
		
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
		
		public GameObject doubleDoor;
		triggerDoubleDoors dDoor;

		//girl, has camera collide scrip attached to her
		public GameObject appear; 
		CameraCollide cameraCollide;
		
		public GameObject hand;
		public GameObject player;
		public GameObject camera;
		
		bool banged;
		bool paperSound = false;
		bool paperSound2 = false;
		bool paperSound3 = false;
		bool radioOn = false;
		bool radioHit = false;
        bool placed = false; // for the tapes
        
        float firstTapeTimer = 15.0f;
        float secondTapeTimer = 19.0f;
        float thirdTapeTimer = 17.0f;
        float knockTime = 2.0f;
        
        //locations of the tapes
        int tapeOneLoc;
		int tapeTwoLoc;
		int tapeThreeLoc;

		//public Animation anim;
    
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
		audioManager.SetPriority (11, 0);
		dDoor=doubleDoor.GetComponent<triggerDoubleDoors>();
		//anim = GetComponent<Animation>();
        
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

			if(dDoor.shake){
				audioManager.Play (40);
			}
			if(dDoor.opened){
				audioManager.Play (31);
			}
			if(dDoor.closed){
				audioManager.Play (18);
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

	void handAppear(float timer){
		if (timer > 0) {
			hand.transform.localPosition = new Vector3 (.97f, -2.32f, .65f);
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

	/*void handAppear(float timer){
		if (timer > 0) {
			hand.transform.localPosition = new Vector3 (.97f, -2.32f, .65f);
			anim.PlayQueued ("TurningOn", QueueMode.PlayNow);
			if (timer > 1) {
				anim.PlayQueued ("playing", QueueMode.CompleteOthers);
			} else {
				anim.PlayQueued ("turning it off", QueueMode.CompleteOthers);
			}
			timer -= Time.deltaTime;
		} else {
			hand.transform.localPosition = new Vector3 (0.0f, 0.0f, 50.0f);
		}
	}
*/
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
			thirdTape.transform.position = new Vector3(-60.32f,.27f,-52.94f);
		}
		if (tapeThreeLoc == 2) {
			thirdTape.transform.position = new Vector3(-66.53f,.687f,-45.856f);
        }
        placed = true;
    }
}
