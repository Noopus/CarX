using UnityEngine;
using System.Collections;

public class carRotate : MonoBehaviour {
	
	float xspeep = 0f;
	float power = 0.0320f;
//	float friction = 0.670f;
	float friction = 0.570f;
	public bool right = false;
	public bool left = false;
	
	public float fuel = 20000;
	




	private Vector3 initialVector = Vector3.forward;
	
	
	// Use this for initialization



	public AudioClip clip;

		

	public ParticleSystem nitros;



	public TextMesh score;


	Quaternion secrot;
	void Start () {


		firstrot = this.transform.rotation;


		//secrot = Quaternion.Euler ((firstrot.eulerAngles)*400);

		secrot = Quaternion.Euler (new Vector3(900,100,100));


		//sparkparticle.particleEmitter.renderer = false;

		
		initialVector = transform.position - piv1.transform.position;
		
		initialVector.y = 0;
		
		
		
		delay = 0;



		smokeparticle.renderer.enabled = false;

		sparkparticle.particleEmitter.emit=false;



		audio.loop = true;
	
		audio.clip = clip; 

	//	audio.Play();


		audio.pitch = 2.0f;
	}



	public int health;


	bool repos;

	int repostime=0;




	void OnCollisionEnter(Collision collisionInfo)
	{



		if (!gameover) {
	

		




		
						foreach (ContactPoint contact in collisionInfo) {



			//	this.transform.rigidbody.AddExplosionForce(1000,Vector3.forward*-2500,1000);


								//Instantiate(sparkparticle, contact.point, Quaternion.identity);


								Vector3 conpos;

								if (contact.point.x > this.transform.position.x)
										conpos = new Vector3 (contact.point.x - 0.2f, contact.point.y - 0.6f, contact.point.z);
								else
										conpos = new Vector3 (contact.point.x + 0.2f, contact.point.y - 0.6f, contact.point.z);

								sparkparticle.transform.position = conpos;
		

								sparkparticle.particleEmitter.emit = true;



			
						}


						if (gameObject.transform.position.z + 0 < collisionInfo.collider.transform.position.z) {

								health++;

	
								if (collisionInfo.collider.rigidbody != null) {	

										collisionInfo.collider.rigidbody.isKinematic = false;


									//	Physics.gravity = new Vector3 (0, -20, 0);




			
										collisionInfo.collider.rigidbody.useGravity = true;



										gameObject.rigidbody.useGravity = true;




								}



				collisionInfo.collider.rigidbody.AddForce (collisionInfo.collider.transform.forward * 500*speed);

				collisionInfo.collider.rigidbody.AddForce (collisionInfo.collider.transform.up * 500*speed);

				collisionInfo.collider.rigidbody.AddTorque (collisionInfo.collider.transform.up * 6500*speed);


				collider.rigidbody.AddForce (collisionInfo.collider.transform.forward * -3500*speed);



								if (collisionInfo.collider.transform.position.x > gameObject.transform.position.x+2) {


										if (collisionInfo.collider.rigidbody != null) {	

		
				//		collisionInfo.collider.rigidbody.AddForce (collisionInfo.collider.transform.right * 200);

										}


								} else
				
					if (collisionInfo.collider.transform.position.x < gameObject.transform.position.x-2)
				{

		
										if (collisionInfo.collider.rigidbody != null) {	

				//		collisionInfo.collider.rigidbody.AddForce (collisionInfo.collider.transform.right * -200);



						
						
					}
			
								}

						} else {


								this.gameObject.rigidbody.useGravity = true;

			

						}




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
			
		//	gameObject.transform.Translate (Vector3.left * 0.45f);
			
			
					
		} 
		else
		{
			
		//	gameObject.transform.Translate (Vector3.left * -0.45f);
			
			
			}




	
	}
	
	Quaternion firstrot;

	public GameObject explosion;
	



	public int delay=0;


	public bool gameover;



	float speed;


	public GameObject obstaclemaker;




	int distance;


	public GameObject carbody;

	// Use this for initialization



	public  float updateInterval = 0.5F;
	
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left




