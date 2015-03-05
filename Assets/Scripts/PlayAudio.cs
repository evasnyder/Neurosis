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

	//	this is the gameObject appear which is set to "Desk" in the inspector 
	// 	because it has to pull out the CameraCollide from whatever object was collided with
	//	creating an instance of the desk in the code to reach the cameraCollide code associated 
	//	with it
	public GameObject appear;
	//	getting cameraCollide scipt 
	CameraCollide cameraCollide;

	bool banged = false;
    
    // Use this for initialization
    void Start () {
		//	setting the audioManager to type NeurosisAudioManager
        audioManager = audio.GetComponent<NeurosisAudioManager> ();
		//	setting the cameraCollide to type CameraCollide 
		cameraCollide = appear.GetComponent<CameraCollide> ();
		audioManager.SetVolume (11, 0.0f);
		opener = door.GetComponent<firstDoorToOpen>();

    }
    
    // Update is called once per frame
    void Update () {


		if (cameraCollide.inHall == true) {
			Debug.Log ("BOOBS");
			audioManager.FadeOut (11);
			audioManager.FadeIn (7);
			audioManager.FadeIn (8);
			if (!banged) {
				audioManager.Play (18);
				banged = true;
			}
		} else {
			audioManager.SetVolume (7, 0.0f);
			audioManager.SetVolume (8, 0.0f);
			audioManager.Play (7);
			audioManager.Play (8);

		}


	


		//	play background music - wind and ambiance (spelling...???)
       // audioManager.PlayLoop (8);
        //audioManager.PlayLoop (7);
		//if (radioHit) {
			audioManager.PlayLoop(11);
		//}

//        Knocking ();
        
		/* 
		 *  If the camera collides with the desk i.e setting the boolean of deskScareHappens equal to true
	 	* */ 
	/*	if (cameraCollide.deskScareHappens == true) {
			if(!radioOn){
				radioOn = true;
				radioHit = true;
				Debug.Log ("radon");
				audioManager.SetVolume(11,1.0f);

			}
			else{
				radioOn = false;
				Debug.Log ("radoff");
				audioManager.SetVolume(11,0.0f);
			}
			//	play the scary audio that comes with the little girl
			//audioManager.Play (9);
			//	reset the desk boolean back to false so it can be hit again and the little girl 
			//	will appear again.
			cameraCollide.deskScareHappens = false;

		}
		*/

		//if(opener.doorHit){
		//	audioManager.PlayLoop(7);
		//	audioManager.PlayLoop(8);

		//}
    }
    

}
