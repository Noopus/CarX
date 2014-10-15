
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {
	
	
	
	public GameObject ob1,ob2,player;
	
	
	
	GameObject curob,curob2;
	
	Vector3 spawnpos;
	
	
	Vector3 size,size2;
	
	Transform firstpos;
	
	Renderer rende,rende2;
	
	
	Vector3[] childpos,childpos2,ob1pos,ob2pos;
	
	
	
	
	
	
	bool firstwave=false,secondwave=false;
	
	
	
	
	
	
	
	int delay;
	
	
	
	
	bool start=false;
	
	
	int val;
	
	
	bool[] reg1,reg2;
	
	
	
	public float speed,time=0,turntime=0;
	
	
	/// <summary>
	/// ///////////////
	/// </summary>
	
	
	Vector3[] par1pos,par2pos;
	
	
	
	
	
	public GameObject vehicle,vcar,vtruck;
	
	
	
	
	GameObject[] veh,veh2,car,truck,car2,truck2;
	
	
	/////////
	/// 
	/// 
	/// 
	
	
	
	// Use this for initialization




	int[] x,x2;
	
	
		
	public void Randomizer(int[] x)
	{
		
		x[0] = Random.Range(0,2);
		
		x[1] = Random.Range(0,2);
		
		x[2] = Random.Range(0,2);
		
		x[3] = Random.Range(0,2);
		
		
		
	}





	
	void Start () {
		
		x=new int[4];
		
		x2=new int[4];



		speed = 0.4f;
		
		
		//////////////
		
		
		
		
		
		
		veh=new GameObject[4];
		
		veh2=new GameObject[4];
		
		
		
		car=new GameObject[4];
		
		truck=new GameObject[4];
		
		
		car2=new GameObject[4];
		
		truck2=new GameObject[4];
		
		
		
		par1pos = new Vector3[8];
		
		curob = new GameObject ();
		
		curob.transform.position = new Vector3 (0,0,140);
		
		
		par2pos = new Vector3[8];
		
		curob2 = new GameObject ();
		
		curob2.transform.position = new Vector3 (0,0,140);
		
		

		
		for (int i=0; i<veh.Length; i++) 
		{
			
			
			veh [i] = Instantiate (vehicle, new Vector3 (3.7f - 3.2f * i, 0, 140), transform.rotation) as GameObject;
			
			
			
			
			
			car [i] = Instantiate (vcar, new Vector3 (3.7f - 3.2f * i, 0, 10*140), transform.rotation) as GameObject;
			
			
			truck [i] = Instantiate (vtruck, new Vector3 (3.7f - 3.2f * i, 0, 10*140), transform.rotation) as GameObject;
			
			
			
			//    veh[i]=truck[i];
			
			
			par1pos[i]=veh[i].transform.position;
			
			
			
			veh[i].transform.parent = curob.transform;


			BoxCollider col=veh[i].AddComponent<BoxCollider>();



			/*
			Rigidbody gameObjectsRigidBody = veh[i].AddComponent<Rigidbody>(); // Add the rigidbody.
			
			
			
			gameObjectsRigidBody.mass = 5;
			
			gameObjectsRigidBody.useGravity=false;
			
			gameObjectsRigidBody.isKinematic=true;
*/




		}
		
		
		
		
		
		for (int i=0; i<veh2.Length; i++) 
		{
			
			
			veh2 [i] = Instantiate (vehicle, new Vector3 (3.7f - 3.2f * i, 0, 140), transform.rotation) as GameObject;
			
			
			
			
			
			car2 [i] = Instantiate (vcar, new Vector3 (3.7f - 3.2f * i, 0, 10*140), transform.rotation) as GameObject;
			
			
			truck2 [i] = Instantiate (vtruck, new Vector3 (3.7f - 3.2f * i, 0, 10*140), transform.rotation) as GameObject;
			
			
			par2pos[i]=veh2[i].transform.position;
			
			
			
			veh2[i].transform.parent = curob2.transform;

			BoxCollider col=veh2[i].AddComponent<BoxCollider>();

		/*	Rigidbody gameObjectsRigidBody = veh2[i].AddComponent<Rigidbody>(); // Add the rigidbody.
			
			gameObjectsRigidBody.mass = 5;
			
			gameObjectsRigidBody.useGravity=false;
			
			gameObjectsRigidBody.isKinematic=true;


*/






		}
		
		
		
		
		
		////////////
		
		
		reg1=new bool[10];
		
		reg2=new bool[10];
		
		
		for (int r=0; r<reg1.Length; r++)
			reg1 [r] = false;
		
		for (int r=0; r<reg2.Length; r++)
			reg2 [r] = false;
		
		
		
		
		firstwave = false;

		secondwave = true;
		
		
		childpos = new Vector3[10];
		
		childpos2 = new Vector3[10];
		
		
		
		ob1pos = new Vector3[ob1.transform.childCount];
		
		ob2pos = new Vector3[ob2.transform.childCount];
		
		
		ob1=Instantiate (ob1, new Vector3(player.transform.position.x,0,120), transform.rotation) as GameObject;
		
		ob2=Instantiate (ob2, new Vector3(player.transform.position.x,0,120), transform.rotation) as GameObject;
		
		

		val = 0;
		
		
		
		spawnpos = curob.transform.position;
		
		
		
		
		rende = curob.GetComponentInChildren<Renderer> ();
		
		rende2 = curob2.GetComponentInChildren<Renderer> ();
		
		
		size = rende.bounds.size;
		
		size2 = rende2.bounds.size;
		
		
		
		
		
		firstpos = curob.transform;
		
		
		for (int j = 0; j < curob.transform.childCount; j++)
		{
			
			ob1pos[j]=curob.transform.GetChild(j).transform.position;
			
		}
		
		
		
		for (int j = 0; j < curob2.transform.childCount; j++)
		{
			
			ob2pos[j]=curob2.transform.GetChild(j).transform.position;
			
		}
		
		
		childpos = ob1pos;
		
		
		childpos2 = ob2pos;
		
		
		
		
		reset (curob, childpos,reg1);


		reset (curob2, childpos2,reg2);
		
		
		
		
		setKin (curob);
		
		setKin (curob2);
		
		
	}
	
	
	void setKin(GameObject curob)
	{
		
		for (int j=0; j<curob.transform.childCount; j++) {
			
			     //       if(curob.transform.GetChild(j).transform.rigidbody!=null)
			    //                    curob.transform.GetChild (j).transform.rigidbody.isKinematic = false;
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
		
		
		delay = player.GetComponent<carMove> ().health;
		
		
		
		
		
		
		
		if (delay > 0) 
		{
			
			setKin (curob);
			
			setKin (curob2);
			
			
			setGra (curob);
			
			setGra (curob2);
			
			    speed=-0.2f;
			
			
			speed=0;
		}
		
		
		if (curob.transform.position.z < player.transform.position.z - 4 * size.z&&delay==0) {
			
			
			
			
			
			
			reset (curob, childpos,reg1);
			
			
			
			curob.transform.position = new Vector3(curob.transform.position.x,curob.transform.position.y,150);
			
			
			
			
			Randomizer(x);
			
			
			//    curob=ob1;
			
			
			    reshuffle(childpos);
			
			
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
				
				
				
				reset (curob, childpos,reg1);
				
				
		//		if(i>1)






				if(x[i]==0)
				{
					veh[i]=car[i];
			
				}
				else
				if(x[i]==1)
				{
					veh[i]=truck[i];
				}




				
				
				//		veh[i]=car[i];
				
				
				
				
				veh[i].transform.parent = curob.transform;
				
				
				reset (curob, childpos,reg1);
				
				
			}




			
			for(int j=0;j<curob.transform.childCount;j++)
			{
				
				//                curob.transform.GetChild(j).transform.rigidbody.isKinematic = false;
				
				
				if(!curob.transform.GetChild(j).transform.rigidbody.isKinematic)
					
				{
					curob.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
					
					curob.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;
					
				}
				
				
				curob.transform.GetChild(j).transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);
				
				//        curob.transform.GetChild(j).transform.rotation=Quaternion.identity;
				
				
				
				
				
				//                curob.transform.GetChild(j).transform.rigidbody.Sleep( );
				
			}
			
			
			
			//            firstwave=false;
			





			
		} else 
		{
			
			if(firstwave)
			{
			/*	
				
				//    if(delay==0)
				curob.transform.Translate (Vector3.forward * -speed);
				
				for(int j=0;j<curob.transform.childCount;j++)
				{
					
					
					
					if(delay==0)
						curob.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f+0.05f*j+0.05f*j+j*speed/1000));
					else
						if(curob.transform.GetChild (j).transform.position.z<player.transform.position.z)
					{
						
						curob.transform.GetChild (j).transform.Translate (Vector3.forward *-(0.045f+0.05f*j+0.05f*j+j*speed/2000));
						
					}
					else
					{
						
						if(j==0)
							curob.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*1+0.03f*1+1*speed/2000));
						
						curob.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*j+0.03f*j+j*speed/2000));
						
					}
					
					
					
					
					
					
					if(curob.transform.GetChild (j).transform.position.z<player.transform.position.z&&reg1[j]==false)
					{
						reg1 [j] = true;
						
						                        print ("hit is detected");
						
						time+=1;
						
						
						if(time==5)
						{
							
							if(speed<0.9f)
		
							speed+=0.1f;
							
							
							time=0;
							
							turntime+=3;
							
							
						}
						
						
					}
					
					
					
				}

*/
			}
			
			
			
			
		}
		
		
		
		
		if (curob.transform.position.z < player.transform.position.z + 40) 
		{
			secondwave = true;
		}
		
		//        if (curob2.transform.position.z < player.transform.position.z + 4* size2.z)
		
		if (curob2.transform.position.z < player.transform.position.z + 70)
			firstwave = true;
		
		
		
		
		//        if (curob2.transform.position.z < player.transform.position.z - 4 * size.z)
		if (curob2.transform.position.z < player.transform.position.z - 4 * size.z&&delay==0)
			
		{
			
			
			
			curob2.transform.position = new Vector3(curob2.transform.position.x,curob2.transform.position.y,150);
			
			
			
			
			//    curob2=ob2;
			
			
			reshuffle(childpos2);



			Randomizer(x2);


			for(int i=0;i<4;i++)
			{
				
				
				veh2[i].transform.parent=null;
				

				
				reset (curob2, childpos2,reg1);
				
				
				//		if(i>1)
				
				
				
				if(x2[i]==0)
				{
					veh2[i]=car2[i];
					
				}
				else
					if(x2[i]==1)
				{
					veh2[i]=truck2[i];
				}
				
				
				
				
				
				
				//		veh[i]=car[i];
				
				
				
				
				veh2[i].transform.parent = curob2.transform;
				
				
				reset (curob2, childpos2,reg2);
				
				
			}
			
			


			
			
			
			for(int j=0;j<curob2.transform.childCount;j++)
			{    
				
				
				
				reset (curob2, childpos2,reg2);
				
				
				
				if(!curob2.transform.GetChild(j).transform.rigidbody.isKinematic&&(curob.transform.GetChild(j).transform.rigidbody!=null))
				{
					curob2.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
					
					curob2.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;
				}
				
				
				
				
				
			}
			
			
		} else 
		{
			
			
			
			if(secondwave)
			{
				
				//    if(delay==0)
	




				curob2.transform.Translate (Vector3.forward * -speed);



				for(int j=0;j<curob.transform.childCount;j++)
				{
					
					if(delay==0)
						curob2.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f+0.05f*j+0.05f*j+j*speed/1000));
					else
						if(curob2.transform.GetChild (j).transform.position.z<player.transform.position.z)
					{
						
						curob2.transform.GetChild (j).transform.Translate (Vector3.forward * (0.045f+0.05f*j+0.05f*j+j*speed/2000));
						
					}
					else
					{
						
						if(j==0)
							curob2.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*1+0.03f*1+1*speed/2000));
						
						curob2.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*j+0.03f*j+j*speed/2000));
						
					}
					
					
					if(curob2.transform.GetChild (j).transform.position.z<player.transform.position.z&&curob2.transform.GetChild (j).transform.position.y>0&&reg2[j]==false)
					{
						
						reg2 [j] = true;
						
						//                    print ("hit is detected");
						
					}
					
					
					
				}
				
				
				
			}
			
		}
		
		
		
		
//		print ("xa:"+x[0]+"xb:"+x[1]+"xc:"+x[2]+"xd:"+x[3]);

		
		if (delay == 50) {
			reset (curob, childpos,reg1);
			reset (curob2, childpos2,reg2);
			
		}
		
		
	}
	
	
	public Transform[] prefabpos,prefabinipos;
	// List of prefab childs.
	
	private List<Transform>[] prefabReferences;
	

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
		
		if (delay == 0) {    
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