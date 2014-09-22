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

	void Update () {


	

		iPx = Input.acceleration.x;
		
		
		
		
		
		if (Input.GetKey (KeyCode.K)||iPx<-0.05f)
	//	if(Input.GetKey(KeyCode.K))
		{
			goleft = true;
			goright = false;
			
		} else
				if (Input.GetKey (KeyCode.L)||iPx>0.05f) 
	//		if(Input.GetKey(KeyCode.L))
		{
			goleft = false;
			goright = true;
			
		} else {
			goleft=false;
			goright=false;
			
		}
		



		if (parent == false) 
		{









		
		//	this.transform.localRotation = Quaternion.Euler (curangles);
		
	//		this.transform.rotation=Quaternion.Euler(RotatePointAroundPivot(Vector3.up,transform.position,curangles));




		


	//		this.transform.rotation=Quaternion.Euler(RotatePointAroundPivot(this.transform.position,piv1.transform.position,curangles));

	//		transform.Rotate(curangles, Space.World);







			if(piv1.transform.position.z<-9.8f)
				transform.Translate(Vector3.forward*0.05f);
      





			float rotateDegrees = 0f;
		
			float srotateDegrees = 0f;

	//		if (Input.GetKey(KeyCode.LeftArrow))
				if(goleft)
			{
	

				rotateDegrees -= 2*rotateSpeed * Time.deltaTime;
				
				lastrot=rotateDegrees;
				

			

			}
			else 
			//	if (Input.GetKey(KeyCode.RightArrow))
				if(goright)

			{

				rotateDegrees += 2*rotateSpeed * Time.deltaTime;
				
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
				newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -10, 10);
			    rotateDegrees = newAngle - angleBetween;
				this.transform.RotateAround(piv2.transform.position,Vector3.up,rotateDegrees);

			}
			else
			{
				newAngle = Mathf.Clamp(angleBetween/2 + srotateDegrees/2, -10, 10);
			    srotateDegrees = newAngle/2 - angleBetween;
				this.transform.RotateAround(piv1.transform.position,Vector3.up,srotateDegrees/10);

			}





		




	





		//	this.transform.rotation= Quaternion.Euler (curangles);

		


		}		else {


			float accx;

			accx=Mathf.Abs(iPx);

		//	if (Input.GetKey ("left"))
			if(goleft)
			{	
			
				this.transform.Translate (Vector3.left*(accx-0.05f));
			}
			else
//				if (Input.GetKey ("right"))
				if(goright)
			{
			
				this.transform.Translate (Vector3.left*-(accx-0.05f));
			}
		

				}


	


	
	}


	float speed=0.08f;


}
