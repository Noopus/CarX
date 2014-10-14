
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdvObstacle : MonoBehaviour {
	
	
	
	public GameObject player;
	
	

	Vector3[] par1pos,par2pos;
	
	
		
	
	
	public GameObject vehicle,vcar,vtruck;
	
	
	
	
	GameObject[] veh,veh2,car,truck,car2,truck2;


	GameObject parent1,parent2;





	Renderer[] renderers;



	public float speed=0.4f;



	int[] x;



	Vector3[] childpos,childpos2;






	public void Randomizer()
	{

		x[0] = Random.Range(0,2);

		x[1] = Random.Range(0,2);

		x[2] = Random.Range(0,2);

		x[3] = Random.Range(0,2);



	}



	int count;

	// Use this for initialization
	void Start () {

		x = new int[4];


		Randomizer ();
		

		speed = 0.8f;


		childpos = new Vector3[10];

		
		childpos2 = new Vector3[10];




		
		veh=new GameObject[4];

		veh2=new GameObject[4];



		car=new GameObject[4];

		truck=new GameObject[4];


		car2=new GameObject[4];
		
		truck2=new GameObject[4];



		par1pos = new Vector3[8];
		
		parent1 = new GameObject ();

		parent1.transform.position = new Vector3 (0,0,140);


		par2pos = new Vector3[8];

		parent2 = new GameObject ();
		
		parent2.transform.position = new Vector3 (0,0,200);



//		Renderer ren = parent1.AddComponent<MeshRenderer>(); // Add the rigidbody.




		
		for (int i=0; i<veh.Length; i++) 
		{


			veh [i] = Instantiate (vehicle, new Vector3 (3.7f - 3.2f * i, 0, 140), transform.rotation) as GameObject;





			car [i] = Instantiate (vcar, new Vector3 (3.7f - 3.2f * i, 0, 10*140), transform.rotation) as GameObject;


			truck [i] = Instantiate (vtruck, new Vector3 (3.7f - 3.2f * i, 0, 10*140), transform.rotation) as GameObject;


			par1pos[i]=veh[i].transform.position;



			veh[i].transform.parent = parent1.transform;
	
			Rigidbody gameObjectsRigidBody = veh[i].AddComponent<Rigidbody>(); // Add the rigidbody.
			
			gameObjectsRigidBody.mass = 5;
			
			gameObjectsRigidBody.useGravity=false;
			
			gameObjectsRigidBody.isKinematic=true;
	}
		
		



		childpos = par1pos;





		
		for (int i=0; i<veh2.Length; i++) 
		{
			
			
			veh2 [i] = Instantiate (vehicle, new Vector3 (3.7f - 3.2f * i, 0, 200), transform.rotation) as GameObject;
			
			
			
			
			
			car2 [i] = Instantiate (vcar, new Vector3 (3.7f - 3.2f * i, 0, 10*200), transform.rotation) as GameObject;
			
			
			truck2 [i] = Instantiate (vtruck, new Vector3 (3.7f - 3.2f * i, 0, 10*200), transform.rotation) as GameObject;
			
			
			par2pos[i]=veh2[i].transform.position;
			
			
			
			veh2[i].transform.parent = parent2.transform;
			
			Rigidbody gameObjectsRigidBody = veh2[i].AddComponent<Rigidbody>(); // Add the rigidbody.
			
			gameObjectsRigidBody.mass = 5;
			
			gameObjectsRigidBody.useGravity=false;
			
			gameObjectsRigidBody.isKinematic=true;
		}




		
		childpos = par2pos;


		
	

	
	}



	
	void setKin(GameObject curob)
	{
		
		for (int j=0; j<curob.transform.childCount; j++) {
			
			//			if(curob.transform.GetChild(j).transform.rigidbody!=null)
			//						curob.transform.GetChild (j).transform.rigidbody.isKinematic = false;
		}
		
	}
	
	
	
	void setGra(GameObject curob)
	{
		
		for (int j=0; j<curob.transform.childCount; j++) {
			
			
			
			curob.transform.GetChild (j).transform.rigidbody.useGravity=true;
		}



	}
	
	
	

	// Update is called once per frame
	void Update () {






		if (parent1.transform.position.z < player.transform.position.z) {

			parent1.transform.position = new Vector3 (0, 0,140);


			count++;

		//	Randomizer();








			for (int j=0; j<parent1.transform.childCount; j++) 
			{

			
				childpos[j]=new Vector3(3.7f - 3.2f * j, 0, parent1.transform.position.z);

			}


		
			reshuffle(childpos);





			for (int j=0; j<parent1.transform.childCount; j++) 
			{


		//		car[j].transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);


		//		truck[j].transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);



				veh[j].transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);



				
	//			parent1.transform.GetChild (j).transform.position=new Vector3(3.7f - 3.2f * j, 0, parent1.transform.position.z);






			}



			for(int i=0;i<4;i++)
			{

			
				veh[i].transform.parent=null;
			

			/*	if(count==2)
				{
					veh[i]=truck[i];
				}

				if(count==3)
				{

					veh[i]=car[i];

				}
				
				if(count==4)
				{
					
					veh[i]=truck[i];
					
				}
*/

				if(x[i]==0)
				{
					veh[i]=car[i];
				}
				else
					if(x[i]==1)
				{
			//		veh[i]=truck[i];
					veh[i]=car[i];
			
				}




				veh[i].transform.parent = parent1.transform;
				


			}



		}
		else 
		{
		
			parent1.transform.Translate (Vector3.forward * -speed);

			for (int j=0; j<parent1.transform.childCount; j++) 
			{
				
				
				parent1.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f + 0.05f * j + 0.15f * j + j * speed / 2000));


				
			}
			
			



		
		}









		if (parent2.transform.position.z < player.transform.position.z) {
			
			parent2.transform.position = new Vector3 (0, 0,140);
			
			
			count++;
			
			//Randomizer();
			
			
			for (int j=0; j<parent2.transform.childCount; j++) 
			{
				
				
				childpos2[j]=new Vector3(3.7f - 3.2f * j, 0, parent2.transform.position.z);
				
			}
			
			
			
		//	reshuffle(childpos2);
			
			
			
			
			
			for (int j=0; j<parent2.transform.childCount; j++) 
			{
				
				
				//		car[j].transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);
				
				
				//		truck[j].transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);
				
				
				
				veh2[j].transform.position=new Vector3(childpos2[j].x,childpos2[j].y,childpos2[j].z);
				
				
				
				
				//			parent1.transform.GetChild (j).transform.position=new Vector3(3.7f - 3.2f * j, 0, parent1.transform.position.z);
				
				
				
				
				
				
			}
			

			
			
			for(int i=0;i<4;i++)
			{
				
				
				veh2[i].transform.parent=null;
				
				
				/*	if(count==2)
				{
					veh[i]=truck[i];
				}

				if(count==3)
				{

					veh[i]=car[i];

				}
				
				if(count==4)
				{
					
					veh[i]=truck[i];
					
				}
*/
				
				if(x[i]==0)
				{
					veh2[i]=car2[i];
				}
				else
					if(x[i]==1)
				{
					veh2[i]=truck2[i];
				}
				
				
				
				
				veh2[i].transform.parent = parent2.transform;
				
				
				
			}
			
			
			
		}
		else 
		{
	
		
			parent2.transform.Translate (Vector3.forward * -speed);
			
			for (int j=0; j<parent2.transform.childCount; j++) 
			{
				
				
				parent2.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f + 0.05f * j + 0.15f * j + j * speed / 2000));
				
				
			}
			
		
			
			
			
			
		}













		print ("xa:"+x[0]+"xb:"+x[1]+"xc:"+x[2]+"xd:"+x[3]);

		
		
	}
	
	




	void reshuffle(Vector3[] obje)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < obje.Length; t++ )
		{
			
			Vector3 tmp = obje[t];
			
			int r = Random.Range(t, obje.Length);
			
			obje[t] = obje[r];
			
			obje[r] = tmp;
			
			
		}
	}
	
	
	
	void reset(GameObject curo,Vector3[] child,bool[] reg)
	{
		
	//	if (delay == 0) 
		{	
			for (int j=0; j<curo.transform.childCount; j++) {
				
				reg [j] = false;
				
				
				
				if (!curo.transform.GetChild (j).transform.rigidbody.isKinematic && curo.transform.GetChild (j).transform.rigidbody != null) {		
					
					curo.transform.GetChild (j).transform.rigidbody.velocity = Vector3.zero;
					
					curo.transform.GetChild (j).transform.rigidbody.angularVelocity = Vector3.zero;
					
					
				}
				
				
				
				
				curo.transform.GetChild (j).transform.position = new Vector3 (child [j].x, child [j].y, child [j].z);
				
				curo.transform.GetChild (j).transform.rotation = Quaternion.identity;
				
				
				
				
			}
			
		}
		
	}
	
	
	
}