	void FixedUpdate () {



	
		Camera.main.backgroundColor = Color.Lerp (Color.gray,new Color(0.8f,0.8f,0.8f,1), Mathf.PingPong (Time.time, 50) / 50);

		RenderSettings.fogColor=Color.Lerp (Color.gray,new Color(0.8f,0.8f,0.8f,1), Mathf.PingPong (Time.time, 50) / 50);


		if (gameover) 
		{

		//	Camera.main.transform.rotation=Quaternion.Lerp(this.transform.rotation,secrot,0.001f*Time.deltaTime);


			Camera.main.transform.RotateAround (this.transform.position, Vector3.up, 10 * Time.deltaTime);
		

		
			if(Camera.main.transform.position.z<-28)
			{
			Camera.main.transform.Translate(Vector3.forward*0.05f);

			Camera.main.transform.Translate(Vector3.down*0.05f);
			}


		}



		distance=distance+(int)(speed+0.8f);












	



	
		speed = obstaclemaker.GetComponent<Obstacle> ().speed;

		

		nitros.startSize = 0.3f+speed/4;


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



	public GameObject smokeparticle,sparkparticle,missile;

	GameObject fmiss;

	bool fire=false;

	public bool firepress=false;


	public GameObject wheelset;








	// Update is called once per frame
	void Update () {




		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 )
		{
			// display two fractional digits (f2 format)
			float fps = accum/frames;
			//string format = System.String.Format("{0:F2} FPS",fps);
			//		guiText.text = format;
			
			
			
			score.text = ""+fps;
			
			
			//	DebugConsole.Log(format,level);
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}
		








		for (int j=0; j<carbody.renderer.materials.Length; j++) 
		carbody.renderer.materials [j].SetVector ("_QOffset", obstaclemaker.GetComponent<Obstacle> ().curvect);




		for(int i=0;i<wheelset.transform.childCount;i++)
//		for(int i=0;i<3;i++)
		{

			for(int j=0;j<wheelset.transform.GetChild(i).renderer.materials.Length;j++)
//			for(int j=0;j<3;j++)
			{

				wheelset.transform.GetChild(i).renderer.materials [j].SetVector ("_QOffset", obstaclemaker.GetComponent<Obstacle> ().curvect);



			}

		}



		if (Input.GetButtonDown ("Fire1")) {
			
						RaycastHit hit;
			
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			
						if (Physics.Raycast (ray, out hit)) {
				
								//Debug.Log("Hit point: " + hit.point);
				
				
				
				
				
								if (hit.collider.name.Equals ("Fire")) {
										fire = true;

										firepress = true;
								} else {
										firepress = false;
								}
				
				
				
						} else {
								firepress = false;

						}
			
			
			
			
		}

		if(Input.GetKey("up"))
		{
			fire=true;
		}

		if (fire) {

			if(fmiss==null)
			fmiss=Instantiate (missile, this.transform.position+new Vector3(0,1.2f,-2), Quaternion.Euler(Vector3.zero)) as GameObject;
			


			fmiss.transform.GetChild(0).Rotate(fmiss.transform.GetChild(0).forward*10);


			for(int i=0;i<fmiss.transform.GetChild(0).transform.childCount;i++)
			{

				for(int j=0;j<fmiss.transform.GetChild(0).transform.GetChild(i).renderer.materials.Length;j++)
					//			for(int j=0;j<3;j++)
				{
					fmiss.transform.GetChild(0).transform.GetChild(i).renderer.materials [j].SetVector ("_QOffset", obstaclemaker.GetComponent<Obstacle> ().curvect);
				
					fmiss.transform.GetChild(0).transform.GetChild(i).GetComponent<TrailRenderer>().materials[j].SetVector ("_QOffset", obstaclemaker.GetComponent<Obstacle> ().curvect);

				}



			}


			fmiss.transform.Translate(fmiss.transform.forward*2);


			//fmiss.transform.GetChild(0).RotateAround(fmiss.transform.GetChild(3).position,Vector3.forward,Time.deltaTime*400);

				}

		if(fmiss!=null)
			if (fmiss.transform.position.z > 150) 
		{


			fire=false;

			Destroy(fmiss);

			fmiss.transform.position=this.transform.position;

			fmiss=null;

		

		/*	for(int i=0;i<4;i++)
			{
			
		//	missile.transform.GetChild (i).transform.rigidbody.velocity = Vector3.zero;
			
			missile.transform.GetChild (i).transform.position = Vector3.zero;
			


			//curo.transform.GetChild (j).transform.position = new Vector3 (child [j].x, child [j].y, child [j].z);


			}

			missile.transform.position=new Vector3(0,0,0);

*/
		}


		


		if (!gameover) {
						if (this.transform.position.y < 0.65f) {

								this.transform.position = new Vector3 (this.transform.position.x, 0.66f, this.transform.position.z);

								this.transform.rigidbody.angularVelocity = Vector3.zero;

								this.transform.rigidbody.velocity = Vector3.zero;

								this.transform.rotation = Quaternion.identity;

								this.gameObject.rigidbody.useGravity = false;

						}

						this.transform.rigidbody.angularVelocity = Vector3.zero;
		
						this.transform.rigidbody.velocity = Vector3.zero;
				}


		if (gameover) {

			if(delay<1)
			{
		
				audio.Stop();

		
				/*
				collider.rigidbody.AddForce (Vector3.up * 52);

				collider.rigidbody.AddForce (Vector3.forward * 52);


				collider.rigidbody.AddTorque (Vector3.up * 152);
				
				collider.rigidbody.AddTorque (Vector3.forward * 152);

*/


	
			}

						delay += 1;
		
			smokeparticle.renderer.enabled = true;

		}else
			delay=0;
		
	
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
	

	

		if (this.transform.position.z > -15f&&!gameover)
		//	transform.Translate (Vector3.forward*-0.05f);
			transform.rigidbody.AddForce(Vector3.forward*-0.5f);

		iPx = Input.acceleration.x;
		
		




		if (this.transform.position.x < 4.8f && this.transform.position.x > -6.6f)
			isallowed = true;
		else
			isallowed = false;




		if (Input.touchCount >0)
			touch = Input.touches [0];
		
		

		
		if (gameover == false&&firepress==false) {	
						if (Input.GetKey (KeyCode.RightArrow) || (touch.position.x > Screen.width / 2 && Input.touchCount > 0)) {
								left = true;
								right = false;
			
				audio.pitch-=0.001f;

		//		obstaclemaker.GetComponent<Obstacle> ().speed-=0.0025f;



			
						} else
		if (Input.GetKey (KeyCode.LeftArrow) || (touch.position.x < Screen.width / 2 && Input.touchCount > 0)) {
								left = false;
								right = true;

				audio.pitch-=0.001f;


		//		if(speed>obstaclemaker.GetComponent<Obstacle> ().latestspeed-3)
		//		obstaclemaker.GetComponent<Obstacle> ().speed-=0.0025f;

			
						} else {
								left = false;
								right = false;
			
				 
				if(audio.pitch<2.0f+speed-0.4f)
					audio.pitch+=0.01f;


		//		obstaclemaker.GetComponent<Obstacle> ().speed=obstaclemaker.GetComponent<Obstacle> ().latestspeed;

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

	
		rotateDegrees = 0f;
		
		float srotateDegrees = 0f;
		
		if(left)
		{
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

		if (this.transform.position.x < -5.8f) 
		{
//						this.transform.position = this.transform.position - new Vector3 (-0.15f, 0, 0);


			this.transform.position = new Vector3 (-5.8f, this.transform.position.y, this.transform.position.z);


		}


		
		//if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
		if(left||right)
		{    
			newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -5, 6f);
			rotateDegrees = newAngle - angleBetween;
		


			this.transform.RotateAround(piv2.transform.position,Vector3.up,rotateDegrees);
		

		//	carbody.transform.RotateAround(this.transform.position,Vector3.forward,rotateDegrees);


		//	this.transform.rotation=Quaternion.Slerp(this.transform.rotation,Quaternion.Euler(new Vector3(0,0,0)),Time.time*0.01f);



//			print ("speed "+speed);


			if(left)
			{
				carbody.transform.localRotation=Quaternion.Slerp(carbody.transform.localRotation,Quaternion.Euler(new Vector3(0,0,-5/2)),Time.time*speed/15);
			

//				this.transform.rotation=Quaternion.Lerp(piv2.transform.localRotation,Quaternion.Euler(new Vector3(0,15,0)),Time.time*0.05f);

			}
			else
			{
				carbody.transform.localRotation=Quaternion.Slerp(carbody.transform.localRotation,Quaternion.Euler(new Vector3(0,0,5/2)),Time.time*speed/15);

			
//				this.transform.rotation=Quaternion.Lerp(piv2.transform.localRotation,Quaternion.Euler(new Vector3(0,-15,0)),Time.time*0.05f);

			}


		}
		else
		{
			newAngle = Mathf.Clamp(angleBetween/2 + srotateDegrees/2, -20, 20);
			srotateDegrees = newAngle/2 - angleBetween;
		

			this.transform.RotateAround(piv1.transform.position,Vector3.up,srotateDegrees/6);

		//	carbody.transform.RotateAround(this.transform.position,Vector3.forward,srotateDegrees/(6*2));




		//	this.transform.localRotation=Quaternion.Slerp(piv1.transform.localRotation,Quaternion.Euler(new Vector3(0,0,0)),Time.time*0.5f);



			carbody.transform.localRotation=Quaternion.Slerp(carbody.transform.localRotation,Quaternion.Euler(new Vector3(0,0,0)),Time.time*speed/15);

			carbody.transform.localPosition=new Vector3(-3.035522f,carbody.transform.localPosition.y,carbody.transform.localPosition.z);



		}
		

	}







}