using UnityEngine;
using System.Collections;

public class explo : MonoBehaviour
{
	public GameObject explosion;

	void OnTriggerEnter(Collider other) 
	{

		Instantiate(explosion, transform.position, transform.rotation);


		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}