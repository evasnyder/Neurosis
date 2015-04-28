using UnityEngine;
using System.Collections;

public class Scares : MonoBehaviour {

	//creating an instance of the little girl
	public GameObject girl;
	private float speed = 25f;
	private bool isBall;


	// Use this for initialization
	void Start () {
		girl.SetActive (false);
		isBall = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//	make the little girl appear
	public void Appear(){
			girl.SetActive (true);	
			girl.animation.Play ("Take 0012");
			
	}

	//function for a jumpscare girl
	public void ScareMe(Transform pos){
			girl.transform.parent = pos;
			girl.transform.localPosition = new Vector3 (0f, 0f, 1.2f);
			//print ("player position " + pos.position);
			//print ("girl position " + girl.transform.position);
			girl.SetActive (true);
			girl.animation.Play ("Take 001");
			Invoke ("Dissapear", .3f);
		
	}

	//	Makes the little girl dissapear 
	public void Dissapear(){
		girl.SetActive (false);
	}

	/// 
	/// LERPING STUFF
	/// 

	private float timeTakenDuringLerp;
	private bool _isLerping;
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private float _timeStartedLerping;

	//function for ball
	public void Ball(){
		//girl is now a ball
		isBall = true;
		girl.SetActive (true);
		timeTakenDuringLerp = 7f;
		_isLerping = true;
		_timeStartedLerping = Time.time;
		//We set the start position to the current position, and the finish to 10 spaces in the 'forward' direction
		_startPosition = girl.transform.position;
		_endPosition = new Vector3 (47.32f, 0.17f, -73.28f);

	}
	//function for a running away girl
	public void SlidingGirl(){
		girl.animation.Play ("Take 0011");
		timeTakenDuringLerp = 0.5f;
		_isLerping = true;
		_timeStartedLerping = Time.time;
		
		//We set the start position to the current position, and the finish to 10 spaces in the 'forward' direction
		_startPosition = girl.transform.position;
		
		_endPosition = new Vector3 (2.562f, 0.87f, -47.86f);

	}
	
	//function for a running through walls girl
	public void RunThroughGirl(){
		girl.SetActive (true);
		girl.animation.Play ("Take 0011");
		timeTakenDuringLerp = 0.5f;
		_isLerping = true;
		_timeStartedLerping = Time.time;
		
		//We set the start position to the current position, and the finish to 10 spaces in the 'forward' direction
		_startPosition = girl.transform.position;
		
		_endPosition = new Vector3 (13.35f, 1f, -59.5f);
		
	}
	
	//We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
	void FixedUpdate()
	{
		if(_isLerping)
		{
			if (isBall) {
				girl.transform.Rotate(Vector3.up, speed * Time.deltaTime);
				//girl.transform.Rotate(Vector3.right, 15, Space.World);// * Time.deltaTime);
				//girl.transform.Rotate(new Vector3(-0.5981908f,0.0f,0.0f),15,Space.World);
			}
			else{
				girl.animation.Play ("Take 001");
			}
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
