﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {
	
	
	
	public GameObject ob1,ob2,player;
	


	GameObject curob;

	Vector3 spawnpos;
	
	
	Vector3 size;
	
	Transform firstpos;
	
	Renderer rende;
	
	
	Vector3[] childpos,ob1pos,ob2pos;










	// Use this for initialization
	void Start () {
		
		

		childpos = new Vector3[10];


		ob1pos = new Vector3[6];

		ob2pos = new Vector3[6];

		
		ob1=Instantiate (ob1, new Vector3(player.transform.position.x,0,150), transform.rotation) as GameObject;
		

		ob2=Instantiate (ob2, new Vector3(player.transform.position.x,0,150), transform.rotation) as GameObject;


		
		
		curob = ob1;

		
		
		spawnpos = curob.transform.position;
		
		
		
		rende = curob.GetComponentInChildren<Renderer> ();
		
		
		size = rende.bounds.size;
		
		
		
		firstpos = curob.transform;
		




	
		
		for (int j = 0; j < ob1.transform.childCount; j++)
		{
			//			prefab.transform.GetChild(j).transform.localPosition = prefabpos[j].localPosition;
			
	//		firstpos.transform.GetChild(j).transform.position=ob1.transform.GetChild(j).transform.position;

//			childpos[j]=curob.transform.GetChild(j).transform.position;

			ob1pos[j]=ob1.transform.GetChild(j).transform.position;

		}
		
		
		
		for (int j = 0; j < ob2.transform.childCount; j++)
		{
			//			prefab.transform.GetChild(j).transform.localPosition = prefabpos[j].localPosition;
			
			//		firstpos.transform.GetChild(j).transform.position=ob1.transform.GetChild(j).transform.position;
			
			ob2pos[j]=ob2.transform.GetChild(j).transform.position;
			
		}
		

		childpos = ob1pos;
		
		
		
	}
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		
		size = rende.bounds.size;
		
		
		
		
		//		if (ob1.transform.position.z < player.transform.position.z-5) 
		
		//		if (ob1.transform.position.z < -size.z) 



		print("cpos "+childpos[0].x+" firstpos "+curob.transform.GetChild(0).transform.position.x);


	


		if (curob.transform.position.z < player.transform.position.z - 4 * size.z) {
			
						//ob1.transform.position.Set(player.transform.position.x,player.transform.position.y,player.transform.position.z+50);
			
			
			
						//		spawnpos.x=Random.Range(-4,4);


			
			//			ResetObject (ob1);






			curob.transform.position = spawnpos;


			if(curob==ob1)
			{
				curob=ob2;


				childpos=ob2pos;


			}
			else
			{
				curob=ob1;
			
				childpos=ob1pos;

			}


			shuffleArray(childpos);


			for(int j=0;j<curob.transform.childCount;j++)

				curob.transform.GetChild(j).transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);



		} else 
		{
		
			curob.transform.Translate (Vector3.forward * -0.6f);

			for(int j=0;j<curob.transform.childCount;j++)
			curob.transform.GetChild (j).transform.Translate (Vector3.forward * -(0.01f+j/2));

			
		}
		
		
		
		
		
	}
	
	
	public Transform[] prefabpos,prefabinipos;
	// List of prefab childs.
	
	private List<Transform>[] prefabReferences;
	
	
	public void ResetObject(GameObject prefab)
	{
		
		
		//		prefabs = ob1.GetComponentsInChildren <GameObject>();
		
		//		Transform[] allChildren = GetComponentsInChildren<Transform>();
		
		
		prefabpos = curob.GetComponentsInChildren<Transform>();
		
		
		for (int i = 0; i < prefabpos.Length; i++)
		{
			Transform tmpPrefab = prefabpos[i];
			
			if (tmpPrefab.name == prefab.name)
			{
				
				
				

				for (int j = 0; j < tmpPrefab.transform.childCount; j++)
				{
					//			prefab.transform.GetChild(j).transform.localPosition = prefabpos[j].localPosition;
					
					prefab.transform.GetChild(j).transform.position = childpos[j];



				}
				
			}
			
			
		}
		
	}
	
	void shuffleArray(Vector3[] ar)
	{


		for (int i = ar.Length - 1; i > 0; i--)
		{
		
//			int index = rnd.nextInt(i + 1);

			int index=Random.Range(1,i);

			// Simple swap
			Vector3 a = ar[index];
			ar[index] = ar[i];
			ar[i] = a;
		}
	}
	
	
}
