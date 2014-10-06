using UnityEngine;
using System.Collections;

public class carMove : MonoBehaviour {
	
	float xspeep = 0f;
//	float power = 0.0110f;
//	float friction = 0.95f;

	float power = 0.018f;
	float friction = 0.940f;


	bool right = false;
	bool left = false;
	
	public float fuel = 20000;


	
	



	
	// Use this for initialization
	void FixedUpdate () {
		
		
		if(right){
			xspeep += (power)+accx/55;
		//	fuel -= power;
		}
		if(left){
			xspeep -= (power)+accx/55;
		//	fuel -= power;
		}
		
		
	}


	float iPx,accx;


	Touch touch;

	// Update is called once per frame
	void Update () {


		iPx = Input.acceleration.x;


//		if(Mathf.Abs(iPx)<2)
		accx = Mathf.Abs (iPx);



		if (Input.touchCount >0)
		touch = Input.touches [0];

	
		/*

	//	if (Input.touchCount == 1||Input.touchCount == 0) 
		{
						touch = Input.touches [0];

		
//		if (Input.GetKey (KeyCode.L)||iPx>0.05f) 
						//    if(Input.GetKey(KeyCode.K))
						if (Input.GetKey (KeyCode.L) || touch.position.x > Screen.width / 2) {
								left = true;
								right = false;
			
			
						} else
	//		if (Input.GetKey (KeyCode.K)||iPx<-0.05f)
			if (Input.GetKey (KeyCode.K) || touch.position.x < Screen.width / 2) {
				//        if(Input.GetKey(KeyCode.L))
								left = false;
								right = true;
			
			
						} else {
								left = false;
								right = false;
			
						}


				}
/*
		else {
			left = false;
			right = false;
			
		}



		*/



		if (Input.GetKey (KeyCode.RightArrow)|| (touch.position.x > Screen.width / 2&&Input.touchCount >0)) {
			left = true;
			right = false;
			
			
		} else
		if (Input.GetKey (KeyCode.LeftArrow)|| (touch.position.x < Screen.width / 2&&Input.touchCount >0)) {
			left = false;
			right = true;
			
			
		} else {
			left = false;
			right = false;
			
		}
		



		if(fuel < 0){
			
			xspeep = 0;
			
		}
		
		xspeep *= friction;

		transform.Translate(Vector3.right * -xspeep);





	
	}




}