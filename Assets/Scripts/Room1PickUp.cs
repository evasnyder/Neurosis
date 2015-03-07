using UnityEngine;
using System.Collections;

public class Room1PickUp : MonoBehaviour {
	
	public GameObject note;
	public GameObject player;
	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	public GameObject girl; 
	//public Light myLight;
	
	float lightStep = .3f;
	float thirdLight = 5f;
	float fucker = 1000;
	float fuckerCounter = .5f;
	int girlcounter = 0;


	public bool pickedUp = false;
	bool turnLight1 = false; 
	bool turnLight2 = false; 
	bool turnLight3 = false; 
	//bool lightFlucker = false;
	float lightFlucker;
	float timer;
	
	// Use this for initialization
	void Start () {
		light.GetComponent("Light");
		light2.light.intensity = 0.0f;
		lightFlucker = light3.light.intensity;
		girl.SetActive (false);
		//print ("Turn light 2 off in beginning");
	}
	
	// Update is called once per frame
	void Update () {
		girl.SetActive (false);
		if (turnLight1) { 
			light1.light.intensity -= lightStep * Time.deltaTime;
			//lightTest.light.intensity = 0.0f;
			//print ("intensity: " + light1.light.intensity);
			
			if (light1.light.intensity <= 0.1) { 
				turnLight2 = true;
				turnLight1 = false; 
			} 
			
		} 
		
		if (turnLight2) { 
			light2.light.intensity = .2f;
			//print ("Turn Light 2 On");
			turnLight3 = true; 
			turnLight2 = false; 
		} 
		
		if (turnLight3) { 
			//print ("Light 3");
			if (thirdLight > 1) { 
			//	print ("Time Decrease");
				thirdLight -= Time.deltaTime;
				girl.SetActive(false);
			//	print ("ThridLight Time :" + thirdLight);
			} else { 
				/*print("Turn Light 3 On");
                light3.light.intensity = .5f;

                float time = Time.deltaTime;

                if(lightFlucker) { 
                    fuckerCounter++;
                    print ("fuckerCounter" + fuckerCounter);
                    lightFlucker = true;
                } 

                //yield WaitForSeconds(1); 
                if(fuckerCounter%2.0f ==0){
                    Debug.Log ("fucker has fucked");
                    light3.light.intensity =1.0f;
                    fucker -=Time.deltaTime;
                }
                else{
                    fucker -=Time.deltaTime;
                    Debug.Log ("fucker is waiting");
                    print ("fucker: " + fucker);
                    light3.light.intensity =0.0f;
                }
            } 
        }*/
				//THIS FLICKERS THE LIGHTS :) 
				if (fuckerCounter <= 0) {
				//	print ("lightFlucker > 0");
					light3.light.intensity -= Time.deltaTime;
					lightFlucker = light3.light.intensity; 
					light3.light.intensity = 0.2f;
					if(girlcounter < 5) { 
						girl.SetActive(true);
						girlcounter++;
					}
					fuckerCounter = Random.Range(0, 3);
				} else {
				//	print ("turn it back off...");
//					int random = Random.Range(1, 5);
//					light3.light.intensity += Time.deltaTime * random;
					light3.light.intensity = 0.0f; 
					girl.SetActive(false);
					lightFlucker = light3.light.intensity; 
					fuckerCounter -= Time.deltaTime;
					print ("counter" + fuckerCounter);
				}
				
				
				
			}
		}
	}
	
	void OnTriggerEnter(Collider info)
	{
	//	print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		if (info.collider.name == "OVRPlayerController") {
			note.transform.parent = player.transform;
			//if(!pickedUp){
			pickedUp = true;
			//note.transform.Translate (player.transform.position.x+1, 0, player.transform.position.z+1); //= 
			note.transform.localPosition= new Vector3(.44f,-.498f,.65f);
			turnLight1 = true; 
			girl.SetActive(false);
		//	print ("turn 1 light off");
		}
		
	}
}