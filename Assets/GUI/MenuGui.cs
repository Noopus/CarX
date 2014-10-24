using UnityEngine;
using System.Collections;

public class MenuGui : MonoBehaviour {


	Vector3 sd;



	public GameObject logoobj;


	// Use this for initialization
	void Start () {
	
	
	
	

		Vector3 inputPosition = Input.mousePosition; 
		
		
		
		Vector3 ray = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (0, Screen.height, Camera.main.transform.position.z + this.transform.position.z));
		
		
		
		
		Vector3 logopos = ray;
		
		//		logopos.x = ray.x - renderer.bounds.size.x/2;
		
		
		logopos.x = ray.x + logoobj.renderer.bounds.size.x/2-0.5f;
		
		logopos.y = ray.y - logoobj.renderer.bounds.size.y/2;
		
		
		
		logoobj.transform.position = logopos;


	}
	
	// Update is called once per frame
	void Update () {
	


	


	//	print ("sc w :sc h : "+ray.x);





		if(Input.GetButtonDown("Fire1"))
		{

			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


			if(Physics.Raycast(ray,out hit)){

				//Debug.Log("Hit point: " + hit.point);
			




				if(hit.collider.name.Equals("race"))
					Application.LoadLevel(1);





			}




		}




	}


	//Vector3 ray = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z - 2f));



}
