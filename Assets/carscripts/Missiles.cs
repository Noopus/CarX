using UnityEngine;
using System.Collections;

public class Missiles : MonoBehaviour {

	/*
	void OnCollisionEnter(Collision collisionInfo)
	{
		
		collisionInfo.collider.rigidbody.isKinematic = false;

		collisionInfo.collider.rigidbody.AddExplosionForce (5000, Vector3.up*50, 3000);


		//collisionInfo.collider.rigidbody.useGravity = true;


	}

*/

	void OnTriggerEnter(Collider other) {

		other.rigidbody.isKinematic = false;

		other.rigidbody.useGravity = true;

		print("hit trigger");

		//other.rigidbody.AddExplosionForce (500000, other.transform.up*50000, 300000);

		if(other.transform.rigidbody.mass==8)
		other.rigidbody.AddForce (other.transform.up*1200*(other.transform.rigidbody.mass*1.2f));
		else
			other.rigidbody.AddForce (other.transform.up*1200*(other.transform.rigidbody.mass*0.3f));


	//	other.rigidbody.AddForce (other.transform.forward*200);
	//	other.rigidbody.AddForce (other.transform.right*5);


	//	other.rigidbody.AddTorque (other.transform.forward*2000);
	//	other.rigidbody.AddTorque (other.transform.right*2000);
		other.rigidbody.AddTorque (other.transform.forward*10000);



	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
