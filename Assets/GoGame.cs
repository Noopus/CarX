using UnityEngine;
using System.Collections;

public class GoGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	



	}

	Touch touch;


	// Update is called once per frame
	void Update () {

	
		if (Input.touchCount > 0) {
						touch = Input.touches [0];
		
			Application.LoadLevel("gamescebe");


		}



	}
}
