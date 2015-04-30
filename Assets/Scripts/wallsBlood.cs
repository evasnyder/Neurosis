using UnityEngine;
using System.Collections;

public class wallsBlood : MonoBehaviour {

	public Texture[] myTextures = new Texture[5];
	public GameObject[] walls = new GameObject[7];
	int maxTextures;
	bool blood;
	bool calledOnce;
	public GameObject audio;
	NeurosisAudioManager audioManager;

	void Start ()
	{
		audioManager = audio.GetComponent<NeurosisAudioManager> ();
		maxTextures = myTextures.Length-1;
		blood = false;
		calledOnce = false;
	}


	void Update ()
	{
		if (blood == true && calledOnce == false)
		{
			calledOnce = true;
			foreach(GameObject wall in walls){
					changeTextures(wall.name);
				}
		}  
	}

	void changeTextures(string name){

	switch(name){
	case "Wall_Plain_Blood":
		renderer.material.mainTexture = myTextures[3];
		break;
	case "Wall_Plain_Blood2":
		walls[1].renderer.material.mainTexture = myTextures[1];
		break;
	case "Wall_Plain_Blood3":
		walls[2].renderer.material.mainTexture = myTextures[2];
		break;
	case "Wall_Plain_Blood4":
		walls[3].renderer.material.mainTexture = myTextures[4];
		break;
	case "Wall_Plain_Blood5":
		walls[4].renderer.material.mainTexture = myTextures[1];
		break;
	case "Wall_Plain_Blood6":
		walls[5].renderer.material.mainTexture = myTextures[2];
		break;
	case "Wall_Plain_Blood7":
		walls[6].renderer.material.mainTexture = myTextures[3];
		break;
	default:
		renderer.material.mainTexture = myTextures[0];
		break;
	}
}
	
	void OnTriggerEnter(Collider info)
	{
		if (gameObject.name == "Wall_Plain_Blood" && info.collider.name == "OVRPlayerController") { 
			print("textures should change");
			audioManager.Play (10);//blood splat
			blood =true;
		}
	}
}