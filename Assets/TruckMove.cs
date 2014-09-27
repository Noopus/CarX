using UnityEngine;
using System.Collections;

public class TruckMove : MonoBehaviour {



	Vector3 inipos;


	// Use this for initialization
	void Start () 
	{
	


		inipos=this.transform.localPosition;


	}

	float speed=0.1f,conspeed=0.2f;





	// Update is called once per frame
	void Update () {



		if (this.transform.position.z > -50) 
		{

			if(this.transform.position.z>60)
			{	

				speed=0.1f+(float)Random.Range(0,2)*0.5f;
			
			    this.transform.localPosition=inipos;
			}

								this.transform.Translate (Vector3.forward * -speed);
	
		}

		else 
		{




	
	
		}




	}
}
