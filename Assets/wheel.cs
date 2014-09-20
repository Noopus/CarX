using UnityEngine;
using System.Collections;

public class wheel : MonoBehaviour 
{



	public Vector3 iniangles,curangles;


	bool goleft,goright;
	
	
	float iPx;

	float rotation=0;

	// Use this for initialization
	void Start () 
	{
	
		iniangles = transform.eulerAngles;
		
		curangles = Vector3.zero;


	}
	
	// Update is called once per frame
	void Update () 
	{
	
		iPx = Input.acceleration.x;




		if (Input.GetKey ("left")) {

						goleft = true;
						goright = false;


				} else
		if (Input.GetKey ("right")) {
						goleft = false;
						goright = true;

				} else 
		{
			goleft = false;
			goright = false;

		}






		if(goleft)
		{

		//	curangles.y -= 50*(3+Mathf.Abs(iPx)) * Time.deltaTime;

			if(rotation>-40)
				rotation-=4;
			


		} else
			
			//	if (Input.GetKey (KeyCode.L)) {
			
			if(goright)
		{
		
		//	curangles.y += 50*(3+Mathf.Abs(iPx)) * Time.deltaTime;

			if(rotation<40)
				rotation+=4;



		} else {
			
/*			
			if (curangles.y < -0.01f)
				curangles.y += 60 * Time.deltaTime;
			if (curangles.y > 0.01f)
				curangles.y -= 60 * Time.deltaTime;
*/


			if(rotation<-0.5f)
			{
				rotation+=2;
			}
else
				if(rotation>0.5f)
			{
				rotation-=2;
			}


		}



		curangles.y = Mathf.Sin (Mathf.Deg2Rad*rotation) * 20;




//		curangles.x=Mathf.Clamp(curangles.x,-25,25);
		
//		curangles.y=Mathf.Clamp(curangles.y,-20,20);
		
//		curangles.z=Mathf.Clamp(curangles.z,-25,25);
		
		
		
		transform.eulerAngles=iniangles+curangles;


		print ("this is wheel : "+rotation);



	}




}
