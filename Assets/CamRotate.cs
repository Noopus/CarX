using UnityEngine;
using System.Collections;

public class CamRotate : MonoBehaviour {




	public GameObject pivot;



	// Use this for initialization
	void Start () 
	{
	


	}



	// Update is called once per frame
	void Update () 
	{
	


		transform.RotateAround (pivot.transform.position, Vector3.up, 20 * Time.deltaTime);


	}




}
