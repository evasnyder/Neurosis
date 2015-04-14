using UnityEngine;
using System.Collections;

public class Scares : MonoBehaviour {

	//creating an instance of the little girl
	public GameObject girl;


	// Use this for initialization
	void Start () {
		girl.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//	make the little girl appear
	public void Appear(){
			girl.SetActive (true);	
	}

	//function for a jumpscare girl
	public void ScareMe(Vector3 pos, Quaternion rot){
			girl.transform.position = new Vector3 (pos.x, 0.9f, pos.z - 1f);
			girl.transform.rotation = rot;
			girl.SetActive (true);
			Invoke ("Dissapear", .3f);
		
	}

	//	Makes the little girl dissapear 
	public void Dissapear(){
		girl.SetActive (false);
	}

	/// 
	/// LERPING STUFF
	/// 

	private float timeTakenDuringLerp = 0.2f;
	private bool _isLerping;
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private float _timeStartedLerping;

	//function for a running away girl
	public void SlidingGirl(){
		_isLerping = true;
		_timeStartedLerping = Time.time;
		
		//We set the start position to the current position, and the finish to 10 spaces in the 'forward' direction
		_startPosition = girl.transform.position;
		
		_endPosition = new Vector3 (2.4f, 1f, -18.27f);

	}
	
	//We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
	void FixedUpdate()
	{
		if(_isLerping)
		{
			//We want percentage = 0.0 when Time.time = _timeStartedLerping
			//and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
			//In other words, we want to know what percentage of "timeTakenDuringLerp" the value
			//"Time.time - _timeStartedLerping" is.
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
			
			//Perform the actual lerping.  Notice that the first two parameters will always be the same
			//throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
			//to start another lerp)
			transform.position = Vector3.Lerp (_startPosition, _endPosition, percentageComplete);
			
			//When we've completed the lerp, we set _isLerping to false
			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
				girl.SetActive(false);
				
			}
		}
	}

}
