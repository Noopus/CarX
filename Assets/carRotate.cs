﻿using UnityEngine;
using System.Collections;

public class carRotate : MonoBehaviour {
	
	float xspeep = 0f;
	float power = 0.028f;
	float friction = 0.95f;
	public bool right = false;
	public bool left = false;
	
	public float fuel = 20000;
	




	private Vector3 initialVector = Vector3.forward;
	
	
	// Use this for initialization





		
	void Start () {
		
		
		//sparkparticle.particleEmitter.renderer = false;

		
		initialVector = transform.position - piv1.transform.position;
		
		initialVector.y = 0;
		
		
		
		delay = 0;



		smokeparticle.renderer.enabled = false;

		sparkparticle.particleEmitter.emit=false;

		
	}



	public int health;


	bool repos;

	int repostime=0;




	void OnCollisionEnter(Collision collisionInfo)
	{



		foreach (ContactPoint contact in collisionInfo) 
		{


			//Instantiate(sparkparticle, contact.point, Quaternion.identity);


			Vector3 conpos;

			if(contact.point.x>this.transform.position.x)
				conpos=new Vector3(contact.point.x-0.2f,contact.point.y-0.6f,contact.point.z);
else
					conpos=new Vector3(contact.point.x+0.2f,contact.point.y-0.6f,contact.point.z);

			sparkparticle.transform.position=conpos;
		

		//	sparkparticle.particleEmitter.renderer = true;


			sparkparticle.particleEmitter.emit=true;




		}


		if (gameObject.transform.position.z + 0 < collisionInfo.collider.transform.position.z) {

						health++;

	
						if (collisionInfo.collider.rigidbody != null) 
			{	



//			if(!collisionInfo.collider.name.Equals("Obtruck"))
								collisionInfo.collider.rigidbody.isKinematic = false;


								if (collisionInfo.collider.name.Equals ("Obtruck"))
										Physics.gravity = new Vector3 (0, -100, 0);
								else
										Physics.gravity = new Vector3 (0, -50, 0);




			
								collisionInfo.collider.rigidbody.useGravity = true;




//			gameObject.collider.rigidbody.AddForce (Vector3.forward * -100);


//			gameObject.collider.rigidbody.AddForce (Vector3.up * 50);


//			gameObject.collider.rigidbody.AddTorque (Vector3.forward * -500);




								gameObject.rigidbody.useGravity = true;




						}

						//collisionInfo.collider

		
//		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
//		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
//		print("Their relative velocity is " + collisionInfo.relativeVelocity);



//		collisionInfo.collider.rigidbody.AddForce (Vector3.up * -50);


						if (collisionInfo.collider.transform.position.x > gameObject.transform.position.x) {

								//	gameObject.transform.Translate (Vector3.left * 0.45f);


								if (collisionInfo.collider.rigidbody != null) {	

										//					collider.rigidbody.AddForce (Vector3.left * 50);
	



										//		rigidbody.AddTorque(Vector3.right * 250);


										//		collisionInfo.collider.rigidbody.AddForce (Vector3.left * -150);
				
				
				
										//		collisionInfo.collider.rigidbody.AddTorque(Vector3.right * -550);


										collisionInfo.collider.rigidbody.AddTorque (Vector3.left * -1200);
		
					collisionInfo.collider.rigidbody.AddForce (Vector3.left * -1200);

								}


						} else {

		
								if (collisionInfo.collider.rigidbody != null) {	

					collisionInfo.collider.rigidbody.AddTorque (Vector3.left * 1200);
		
					collisionInfo.collider.rigidbody.AddForce (Vector3.left * 1200);


					
					/*collider.rigidbody.AddTorque(Vector3.right * -25);
		



					rigidbody.AddForce (Vector3.up * -6550);


					rigidbody.AddTorque(Vector3.right * 250);
*/

					
					//		collisionInfo.collider.rigidbody.AddForce (Vector3.left * 150);
				
				
				
										//		collisionInfo.collider.rigidbody.AddTorque(Vector3.right * 550);

			
								}
			
						}

				} else {


			this.gameObject.rigidbody.useGravity=true;

			Physics.gravity=new Vector3(0,-150,0);


				}

	}
	
