using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {



	public GameObject ob1,player;


	Vector3 spawnpos;

	// Use this for initialization
	void Start () {

		ob1=Instantiate (ob1, new Vector3(0,1,50), transform.rotation) as GameObject;


		spawnpos = ob1.transform.position;


	
	}





	
	// Update is called once per frame
	void Update () {


	

	
		if (ob1.transform.position.z < player.transform.position.z-5) 
		{

			//ob1.transform.position.Set(player.transform.position.x,player.transform.position.y,player.transform.position.z+50);



			spawnpos.x=Random.Range(-4,4);

			ob1.transform.position=spawnpos;


		}
		else
			ob1.transform.Translate (Vector3.forward*-0.5f);






	}
}
