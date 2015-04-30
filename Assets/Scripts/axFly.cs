using UnityEngine;
using System.Collections;

public class axFly : MonoBehaviour {
	
	bool follow = false;
	
	GameObject sticky_wall;
	
	public float speed = 10;
	
	Vector3 temp;
	
	GameObject player;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find ("OVRPlayerController");
		sticky_wall = GameObject.Find ("Wall_Moving");
		
		Physics.IgnoreCollision(gameObject.collider, player.collider);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (follow == false) {
			
			rigidbody.velocity = new Vector3 (speed, 0, 0);
			
		} else {
			
			
			//temp = sticky_wall.transform.position;
			//temp.y = transform.position.y;
			//temp.z = transform.position.z;

			//transform.position = temp;

		}
		
	}
	
	
	void OnCollisionEnter(Collision collide)
	{    
		if(collide.collider.gameObject.name == "Wall_Moving" && follow == false)        
		{
			var joint = gameObject.AddComponent<FixedJoint>(); joint.connectedBody = collide.rigidbody; 
			follow = true;
			//Destroy (gameObject.rigidbody);
		}        
	}
}
