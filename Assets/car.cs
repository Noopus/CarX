using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {


	public GameObject road,piv1,piv2;



	wheel scr;

	public bool parent=false;






	public Vector3 iniangles,curangles;
	
	
	bool goleft,goright;
	
	
	float iPx;
	
	float rotation=0;










	public float rotateSpeed = 280.0f;


	
	private Vector3 initialVector = Vector3.forward;


	// Use this for initialization


	Vector3 inipos;

	void Start () {




		initialVector = transform.position - piv1.transform.position;

		initialVector.y = 0;




		inipos = new Vector3 (transform.position.x,road.transform.position.y-0.8f,transform.position.z);

		this.transform.position = inipos;

		scr=GetComponentInChildren<wheel>();




	}
	

	// Update is called once per frame


	float lastrot;


	float accx;
	


	float rotateDegrees = 0f;


	float smoother=1;


	float delay=0;


	void Update () {


	

		iPx = Input.acceleration.x;
		


		if(Mathf.Abs(iPx)<1f)
		accx=Mathf.Abs(iPx);

		
		
		if (Input.GetKey (KeyCode.K)||iPx<-0.1f)
	//	if(Input.GetKey(KeyCode.K))
		{
			goleft = true;
			goright = false;

			if(delay<1)
				delay+=0.001f;

			if(delay<0)
			delay+=0.005f;



			smoother+=0.001f;
	
		} else
				if (Input.GetKey (KeyCode.L)||iPx>0.1f) 
	//		if(Input.GetKey(KeyCode.L))
		{
			goleft = false;
			goright = true;


			if(delay>0)
				delay-=0.005f;


			if(delay>-1)
				delay-=0.001f;

			smoother+=0.001f;
		} else {
			goleft=false;
			goright=false;

			smoother=0;

			delay=0;
		}
		



		if (parent == false) 
		{




			if(piv1.transform.position.z<-12.8f)
				transform.Translate(Vector3.forward*0.05f);
      





			rotateDegrees = 0f;
		
			float srotateDegrees = 0f;

	//		if (Input.GetKey(KeyCode.LeftArrow))
				if(goleft)
			{
	

			

				rotateDegrees -= rotateSpeed* Time.deltaTime+accx;
				
				lastrot=rotateDegrees;
				

			

			}
			else 
			//	if (Input.GetKey(KeyCode.RightArrow))
				if(goright)

			{

			

				rotateDegrees += rotateSpeed * Time.deltaTime+accx;
				
				lastrot=rotateDegrees;

			}
		else
			{

			


			}







//			Vector3 currentVector = transform.position - piv1.transform.position;

			Vector3 currentVector;


	//		if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
			if(goleft||goright)
				currentVector =  piv2.transform.position-transform.position;
           else
				currentVector = transform.position - piv1.transform.position;


			//			currentVector.y = 0;


			float angleBetween;


			angleBetween= Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).y > 0 ? 1 : -1);
  



			float newAngle;




			//if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
			if(goleft||goright)
			{	
				newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -8, 8);
			    rotateDegrees = newAngle - angleBetween;
				this.transform.RotateAround(piv2.transform.position,Vector3.up,rotateDegrees);

			}
			else
			{
				newAngle = Mathf.Clamp(angleBetween/2 + srotateDegrees/2, -8, 8);
			    srotateDegrees = newAngle/2 - angleBetween;
				this.transform.RotateAround(piv1.transform.position,Vector3.up,srotateDegrees/10);

			}





		




	





		//	this.transform.rotation= Quaternion.Euler (curangles);

		


		}		else {


		
		//	if (Input.GetKey ("left"))
			if(goleft)
			{	
			
//				if(delay>0.01f)
		this.transform.Translate (Vector3.left*((accx-0.1f)));
	
	//			this.transform.Translate (Vector3.left*(0.2f));

			}
			else
//				if (Input.GetKey ("right"))
				if(goright)
			{
			
//				if(delay<-0.01f)
				this.transform.Translate (Vector3.left*-((accx-0.1f)));
		
		//		this.transform.Translate (Vector3.left*-(0.2f));
			
			}
		


		
				}


		print ("this is : "+smoother);



	
	}


	float speed=0.08f;


}
