using UnityEngine;
using System.Collections;

public class wheel : MonoBehaviour 
{


	public Texture nrmltex,dmgtex;


	public GameObject parent,wheel1,wheel2;




	int delay;


	float yval=0;


	// Use this for initialization
	void Start () 
	{
	
	


	}

	Vector3 iniangles,curangles;


	
	// Update is called once per frame
	void Update () 
	{
	
		delay=parent.GetComponent<carRotate> ().delay;



		
	//	iniangles = wheel1.transform.eulerAngles;


	



		if(delay>0)
		renderer.material.SetTexture("_MainTex", dmgtex);


		if (parent.GetComponent<carRotate> ().left) {
			
			curangles.y += 100 * Time.deltaTime;
		
		} else
			if (parent.GetComponent<carRotate> ().right) {
			
			curangles.y -= 100* Time.deltaTime;
		
		} else {
			if (curangles.y < -0.01f)
				curangles.y += 120 * Time.deltaTime;
			if (curangles.y > 0.01f)
				curangles.y -= 120 * Time.deltaTime;

				}

		/*
		yval = ClampAngle( yval, 40, -40 );


	//	Quaternion newRot = Quaternion.Euler( 0, yval, 0 );


		Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.left);


		wheel1.transform.rotation= Quaternion.Slerp(transform.rotation, newRotation, 5f);     

		wheel2.transform.rotation= Quaternion.Slerp(transform.rotation, newRotation, 5f);     

//		wheel1.transform.rotation = newRot;

//		wheel2.transform.rotation = newRot;


*/





		/*


		if (parent.GetComponent<carRotate> ().left) 
		{

						wheel1.transform.Rotate (0, 50*Time.deltaTime, 0);
		
			
			wheel2.transform.Rotate (0, 50*Time.deltaTime, 0);


		} 
	

		else
			if (parent.GetComponent<carRotate> ().right) {

			wheel1.transform.Rotate (0, -50*Time.deltaTime, 0);

			wheel2.transform.Rotate (0, -50*Time.deltaTime, 0);

		}

*/




		curangles.x=0;
		
		curangles.y=Mathf.Clamp(curangles.y,-10,10);
		
		curangles.z=0;
		
		
		
		wheel1.transform.eulerAngles=iniangles+curangles;

		wheel2.transform.eulerAngles=iniangles+curangles;





	}


	float ClampAngle( float angle, float min, float max )
	{
		if ( angle < -360 )
			angle += 360;
		if ( angle > 360 )
			angle -= 360;
		
		return Mathf.Clamp( angle, min, max );
	}





}
