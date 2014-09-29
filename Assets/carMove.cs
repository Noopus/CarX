using UnityEngine;
using System.Collections;

public class carMove : MonoBehaviour {
	
	float xspeep = 0f;
	float power = 0.010f;
	float friction = 0.95f;
	bool right = false;
	bool left = false;
	
	public float fuel = 20000;
	
	
	// Use this for initialization
	void FixedUpdate () {
		
		
		if(right){
			xspeep += (power)+accx/35;
		//	fuel -= power;
		}
		if(left){
			xspeep -= (power)+accx/35;
		//	fuel -= power;
		}
		
		
	}


	float iPx,accx;

	
	// Update is called once per frame
	void Update () {


		iPx = Input.acceleration.x;


//		if(Mathf.Abs(iPx)<2)
		accx = Mathf.Abs (iPx);



		if (Input.GetKey (KeyCode.L)||iPx>0.05f) 
			//    if(Input.GetKey(KeyCode.K))
		{
			left = true;
			right = false;
			
			
		} else
			if (Input.GetKey (KeyCode.K)||iPx<-0.05f)
				//        if(Input.GetKey(KeyCode.L))
		{
			left = false;
			right = true;
			
			
		} else {
			left=false;
			right=false;
			
		}




		if(fuel < 0){
			
			xspeep = 0;
			
		}
		
		xspeep *= friction;
		transform.Translate(Vector3.right * -xspeep);
		
	}
}