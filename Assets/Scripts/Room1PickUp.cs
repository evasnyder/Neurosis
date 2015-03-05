using UnityEngine;
using System.Collections;

public class Room1PickUp : MonoBehaviour {

	public GameObject note;
	public GameObject player;
	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	//public Light myLight;

	float lightStep = .1f;
	float thirdLight = 5f;
	float fucker = 1000;
	int fuckerCounter = 0;

	bool pickedUp = false;
	bool turnLight1 = false; 
	bool turnLight2 = false; 
	bool turnLight3 = false; 
	bool lightFlucker = false;
	
	// Use this for initialization
	void Start () {
		light.GetComponent("Light");
		light2.light.intensity = 0.0f;
		print ("Turn light 2 off in beginning");
	}
	
	// Update is called once per frame
	void Update () {
		if (turnLight1) { 
			light1.light.intensity -= lightStep * Time.deltaTime;
			//lightTest.light.intensity = 0.0f;
			print ("intensity: " + light1.light.intensity);

			if(light1.light.intensity <= 0.1) { 
				turnLight2 = true;
			} 
		} 

		if (turnLight2) { 
			light2.light.intensity = .5f;
			print("Turn Light 2 On");

			turnLight3 = true; 
		} 

		if (turnLight3) { 
			if(thirdLight > 1){ 
				print ("Time Decrease");
				thirdLight -= Time.deltaTime;
				print ("ThridLight Time :" + thirdLight);
			} 
				
			else { 
				print("Turn Light 3 On");
				light3.light.intensity = .5f;

				float time = Time.deltaTime;

				if(Time.deltaTime > time) { 
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
		}



	}

	void OnTriggerEnter(Collider info)
	{
		
		print ("Detected collision between " + gameObject.name + " and " + info.collider.name + " in CameraCollide");
		
		if (info.collider.name == "OVRPlayerController") {
			note.transform.parent = player.transform;
			//if(!pickedUp){
			//note.transform.Translate (player.transform.position.x+1, 0, player.transform.position.z+1); //= 
			note.transform.localPosition= new Vector3(.44f,-.498f,.65f);

			turnLight1 = true; 
		}
		
	}
}
