using UnityEngine;
using System.Collections;

public class backwheel : MonoBehaviour {



	Vector3 pivot;


	public GameObject front;



	// Use this for initialization
	void Start () {
	


	


	}



	Bounds bounds;
	
	// Update is called once per frame
	void Update () {


	//	this.transform.localEulerAngles= new Vector3(4000*Time.deltaTime,0,0);

		this.transform.Rotate(-100,0,0);

	
	//	front.transform.Rotate(-100,0,0);



	//	this.transform.position += new Vector3(0,-6f/60,-6f/60);





	}
}