	void OnCollisionStay(Collision collisionInfo)
	{
//		print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
	

	}
	
	void OnCollisionExit(Collision collisionInfo)
	{
	

		
		sparkparticle.particleEmitter.emit=false;


	//	print(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
	
		if (collisionInfo.collider.transform.position.x > gameObject.transform.position.x) 
		{
			
			gameObject.transform.Translate (Vector3.left * 0.45f);
			
			
					
		} 
		else
		{
			
			gameObject.transform.Translate (Vector3.left * -0.45f);
			
			
			}




		
	}
	


	public GameObject explosion;
	



	public int delay=0;


	public bool gameover;



	float speed;


	public GameObject obstaclemaker;


	// Use this for initialization
	void FixedUpdate () {
		
	
		speed = obstaclemaker.GetComponent<Obstacle> ().speed;

		




		if (health == 1) 
		{
	

		//	Application.LoadLevel (0);
		


		
		//	Instantiate(explosion, transform.position, transform.rotation);



			foreach (Transform t in transform)
			{
		//		if(t.name == "caryell")
		//			t.renderer.enabled=false;


			}


		

//			Destroy(other.gameObject);


//			Destroy(gameObject);





			gameover=true;



			health=0;
		}




		if(right){
	//		xspeep += (power)+accx/45;
			xspeep += (power)+speed/25;
	
			//	fuel -= power;
		}
		if(left){
			xspeep -= (power)+speed/25;
			//	fuel -= power;
		}
		
		
	}
	
	
	float iPx,accx;
	

	public GameObject road,piv1,piv2;


	public float rotateSpeed = 8.0f;



	float rotateDegrees = 0f;



    static float count=0;


	bool isallowed = false;


	Touch touch;



	public GameObject smokeparticle,sparkparticle;





	// Update is called once per frame
	void Update () {



//		smokeparticle.particleEmitter.emit = false;

	


		if (this.transform.position.y < 0.65f)
		{

			//			this.transform.Translate (Vector3.up * 0.5f);

			this.transform.position=new Vector3(this.transform.position.x,0.66f,this.transform.position.z);

			this.transform.rigidbody.angularVelocity=Vector3.zero;

			this.transform.rigidbody.velocity=Vector3.zero;

			this.transform.rotation=Quaternion.identity;

			this.gameObject.rigidbody.useGravity=false;

		}

		this.transform.rigidbody.angularVelocity=Vector3.zero;
		
		this.transform.rigidbody.velocity=Vector3.zero;




//		print ("speed s: "+this.transform.position.y);
		



		if (gameover) {
						delay += 1;
		
			smokeparticle.renderer.enabled = true;

		}else
			delay=0;
		
	


		//	Instantiate(explosion, transform.position, transform.rotation);
		
		
		if(delay==100)
		foreach (Transform t in transform)
		{


			//		if(t.name == "caryell")
			//			t.renderer.enabled=false;
			

		//	Instantiate(explosion, transform.position, transform.rotation);

		}



	








		if (delay > 150) 
		{

			delay=0;

			gameover=false;

			Application.LoadLevel (0);
		}


		
	

		
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





		/*

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


*/

		if (Input.touchCount >0)
			touch = Input.touches [0];
		
		

		
		if (gameover == false) {	
						if (Input.GetKey (KeyCode.RightArrow) || (touch.position.x > Screen.width / 2 && Input.touchCount > 0)) {
								left = true;
								right = false;
			
			
						} else
		if (Input.GetKey (KeyCode.LeftArrow) || (touch.position.x < Screen.width / 2 && Input.touchCount > 0)) {
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
			newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -10, 10);
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