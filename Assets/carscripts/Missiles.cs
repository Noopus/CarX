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



		if (!other.name.Equals ("BottomBlock")) {



						other.rigidbody.isKinematic = false;

						other.rigidbody.useGravity = true;




						if (other.GetComponent<VehExploSound> () != null) {

								other.GetComponent<VehExploSound> ().explode ();


		
						}


						//other.rigidbody.AddExplosionForce (500000, other.transform.up*50000, 300000);

						if (other.transform.rigidbody.mass == 2) {
								other.rigidbody.AddForce (other.transform.up * 1200 * (other.transform.rigidbody.mass * 0.45f));
						} else
								other.rigidbody.AddForce (other.transform.up * 1200 * (other.transform.rigidbody.mass * 0.3f));


						//	other.rigidbody.AddForce (other.transform.forward*200);
						//	other.rigidbody.AddForce (other.transform.right*5);


						//	other.rigidbody.AddTorque (other.transform.forward*2000);
						//	other.rigidbody.AddTorque (other.transform.right*2000);

						other.rigidbody.AddTorque (other.transform.forward * 10000);

						other.rigidbody.AddForce (other.transform.forward * -2000);

				}




	}



	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
