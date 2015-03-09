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

	public GameObject paper;
	PaperPickUp pickPaper;

	bool banged;
	bool paperSound = false;
	bool paperSound2 = false;

	float knockTime = 2.0f;

	public GameObject paper2;
	Room1PickUp pickPaper2;



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
		pickPaper = paper.GetComponent<PaperPickUp>();
		pickPaper2 = paper2.GetComponent<Room1PickUp>();
		audioManager.SetPriority (11, 0);
    }
    
    // Update is called once per frame
    void Update () {

		audioManager.PlayLoop (11);
		audioManager.PlayLoop (8);
	

        knocking();
        
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

		if (pickPaper.pickedUp == true) {
			if(paperSound == false){
				audioManager.Play (15);
				paperSound = true;
			}
		}

		if (pickPaper2.pickedUp == true) {
			if(paperSound2 == false){
				audioManager.Play (15);
				paperSound2 = true;
			}
		}
	
	}
    
void knocking(){
		if(opener.doorHit == false && pickPaper.pickedUp == true){
			if(knockTime > 0){
				knockTime -= Time.deltaTime;
			}
			else{
				audioManager.Play(6);
				knockTime = 10.0f;
			}
		}


		}
}
