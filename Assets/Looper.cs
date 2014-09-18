using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {


	public GameObject clone,seclone,barline;


	public bool iscloned=false;



	Vector3 startpos;

	Vector3 pos,backpos,sbackpos,size,resetpos;

	// Use this for initialization


	float limit;


	GameObject barlne,srtlne;

	static bool turn = true;


	int counted=0;

	void Start () {
	
		startpos = this.transform.position;


		Renderer renderer = this.GetComponentInChildren< Renderer >();
		
		size = renderer.bounds.size;



		pos=new Vector3(0,0,size.z);


		resetpos=new Vector3(0,this.transform.position.y,2*size.z-0.4f);


		backpos=new Vector3(0,0,-size.z);


		sbackpos=new Vector3(0,0,-2*size.z);





		barlne = Instantiate(barline, new Vector3(0,0,-size.z+0.4f), transform.rotation) as GameObject;

		srtlne = Instantiate(barline, new Vector3(0,this.transform.position.y,2*size.z-0.4f), transform.rotation) as GameObject;

		barlne.transform.parent = gameObject.transform.parent;
		
		srtlne.transform.parent = gameObject.transform.parent;


		GameObject instance = Instantiate(clone, pos, transform.rotation) as GameObject;

		GameObject instance2 = Instantiate(clone, backpos, transform.rotation) as GameObject;


		instance.transform.parent = gameObject.transform.parent;

		instance2.transform.parent = gameObject.transform.parent;



	
	}


	// Update is called once per frame
	void Update () {
		           

		print ("this is resetpos : "+counted);

	//	if (transform.position.z > -size.z+0.4f) 

	//	resetpos=new Vector3(0,this.transform.position.y,transform.position.z+2*size.z-0.4f);


		if(turn)
		{


			if(counted>3)
				turn=false;


			if (transform.position.z > barlne.transform.position.z) 
	     {	
			transform.Translate (Vector3.forward * -0.4f);
		 }
		else
		{
		//	transform.position=resetpos;
			transform.position=srtlne.transform.position;

				counted+=1;

	//		this.gameObject=seclone;

		}


		}

	
	}
}
