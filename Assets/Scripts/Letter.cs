using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour {

	public GameObject letter;
	bool lookLetter;

	// Use this for initialization
	void Start () {
		lookLetter = true; 
	}
	
	// Update is called once per frame
	void Update () {
		//print ("Update");
		if (Input.GetKeyDown (KeyCode.Return)) { 
			print ("ENTER");
			if(lookLetter) { 
				//letter.SetActive(false); 
				letter.GetComponent<MeshRenderer>().enabled = false;
				lookLetter = false;
				print ("Bye Bye");
			} 
			else {
				letter.GetComponent<MeshRenderer>().enabled = true;
				lookLetter = true;
				print ("Why, Hello there (;" );
			} 
		} 
	}

}
