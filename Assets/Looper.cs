using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {


	public GameObject clone,seclone,endbar,startbar;


	public bool iscloned=false,nextturn=true;



	Vector3 startpos;




	Vector3 pos,backpos,sbackpos,size,resetpos;

	// Use this for initialization


	float limit,roadspeed=0.4f;


//	GameObject barlne,srtlne;

	static bool turn = true;



	public int counted=0;


	GameObject instance,instance2,instance3;


	GameObject bluecountry,bluecountry2,bluecountry3;



	GameObject[] inst;


	int speed;


	void Start () {


		inst=new GameObject[6];
	

		startpos = this.transform.position;


		Renderer renderer = this.GetComponentInChildren< Renderer >();
		
		size = renderer.bounds.size;



		pos=new Vector3(0,0,size.z);


		resetpos=new Vector3(0,this.transform.position.y,2*size.z-roadspeed);


		backpos=new Vector3(0,0,-size.z);


		sbackpos=new Vector3(0,0,-2*size.z);





//		barlne = Instantiate(barline, new Vector3(0,0,-size.z+roadspeed), transform.rotation) as GameObject;

//		srtlne = Instantiate(barline, new Vector3(0,this.transform.position.y,2*size.z-roadspeed), transform.rotation) as GameObject;


//		barlne = Instantiate(barline, new Vector3(0,0,-size.z+roadspeed), transform.rotation) as GameObject;
		
//		srtlne = Instantiate(barline, new Vector3(0,this.transform.position.y,2*size.z-roadspeed), transform.rotation) as GameObject;

		endbar.transform.position = new Vector3 (0, 0, -size.z + roadspeed);

		startbar.transform.position = new Vector3 (0, this.transform.position.y, 2*size.z - roadspeed);





//		barlne.transform.parent = gameObject.transform.parent;
		
//		srtlne.transform.parent = gameObject.transform.parent;


//		if (clone != null) 
		{
		

			for(int i=0;i<6;i++)
			{


				if(i==0||i==3)
				{
				
					if(i==0)
					inst[i] = Instantiate (clone, Vector3.zero, transform.rotation) as GameObject;
				else
							if(i==3)
							inst[i] = Instantiate (seclone, Vector3.zero, transform.rotation) as GameObject;


				}
				else
					if(i==1||i==4)
				{	
				
					if(i==1)
					inst[i] = Instantiate (clone, pos, transform.rotation) as GameObject;
					else
						if(i==4)
							inst[i] = Instantiate (seclone, pos, transform.rotation) as GameObject;

				}
				else if(i==2||i==5)
				{
				
					if(i==2)
					inst[i] = Instantiate (clone, backpos, transform.rotation) as GameObject;
				else
							if(i==5)
								inst[i] = Instantiate (seclone, backpos, transform.rotation) as GameObject;

		}

				inst[i].transform.parent=this.transform.parent;


				if(i==3||i==4||i==5)
					inst[i].SetActive(false);
				else
					inst[i].SetActive(true);



			}






			/*





			instance = Instantiate (clone, this.transform.position, transform.rotation) as GameObject;

			instance2 = Instantiate (clone, pos, transform.rotation) as GameObject;

			instance3 = Instantiate (clone, backpos, transform.rotation) as GameObject;


			bluecountry = Instantiate (seclone, Vector3.zero, transform.rotation) as GameObject;
			
			bluecountry2 = Instantiate (seclone, instance2.transform.position, transform.rotation) as GameObject;

			bluecountry3 = Instantiate (seclone, instance3.transform.position, transform.rotation) as GameObject;




			instance.transform.parent = gameObject.transform.parent;

			instance2.transform.parent = gameObject.transform.parent;




			bluecountry.transform.parent = gameObject.transform.parent;
			
			bluecountry2.transform.parent = gameObject.transform.parent;

			bluecountry3.transform.parent = gameObject.transform.parent;


			bluecountry.SetActive(false);

			bluecountry2.SetActive(false);

			bluecountry3.SetActive(false);

			instance.SetActive(false);

			instance2.SetActive(false);

			instance3.SetActive(false);
			*/
				}
	
	}


	// Update is called once per frame
	void Update () {
		           

	//	print ("this is resetpos : "+counted);

	//	if (transform.position.z > -size.z+roadspeed) 

	//	resetpos=new Vector3(0,this.transform.position.y,transform.position.z+2*size.z-roadspeed);


		if (turn)
			nextturn = true;
				else
			nextturn = false;




		if(turn)
		{





			for(int i=0;i<6;i++)
			{
				

				
			


				if (inst[i].transform.position.z > endbar.transform.position.z) 
				{	

					inst[i].transform.Translate (Vector3.forward * -roadspeed);
				


				}
				else
				{
					//	transform.position=resetpos;
					inst[i].transform.position=startbar.transform.position;
					
					counted+=1;



				

					if(counted<10||counted>30)
					{
					if(i==3||i==4||i==5)
						inst[i].SetActive(true);
					else

						inst[i].SetActive(false);
					}
					else if(counted>10&&counted<30)
					{
					if(i==0||i==1||i==2)
						inst[i].SetActive(true);
					else
						inst[i].SetActive(false);

					}

					//		this.gameObject=seclone;
					
				}

				
				
			}



			if(counted>90)
			{




				turn=false;
			



			}



			if(Input.GetKey("p"))
				roadspeed=2;
			else
				roadspeed=0.4f;
		

		}

	
	}
}
