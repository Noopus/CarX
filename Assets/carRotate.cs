using UnityEngine;
using System.Collections;

public class carRotate : MonoBehaviour {
	
	float xspeep = 0f;
	float power = 0.010f;
	float friction = 0.95f;
	bool right = false;
	bool left = false;
	
	public float fuel = 20000;
	




	private Vector3 initialVector = Vector3.forward;
	
	
	// Use this for initialization
	
		
	void Start () {
		
		
		
		
		initialVector = transform.position - piv1.transform.position;
		
		initialVector.y = 0;
		
		
		
		

		
	}





	// Use this for initialization
	void FixedUpdate () {
		
		
		if(right){
	//		xspeep += (power)+accx/45;
			xspeep += (power)+accx/45;
	
			//	fuel -= power;
		}
		if(left){
			xspeep -= (power)+accx/45;
			//	fuel -= power;
		}
		
		
	}
	
	
	float iPx,accx;
	

	public GameObject road,piv1,piv2;


	public float rotateSpeed = 8.0f;



	float rotateDegrees = 0f;



    float count=0;


	bool isallowed = false;


	Touch touch;

	// Update is called once per frame
	void Update () {



		
		
	
		
		if (count > 5) {
			count = 0;
		} else 
		{
			count++;		
		}
	

		if (count == 1) {
	//		transform.Translate (-Vector3.up*0.01f);
		} else if (count == 5) {
	//		transform.Translate (Vector3.up*0.01f);
			
		}


		if (this.transform.position.z > -15f)
	//		this.transform.position = this.transform.position - new Vector3 (0,0,-1.25f);
			transform.Translate (Vector3.forward*-0.05f);

		

//		print("z value : Global ="+transform.position.z+" Local = "+transform.localPosition.z);

		
		
		iPx = Input.acceleration.x;
		
		
		//		if(Mathf.Abs(iPx)<2)
		accx = Mathf.Abs (iPx);





		if (this.transform.position.x < 4.8f && this.transform.position.x > -6.6f)
			isallowed = true;
		else
			isallowed = false;



		
	/*	
		if ((Input.GetKey (KeyCode.L)||iPx>0.05f)&&isallowed) 
			//    if(Input.GetKey(KeyCode.K))
		{
			left = true;
			right = false;
			
			
		} else
			if ((Input.GetKey (KeyCode.K)||iPx<-0.05f)&&isallowed)
				//        if(Input.GetKey(KeyCode.L))
		{
			left = false;
			right = true;
			
			
		} else {
			left=false;
			right=false;
			
		}
	*/


		if (Input.touchCount == 1) {
			touch = Input.touches [0];
			
			
			//		if (Input.GetKey (KeyCode.L)||iPx>0.05f) 
			//    if(Input.GetKey(KeyCode.K))
			if ((Input.GetKey (KeyCode.L) || touch.position.x > Screen.width / 2)&&isallowed) {
				left = true;
				right = false;
				
				
			} else
				//		if (Input.GetKey (KeyCode.K)||iPx<-0.05f)
			if ((Input.GetKey (KeyCode.K) || touch.position.x < Screen.width / 2)&&isallowed) {
				//        if(Input.GetKey(KeyCode.L))
				left = false;
				right = true;
				
				
			} else {
				left = false;
				right = false;
				
			}
			
			
		}
		else {
			left = false;
			right = false;
			
		}

		
		
		
		if(fuel < 0){
			
			xspeep = 0;
			
		}
		
		xspeep *= friction;

//		transform.Translate(Vector3.right * -xspeep);


		
/*		if(piv1.transform.position.z>-14.8f)
			transform.Translate(Vector3.forward*-0.05f);
*/		

		

		
		rotateDegrees = 0f;
		
		float srotateDegrees = 0f;
		
		//        if (Input.GetKey(KeyCode.LeftArrow))
		if(left)
		{
	//		rotateDegrees += rotateSpeed* Time.deltaTime;

			rotateDegrees += rotateSpeed*0.045f;


			rotateDegrees+=Mathf.Abs(xspeep)*6.5f;

		}
		else 
			//    if (Input.GetKey(KeyCode.RightArrow))
			if(right)
		{
	//		rotateDegrees -= rotateSpeed * Time.deltaTime;
	

			rotateDegrees -= rotateSpeed*0.045f;


			rotateDegrees-=Mathf.Abs(xspeep)*6.5f;

		}
		else
		{





		}
		
		
		
		
		
		
		
		//            Vector3 currentVector = transform.position - piv1.transform.position;
		
		Vector3 currentVector;
		
		
		//        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
		if(left||right)
			currentVector =  piv2.transform.position-transform.position;
		else
			currentVector = transform.position - piv1.transform.position;
		
		
		//            currentVector.y = 0;
		
		
		float angleBetween;
		
		
		angleBetween= Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).y > 0 ? 1 : -1);
		
		
		
		
		float newAngle;
		


		if (this.transform.position.x > 4.8f) 
		{
		
//			this.transform.position = this.transform.position - new Vector3 (0.15f, 0, 0);
		

			this.transform.position = new Vector3 (4.8f, this.transform.position.y, this.transform.position.z);

		}

		if (this.transform.position.x < -6.8f) 
		{
//						this.transform.position = this.transform.position - new Vector3 (-0.15f, 0, 0);


			this.transform.position = new Vector3 (-6.8f, this.transform.position.y, this.transform.position.z);


		}


	


		
		//if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
		if(left||right)
		{    
			newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -7, 7);
			rotateDegrees = newAngle - angleBetween;
			this.transform.RotateAround(piv2.transform.position,Vector3.up,rotateDegrees);
			
		}
		else
		{
			newAngle = Mathf.Clamp(angleBetween/2 + srotateDegrees/2, -20, 20);
			srotateDegrees = newAngle/2 - angleBetween;
			this.transform.RotateAround(piv1.transform.position,Vector3.up,srotateDegrees/6);
			
		}
		
		
		
		


	}
}