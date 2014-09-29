using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {



	public GameObject ob1,player;


	Vector3 spawnpos;


	Vector3 size;

	Transform firstpos;

	Renderer rende;




	// Use this for initialization
	void Start () {




		ob1=Instantiate (ob1, new Vector3(0,1,150), transform.rotation) as GameObject;





		spawnpos = ob1.transform.position;



	    rende = ob1.GetComponentInChildren<Renderer> ();


		size = rende.bounds.size;


	
		firstpos = ob1.transform;


		for (int j = 0; j < 2; j++)
		{
			//			prefab.transform.GetChild(j).transform.localPosition = prefabpos[j].localPosition;
			
			firstpos.transform.GetChild(j).transform.position=ob1.transform.GetChild(j).transform.position;
			
		}








	}





	
	// Update is called once per frame
	void Update () {



		size = rende.bounds.size;

	

	
//		if (ob1.transform.position.z < player.transform.position.z-5) 

//		if (ob1.transform.position.z < -size.z) 

			if (ob1.transform.position.z < player.transform.position.z-2*size.z) 
		{

			//ob1.transform.position.Set(player.transform.position.x,player.transform.position.y,player.transform.position.z+50);



	//		spawnpos.x=Random.Range(-4,4);


			ResetObject(ob1);

			ob1.transform.position=spawnpos;


		}
		else
			ob1.transform.Translate (Vector3.forward*-0.6f);






	}


	public Transform[] prefabpos,prefabinipos;
	// List of prefab childs.

	private List<Transform>[] prefabReferences;


	public void ResetObject(GameObject prefab)
	{

	    
//		prefabs = ob1.GetComponentsInChildren <GameObject>();

//		Transform[] allChildren = GetComponentsInChildren<Transform>();


		prefabpos = ob1.GetComponentsInChildren<Transform>();


		for (int i = 0; i < prefabpos.Length; i++)
		{
			Transform tmpPrefab = prefabpos[i];
			
			if (tmpPrefab.name == prefab.name)
			{



				print("Loopped");

				for (int j = 0; j < tmpPrefab.transform.childCount; j++)
				{
		//			prefab.transform.GetChild(j).transform.localPosition = prefabpos[j].localPosition;
				
					prefab.transform.GetChild(j).transform.position = firstpos.transform.GetChild(j).transform.position;
				
				}

			}


		}

	}




}
