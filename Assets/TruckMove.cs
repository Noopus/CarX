using UnityEngine;
using System.Collections;

public class TruckMove : MonoBehaviour {



	Vector3 inipos;

	public GameObject player;

	// Use this for initialization
	void Start () 
	{
	


		inipos=this.transform.localPosition;


		inipos.y = player.transform.position.y;

		inipos.z = player.transform.position.z+150;



	

	}

	float speed=1.1f,conspeed=0.2f;





	// Update is called once per frame
	void Update () {


		/*
		if (this.transform.position.z > -50) 
		{

			if(this.transform.position.z>150)
			{	

		//		speed=0.1f+(float)Random.Range(0,2)*0.25f;
			
		//	    this.transform.localPosition=inipos;
			}

	
		}

		else 
		{




	
	
		}
*/



		if (this.transform.position.z < player.transform.position.z - 50) {
			
						//this.transform.position.Set(player.transform.position.x,player.transform.position.y,player.transform.position.z+50);
			
			
			
						inipos.x = Random.Range (-4, 4);
			
		
						this.transform.position = inipos;
			
			
				} else 
		{
		
			this.transform.Translate (Vector3.forward * -0.6f);

			this.transform.Translate (Vector3.left * -0.01f);

			
			print("Loopped here "+this.transform.position.z);

		}







	}
}
