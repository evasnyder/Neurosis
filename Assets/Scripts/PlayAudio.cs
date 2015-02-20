using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {
    
    public GameObject audio;
    NeurosisAudioManager audioManager;
    
    public float waitTime = 3.0f;
    public bool knocked = true;
    
    // Use this for initialization
    void Start () {
        audioManager = audio.GetComponent<NeurosisAudioManager> ();
        
        
    }
    
    // Update is called once per frame
    void Update () {
        audioManager.PlayLoop (8);
        audioManager.PlayLoop (7);
        Knocking ();
        
    }
    
    void Knocking(){
            audioManager.Play (6);
     
}
}
