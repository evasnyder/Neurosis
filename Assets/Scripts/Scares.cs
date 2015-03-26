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
		//	make the little girl appear on stairs
		girl.SetActive (true);
	}
	//function for a nonshaking smiling doors
	public void ScareMe(Vector3 pos, Quaternion rot){
		//print ("scare position is " + girlSmiling.transform.position);
		//print ("player position is " + pos);
		//print ("player rotation is " + rot);
		//girlMidway.SetActive (true);
		girlSmiling.transform.position = new Vector3(pos.x, 0.9f, pos.z-1.3f);
		girlSmiling.transform.rotation = rot;
		//Invoke ("Smile",.2f);
		girlSmiling.SetActive (true);
		Invoke ("DissapearSmile",.2f);
	}
	//Smile is not called yet, it should be callled if midway girl is wanted
	void Smile(){
		print ("smile is called");
		girlMidway.SetActive (false);
		girlSmiling.SetActive (true);
		Invoke ("DissapearSmile",.2f);
	}

	void DissapearSmile(){
		girlSmiling.SetActive (false);
	}

	//	Makes the little girl dissapear 
	public void Dissapear(){
		//girlSmiling.SetActive (false);
		girl.SetActive (false);
	}
}
