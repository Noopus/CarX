
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
	
	// Use this for initialization
	void Start () {
		

		speed = 0.4f;

		
		
		reg1=new bool[10];
		
		reg2=new bool[10];
		
		
		for (int r=0; r<reg1.Length; r++)
			reg1 [r] = false;
		
		for (int r=0; r<reg2.Length; r++)
			reg2 [r] = false;
		
		
		
		
		firstwave = true;
		
		
		
		childpos = new Vector3[10];
		
		childpos2 = new Vector3[10];
		
		
		
		ob1pos = new Vector3[ob1.transform.childCount];
		
		ob2pos = new Vector3[ob2.transform.childCount];
		
		
		ob1=Instantiate (ob1, new Vector3(player.transform.position.x,0,120), transform.rotation) as GameObject;
		
		ob2=Instantiate (ob2, new Vector3(player.transform.position.x,0,120), transform.rotation) as GameObject;
		
		
		
		
		curob = ob1;
		
		curob2 = ob2;
		
		
		
		
		
		val = 0;
		
		
		
		spawnpos = curob.transform.position;
		
		
		
		
		rende = curob.GetComponentInChildren<Renderer> ();
		
		rende2 = curob2.GetComponentInChildren<Renderer> ();
		
		
		size = rende.bounds.size;
		
		size2 = rende2.bounds.size;
		
		
		
		
		
		firstpos = curob.transform;
		
		
			for (int j = 0; j < ob1.transform.childCount; j++)
		{
			
			ob1pos[j]=ob1.transform.GetChild(j).transform.position;
			
		}
		
		
		
		for (int j = 0; j < ob2.transform.childCount; j++)
		{
			
			ob2pos[j]=ob2.transform.GetChild(j).transform.position;
			
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

//			if(curob.transform.GetChild(j).transform.rigidbody!=null)
//						curob.transform.GetChild (j).transform.rigidbody.isKinematic = false;
		}
		
	}
	
	
	
	void setGra(GameObject curob)
	{
		
		for (int j=0; j<curob.transform.childCount; j++) {
			
			
			
	//			curob.transform.GetChild (j).transform.rigidbody.useGravity=true;
		}
		
	}
	
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		delay = player.GetComponent<carMove> ().health;
		
		
		size = rende.bounds.size;
		
		
		size2 = rende2.bounds.size;
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		if (delay > 0) 
		{
			
					setKin (curob);
			
			setKin (curob2);


			setGra (curob);
			
			setGra (curob2);

			speed=-0.4f;

			
		}
		
		
		if (curob.transform.position.z < player.transform.position.z - 4 * size.z&&delay==0) {
			
			
			
			
			
			
			reset (curob, childpos,reg1);
			
			
			
			curob.transform.position = new Vector3(curob.transform.position.x,curob.transform.position.y,140);
			
			
			
			
			
			
			
			
			/*
			if(curob==ob1)
			{
				
				curob=ob2;
				
				childpos=new Vector3[ob2.transform.childCount];
				
				childpos=ob2pos;
				
				
			}
			else
			{
				
				curob=ob1;
				
				
				childpos=new Vector3[ob1.transform.childCount];
				
				
				childpos=ob1pos;
				
			}
		*/
			
			
			
			curob=ob1;
			
			
			reshuffle(childpos);
			
			
			
			
			for(int j=0;j<curob.transform.childCount;j++)
			{
				
				//				curob.transform.GetChild(j).transform.rigidbody.isKinematic = false;
				

				if(!curob.transform.GetChild(j).transform.rigidbody.isKinematic)
				
				{
					curob.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
				
				curob.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;
				
				}
				
				
				curob.transform.GetChild(j).transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);
				
				curob.transform.GetChild(j).transform.rotation=Quaternion.identity;
				
				
				
				
				
				//				curob.transform.GetChild(j).transform.rigidbody.Sleep( );
				
			}
			
			
			
			//			firstwave=false;
			
			
			
		} else 
		{
			
			if(firstwave)
			{
				
				
			//	if(delay==0)
					curob.transform.Translate (Vector3.forward * -speed);
				
				for(int j=0;j<curob.transform.childCount;j++)
				{
					
					curob.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f+0.05f*j+0.05f*j+j*speed/2000));
					
					if(curob.transform.GetChild (j).transform.position.z<player.transform.position.z&&curob.transform.GetChild (j).transform.position.y>0&&reg1[j]==false)
					{
						reg1 [j] = true;
						
						//						print ("hit is detected");
					
						time+=1;


						if(time==5+turntime)
						{

							if(speed<0.85f)
						speed+=0.05f;

						
							time=0;

							turntime+=3;


						}


					}
					
					
					
				}
			}
			
			
			
			
		}
		
		
		
		
		if (curob.transform.position.z < player.transform.position.z + 40) 
		{
			secondwave = true;
		}
		
		//		if (curob2.transform.position.z < player.transform.position.z + 4* size2.z)
		
		if (curob2.transform.position.z < player.transform.position.z + 70)
			firstwave = true;
		
		
		
		
		//		if (curob2.transform.position.z < player.transform.position.z - 4 * size.z)
		if (curob2.transform.position.z < player.transform.position.z - 4 * size.z&&delay==0)
			
		{
			
			
			
			curob2.transform.position = new Vector3(curob2.transform.position.x,curob2.transform.position.y,140);
			
			
			/*
			if(curob2==ob1)
			{
				
				curob2=ob2;
				
				childpos2=new Vector3[ob2.transform.childCount];
				
				childpos2=ob2pos;
				
				
			}
			else
			{
				
				curob2=ob1;
				
				
				childpos2=new Vector3[ob1.transform.childCount];
				
				
				childpos2=ob1pos;
				
			}




*/
			
			
			curob2=ob2;
			
			
			reshuffle(childpos2);
			
			
			
			
			for(int j=0;j<curob2.transform.childCount;j++)
			{	
				
				
				
				reset (curob2, childpos2,reg2);
				
				
				
				if(!curob2.transform.GetChild(j).transform.rigidbody.isKinematic&&(curob.transform.GetChild(j).transform.rigidbody!=null))
				{
					curob2.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
					
					curob2.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;
				}
				
				
				
				curob2.transform.GetChild(j).transform.position=new Vector3(childpos2[j].x,childpos2[j].y,childpos2[j].z);
				
				curob2.transform.GetChild(j).transform.rotation=Quaternion.Euler(Vector3.zero);
				
				
				//				curob2.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
				//			curob2.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;
				//			curob2.transform.GetChild(j).transform.rigidbody.Sleep( );
				
			}
			//			secondwave=false;
			
			
		} else 
		{
			
			
			
			if(secondwave)
			{
				
			//	if(delay==0)
					curob2.transform.Translate (Vector3.forward * -speed);
				
				for(int j=0;j<curob.transform.childCount;j++)
				{
					curob2.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f+0.05f*j+0.05f*j+j*speed/2000));
					
					
					if(curob2.transform.GetChild (j).transform.position.z<player.transform.position.z&&curob2.transform.GetChild (j).transform.position.y>0&&reg2[j]==false)
					{
						
						reg2 [j] = true;
						
						//					print ("hit is detected");
						
					}
					
					
					
				}
				
				
				
			}
			
		}
		
		
		
		
		
		
		if (delay == 50) {
			reset (curob, childpos,reg1);
			reset (curob2, childpos2,reg2);
			
		}
		
		
	}
	
	
	public Transform[] prefabpos,prefabinipos;
	// List of prefab childs.
	
	private List<Transform>[] prefabReferences;
	
	/*	
	public void ResetObject(GameObject prefab)
	{
		
		prefabpos = curob.GetComponentsInChildren<Transform>();
		
		
		for (int i = 0; i < prefabpos.Length; i++)
		{
			Transform tmpPrefab = prefabpos[i];
			
			if (tmpPrefab.name == prefab.name)
			{
				
				
				
				
				for (int j = 0; j < tmpPrefab.transform.childCount; j++)
				{
					prefab.transform.GetChild(j).transform.position = childpos[j];
					
					
					
				}
				
			}
			
			
		}
		
	}
*/
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
