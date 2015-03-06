using UnityEngine;
using System.Collections;

public class Scares : MonoBehaviour {

	//creating an instance of the little girl
	public GameObject girl;
	public GameObject girlMidway;
	public GameObject girlSmiling;


	// Use this for initialization
	void Start () {
		//begin by setting the little girl equal to false so she cannot be seen in the room
		girl.SetActive (false);
		girlMidway.SetActive (false);
		girlSmiling.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* 
	 *  Method is called when the desk is collided with by the camera 
	 * 	Makes the litlte girl appear 
	 * */ 
	public void Appear(){
		//	make the little girl appear 
		girl.SetActive (true);
		//print ("scare position is " + girlSmiling.transform.position);
		//invoke the Dissapear() method below after .6 seconds 
		//Invoke ("Smile",.5f);

	}
	public void ScareMe(Vector3 pos){
		girl.SetActive (false);
		girlMidway.SetActive (true);
		girlSmiling.transform.position = new Vector3(pos.x+1.3f, 0.9f, -48.2f);
		Invoke ("Smile",.2f);
	}

	void Smile(){
		print ("smile is called");
		girlMidway.SetActive (false);
		girlSmiling.SetActive (true);
		Invoke ("Dissapear",.3f);
	}

	//	Makes the little girl dissapear 
	public void Dissapear(){
		girlSmiling.SetActive (false);
	}
}
