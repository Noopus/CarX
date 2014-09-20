using UnityEngine;
using System.Collections;

public class ParentLooper : MonoBehaviour {
	

	Looper loop;


	public GameObject first;


	Vector3 pos,size;


	void Start () {
		
		loop=gameObject.GetComponentInChildren<Looper>();


		size = renderer.bounds.size;



		pos=new Vector3(this.transform.position.x,this.transform.position.y,-1220);



		GameObject instance = Instantiate(first, pos, transform.rotation) as GameObject;


	}
	
	
	// Update is called once per frame



	void Update () {

	
      if (loop.nextturn==false) 
		{


			transform.Translate (Vector3.forward * -0.4f);


		}



//	if(loop.turn==false)
	
		
		
	}
}
