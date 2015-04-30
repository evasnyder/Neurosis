//Hannah
using UnityEngine;
using System.Collections;



public class NeurosisAudioManager : MonoBehaviour {
	
	
	public AudioClip[] audioClipArray;
	public AudioSource [] audioSourceArray; //new
	
	int i;
	
	private int y;
	private float timerCountDown = .5f;
	
	//private PlayMusic soundScript;
	
	public float[] volumeArray = new float[60];
	
	
	// Use this for initialization
	
	void Start () {
		
		
		
		DontDestroyOnLoad(transform.gameObject);
		
		audioSourceArray = new AudioSource [audioClipArray.Length];
		
		for (i=0; i < audioSourceArray.Length; i++) {
			AudioSource newSource = gameObject.AddComponent<AudioSource> (); //add component to obj
			newSource.clip = audioClipArray [i]; // adds clip to temporary audiosource
			audioSourceArray [i] = newSource; // puts temp audiosource into aduio array
			//soundScript = GetComponent<PlayMusic>();
		}
		audioSourceArray [11].transform.localPosition = new Vector3 (9.95f, 1.0f, 1.6f);
		audioSourceArray [6].transform.localPosition = new Vector3 (0.0f,1.82f,-5.95f);
	}
	
	void Update () {
		
		
	}

	public void SetPriority(int i, int pri){
		audioSourceArray [i].priority = pri;
	}
	
	public void Play(int i){
		//Debug.Log ("play");
		audioSourceArray[i].Play ();
		
	}
	
	public void PlayLoop(int i){  // call this in update!
		
		if (audioSourceArray [i].isPlaying == false) {
			audioSourceArray [i].Play ();
		}
		//audio.Play;
	}
	
	public void Pause(int i){
		audioSourceArray[i].Pause ();
	}
	

	public void Stop(int i){
		audioSourceArray[i].Stop ();
	}
	
	public void KillAll(){
		for (y=0; y<audioSourceArray.Length; y++) {
			
			if (audioSourceArray[y].isPlaying) {
				audioSourceArray[y].Pause ();
			}
		}
		
	}
	
	public void SetVolume(int i, float y){
		
		
		if (i < audioSourceArray.Length)
		{
			audioSourceArray[i].volume = y;
		}
		
		
		
	}

	public void FadeOut(int i){      
		
		
		if (audioSourceArray[i].volume > 0.0f) {
			audioSourceArray[i].volume -= Time.deltaTime/2;

		}
	}
	
	public void FadeIn(int i){
		if (audioSourceArray [i].volume < 1.0f) {
			audioSourceArray [i].volume += Time.deltaTime/2;
		}
    }
    
    
    
    public void CrossFade(int i, int y){
        
    }
    
    public void SetAllVolume()
	{
		for (int j = 0; j < volumeArray.Length; j++)
		{
			SetVolume(j, volumeArray[j]);
		}
	}
	
}
