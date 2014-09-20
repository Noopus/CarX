using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {


	public GameObject road,piv1,piv2;



	wheel scr;

	public bool parent=false;


	Transform pivot1,pivot2;




	public Vector3 iniangles,curangles;
	
	
	bool goleft,goright;
	
	
	float iPx;
	
	float rotation=0;




	// Use this for initialization


	void Start () {


		Vector3 inipos = new Vector3 (transform.position.x,road.transform.position.y-0.8f,transform.position.z);

		this.transform.position = inipos;

		scr=GetComponentInChildren<wheel>();




		pivot1 = GameObject.FindWithTag("pivot").GetComponent<Transform>();  



	}
	

	// Update is called once per frame


	void LateUpdate () {


	
		if (Input.GetKey ("left")) {
			
			goleft = true;
			goright = false;
			
			
		} else
		if (Input.GetKey ("right")) {
			goleft = false;
			goright = true;
			
		} 
		else 
		{
			goleft = false;
			goright = false;
			
		}
		
		
		
		
		
		
		if(goleft)
		{
			
			//	curangles.y -= 50*(3+Mathf.Abs(iPx)) * Time.deltaTime;
			

			if(rotation>0)
				rotation-=6;


			if(rotation>-20)
				rotation-=2;

		} else
			
			//	if (Input.GetKey (KeyCode.L)) {
			
			if(goright)
		{
			
			//	curangles.y += 50*(3+Mathf.Abs(iPx)) * Time.deltaTime;
			if(rotation<20)
			{
				rotation+=6;
		
				if(rotation<0)
					rotation+=4;

			}

			
		} else {
			
			/*			
			if (curangles.y < -0.01f)
				curangles.y += 60 * Time.deltaTime;
			if (curangles.y > 0.01f)
				curangles.y -= 60 * Time.deltaTime;
*/
			
			
			if(rotation<-0.5f)
			{
				rotation+=3;
			}
			else
				if(rotation>0.5f)
			{
				rotation-=3;
			}
			
			
		}
		
		
		
		curangles.y = Mathf.Sin (Mathf.Deg2Rad*rotation) * 20;





		if (parent == false) 
		{
		
		//	this.transform.localRotation = Quaternion.Euler (curangles);
		
//			this.transform.rotation=Quaternion.Euler(RotatePointAroundPivot(Vector3.zero,transform.position,curangles));

//			this.transform.rotation=

//			RotatePointAroundPivot(Vector3.forward,pivot1.position,Input.GetAxisRaw("Horizontal")*30);

			this.transform.RotateAround(piv1.transform.position,Vector3.forward,Input.GetAxisRaw("Horizontal")*30);

		//	this.transform.rotation= Quaternion.Euler (curangles);

		


		}		else {

/*
			if (Input.GetKey ("left"))
				this.transform.Translate (Vector3.left*0.1f);
			else
				if (Input.GetKey ("right"))
					this.transform.Translate (Vector3.left*-0.1f);
*/
				}




	
	}

	Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
		Vector3 dir = point - pivot; // get point direction relative to pivot
		dir = Quaternion.Euler(angles) * dir; // rotate it
		point = dir + pivot; // calculate rotated point

		return point; // return it
	}

}
