
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
	



	public GameObject newlooperscript;
	
	// Use this for initialization
	void Start () {
		


		firstwave = true;


		
		childpos = new Vector3[10];
		
		childpos2 = new Vector3[10];



		ob1pos = new Vector3[ob1.transform.childCount];
		
		ob2pos = new Vector3[ob2.transform.childCount];
		
		
		ob1=Instantiate (ob1, new Vector3(player.transform.position.x,0,120), transform.rotation) as GameObject;
		
		ob2=Instantiate (ob2, new Vector3(player.transform.position.x,0,120), transform.rotation) as GameObject;
		
		
		
		
		curob = ob1;

		curob2 = ob2;

		
		
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
		
		
	}
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		
		size = rende.bounds.size;


		size2 = rende2.bounds.size;




		if (curob.transform.position.z < player.transform.position.z - 4 * size.z) {
			
		
			
			curob.transform.position = new Vector3(curob.transform.position.x,curob.transform.position.y,120);
			
			
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


				curob.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
				
				curob.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;




				curob.transform.GetChild(j).transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);

				curob.transform.GetChild(j).transform.rotation=Quaternion.identity;

			

			

				//				curob.transform.GetChild(j).transform.rigidbody.Sleep( );

			}



//			firstwave=false;

			
			
		} else 
		{

			if(firstwave)
			{

			curob.transform.Translate (Vector3.forward * -0.9f);
			
			for(int j=0;j<curob.transform.childCount;j++)
				{

					curob.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f+0.05f*j+0.05f*j));
				
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
		if (curob2.transform.position.z < player.transform.position.z - 4 * size.z)

		{
			
			
			
			curob2.transform.position = new Vector3(curob2.transform.position.x,curob2.transform.position.y,120);
			
			
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


				curob2.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
				
				curob2.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;




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
			

				curob2.transform.Translate (Vector3.forward * -0.9f);
			
			for(int j=0;j<curob.transform.childCount;j++)
				{
						curob2.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.045f+0.05f*j+0.05f*j));
				}
			
			}
			
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
	
	
	
	
}
