using UnityEngine;
using System.Collections;

public class MenuGui : MonoBehaviour {


	Vector3 sd;



	public GameObject logoobj,soundobj;


	public GameObject storeoptions,firstscreen,specscreen,powerupscreen;



	Renderer[] storerenderers,fsrenderers,specrenderer;



	// Use this for initialization
	void Start () {
	
	
	
	

		Vector3 inputPosition = Input.mousePosition; 
		
		
		
		Vector3 ray = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (0, Screen.height, Camera.main.transform.position.z + 15.5f));
		
		
		
		
		Vector3 logopos = ray;
		
		//		logopos.x = ray.x - renderer.bounds.size.x/2;
		
		
		logopos.x = ray.x + logoobj.renderer.bounds.size.x/2-4f;
		
		logopos.y = ray.y - logoobj.renderer.bounds.size.y/2+0.1f;

//		logopos.z = ray.z;
		
		
		logoobj.transform.position = logopos;





		Vector3 sray = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z + 15.5f));


		Vector3 soundpos = sray;
		
		//		logopos.x = ray.x - renderer.bounds.size.x/2;
		
		
		soundpos.x = sray.x - soundobj.renderer.bounds.size.x/2-0.5f;
		
		soundpos.y = sray.y - soundobj.renderer.bounds.size.y/2-0.5f;
		
		//		logopos.z = ray.z;
		
		
		soundobj.transform.position = soundpos;




		storerenderers = storeoptions.GetComponentsInChildren<Renderer>();


		foreach (Renderer r in storerenderers)
		{
		
			r.enabled = false;
		
		}


		fsrenderers = firstscreen.GetComponentsInChildren<Renderer>();
		
		
		foreach (Renderer r in fsrenderers)
		{
			
			r.enabled = true;
			
		}


		specrenderer = specscreen.GetComponentsInChildren<Renderer>();
		
		
		foreach (Renderer r in specrenderer)
		{
			
			r.enabled = true;
			
		}






	}
	
	// Update is called once per frame
	void Update () {
	


	


	//	print ("sc w :sc h : "+ray.x);





		if(Input.GetButtonDown("Fire1"))
		{

			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


			if(Physics.Raycast(ray,out hit)){

			
		

				if(hit.collider.name.Equals("race")&&hit.collider.renderer.enabled==true)
					Application.LoadLevel(1);







				if(hit.collider.name.Equals("store")&&hit.collider.renderer.enabled==true)
				{
					
					foreach (Renderer r in storerenderers)
					{
						
						r.enabled = true;
						
					}

					foreach (Renderer r in fsrenderers)
					{
						
						r.enabled = false;
						
					}

					foreach (Renderer r in specrenderer)
					{
						
						r.enabled = false;
						
					}

					
				}

                
				if(hit.collider.name.Equals("back")&&hit.collider.renderer.enabled==true)
				{
					foreach (Renderer r in storerenderers)
					{
						
						r.enabled = false;
						
					}
					
					foreach (Renderer r in fsrenderers)
					{
						
						r.enabled = true;
						
					}

					foreach (Renderer r in specrenderer)
					{
						
						r.enabled = true;
						
					}



				}








			}




		}




	}


	//Vector3 ray = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z - 2f));



}
