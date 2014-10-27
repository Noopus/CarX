using UnityEngine;
using System.Collections;

public class MenuGui : MonoBehaviour {


	Vector3 sd;



	public GameObject logoobj,soundobj;


	public GameObject storeoptions,firstscreen,specscreen,powerupscreen,buycashscreen;

	public GameObject multiplierscreen,nitroscreen,weaponscreen,transplane;


	Renderer[] storerenderers,fsrenderers,specrenderer,pwsrenderers,buycashrenderers;

	Renderer[] multiplierrenderers,nitrorenderers,weaponsrenderers;


	Renderer transrend;

	// Use this for initialization
	void Start () {
	
	
	
	

		Vector3 inputPosition = Input.mousePosition; 
		
		
		
		Vector3 ray = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (0, Screen.height, Camera.main.transform.position.z + 15.5f));
		
		
		
		
		Vector3 logopos = ray;
		
		//		logopos.x = ray.x - renderer.bounds.size.x/2;
		
		
		logopos.x = ray.x + logoobj.renderer.bounds.size.x/2-4.3f;
		
		logopos.y = ray.y - logoobj.renderer.bounds.size.y/2+0.3f;

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



		pwsrenderers = powerupscreen.GetComponentsInChildren<Renderer>();
		
		
		foreach (Renderer r in pwsrenderers)
		{
			
			r.enabled = false;
			
		}




		buycashrenderers = buycashscreen.GetComponentsInChildren<Renderer>();
		
		
		foreach (Renderer r in buycashrenderers)
		{
			
			r.enabled = false;
			
		}






		multiplierrenderers = multiplierscreen.GetComponentsInChildren<Renderer>();
		
		
		foreach (Renderer r in multiplierrenderers)
		{
			
			r.enabled = false;
			
		}



		nitrorenderers = nitroscreen.GetComponentsInChildren<Renderer>();
		
		
		foreach (Renderer r in nitrorenderers)
		{
			
			r.enabled = false;
			
		}



		weaponsrenderers = weaponscreen.GetComponentsInChildren<Renderer>();
		
		
		foreach (Renderer r in weaponsrenderers)
		{
			
			r.enabled = false;
			
		}


		transrend = transplane.renderer;

		transrend.enabled = false;




	}
	
	// Update is called once per frame
	void Update () {
	


	


	//	print ("sc w :sc h : "+ray.x);





		if(Input.GetButtonDown("Fire1"))
		{


			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);




			RaycastHit[] hits;

			hits = Physics.RaycastAll(ray);

			int i = 0;


			while(i<hits.Length){
		//	if(Physics.Raycast(ray,out hit)){
		//	if(Physics.RaycastAll(ray,hits)){
			
				hit = hits[i];

				Debug.Log (hit.collider.gameObject.name);
		
				i++;

				//Race button
				if(hit.collider.name.Equals("race")&&hit.collider.renderer.enabled==true)
					Application.LoadLevel(1);






				//store button
				/////
				if(hit.collider.name.Equals("store")&&hit.collider.renderer.enabled==true)
				{

					transrend.enabled=true;

					//store renderers
					foreach (Renderer r in storerenderers)
					{
						
						r.enabled = true;
						
					}

					//first screen renderers
					foreach (Renderer r in fsrenderers)
					{
						
						r.enabled = false;
						
					}

					//specifications plane renderers
					foreach (Renderer r in specrenderer)
					{
						
						r.enabled = false;
						
					}

					
				}


				if(hit.collider.name.Equals("powerups")&&hit.collider.renderer.enabled==true)
				{

					//powerup renderers
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = true;
						
					}

					//store renderers
					foreach (Renderer r in storerenderers)
					{
						
						r.enabled = false;
						
					}



				}



				if(hit.collider.name.Equals("buycash")&&hit.collider.renderer.enabled==true)
				{

					//powerup renderers
					foreach (Renderer r in buycashrenderers)
					{
						
						r.enabled = true;
						
					}

					//store renderers
					foreach (Renderer r in storerenderers)
					{
						
						r.enabled = false;
						
					}




				}




				if(hit.collider.name.Equals("pwsback")&&hit.collider.renderer.enabled==true)
				{

					print("gobackpws");

					//store renderers
					foreach (Renderer r in storerenderers)
					{
						
						r.enabled = true;
						
					}



					//power ups screen renderers
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = false;
						
					}


				}



				if(hit.collider.name.Equals("buyback")&&hit.collider.renderer.enabled==true)
				{
					
					//store renderers
					foreach (Renderer r in storerenderers)
					{
						
						r.enabled = true;
						
					}
					
					
					
					//power ups screen renderers
					foreach (Renderer r in buycashrenderers)
					{
						
						r.enabled = false;
						
					}
					
					
				}




					
					
				if(hit.collider.name.Equals("storeback")&&hit.collider.renderer.enabled==true)
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

					transrend.enabled=false;

					
				}


				/*
				 * 
				 * inside powerups selection
				 * 
				 * 
				 *
                 */


				if(hit.collider.name.Equals("pmult")&&hit.collider.renderer.enabled==true)
				{
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = false;
						
					}
					foreach (Renderer r in multiplierrenderers)
					{
						
						r.enabled = true;
						
					}
								
				}



				if(hit.collider.name.Equals("multiback")&&hit.collider.renderer.enabled==true)
				{
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = true;
						
					}
					foreach (Renderer r in multiplierrenderers)
					{
						
						r.enabled = false;
						
					}
					
				}

				



				if(hit.collider.name.Equals("pweaps")&&hit.collider.renderer.enabled==true)
				{
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = false;
						
					}
					foreach (Renderer r in weaponsrenderers)
					{
						
						r.enabled = true;
						
					}
					
				}
				
				
				
				if(hit.collider.name.Equals("shotback")&&hit.collider.renderer.enabled==true)
				{
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = true;
						
					}
					foreach (Renderer r in weaponsrenderers)
					{
						
						r.enabled = false;
						
					}
					
				}





				if(hit.collider.name.Equals("pnos")&&hit.collider.renderer.enabled==true)
				{
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = false;
						
					}
					foreach (Renderer r in nitrorenderers)
					{
						
						r.enabled = true;
						
					}
					
				}
				
				
				
				if(hit.collider.name.Equals("nosback")&&hit.collider.renderer.enabled==true)
				{
					foreach (Renderer r in pwsrenderers)
					{
						
						r.enabled = true;
						
					}
					foreach (Renderer r in nitrorenderers)
					{
						
						r.enabled = false;
						
					}
					
				}


				

/*
 * 
 * 
 * 
*/




			}




		}




	}


	//Vector3 ray = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z - 2f));



}
