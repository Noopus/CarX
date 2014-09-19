using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {


	public GameObject road;

	// Use this for initialization
	void Start () {


		Vector3 inipos = new Vector3 (transform.position.x,road.transform.position.y-0.8f,transform.position.z);

		this.transform.position = inipos;


	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey ("left"))
						this.transform.Translate (Vector3.left*0.2f);
		else
			if (Input.GetKey ("right"))
				this.transform.Translate (Vector3.left*-0.2f);





	
	}



}
