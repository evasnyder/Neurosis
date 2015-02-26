using UnityEngine;
using System.Collections;

public class deskHit : MonoBehaviour {
	public GameObject scare;
	public GameObject camera;

	void OnCollisionEnter(Collision collisionInfo)
	{
		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
	}
	void OnCollisionStay(Collision collisionInfo)
	{
		print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
	}
	
	void OnCollisionExit(Collision collisionInfo)
	{
		print(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
	}
}
