﻿using UnityEngine;
using System.Collections;

public class NewLooper : MonoBehaviour {
	
	
	
	
	public GameObject player,go1,go2,go3,go4,go5,go6,obstaclemaker;
	
	

	GameObject g1,g2,g3,g4,g5,g6;



	
	GameObject[] gobs;
	
	
	Vector3 size;
	
	
	
	int sizeofarray;


	int delay;





	Vector3 curvect;

	// Use this for initialization
	void Start () {

		delay = player.GetComponent<carMove> ().health;


		curvect = new Vector3 (0,0,0);


		sizeofarray = 4*6;


		gobs = new GameObject[sizeofarray];
		
		speed = 1f;



		speed = obstaclemaker.GetComponent<Obstacle> ().speed;






//		sizeofarray = 4;



		
		Renderer renderer = go1.GetComponent< Renderer >();
		
		size = renderer.bounds.size;
		
		
		
		Vector3 firstpos, secondpos,thirdpos,fourthpos;
		
		firstpos = new Vector3 (0,0,0);
		
		secondpos = new Vector3 (0,0,firstpos.z+size.z-speed);
		
		thirdpos = new Vector3 (0,0,secondpos.z+size.z);
		
		fourthpos = new Vector3 (0,0,thirdpos.z+size.z);


		/*
        g1=Instantiate (go1, firstpos, transform.rotation) as GameObject;


        g2=Instantiate (go2, secondpos, transform.rotation) as GameObject;

        g3=Instantiate (go2, thirdpos, transform.rotation) as GameObject;

    //    g3.GetComponent<Renderer> ().sharedMaterial.color.g = 0.9f;

        g3.renderer.material.color = Color.white;

    //    size.z = size.z / 2;

*/
		
	
		
		
		for (int i=0; i<sizeofarray; i++) 
		{
			
			float j=(float)i;
			
	/*		
			if(i==0||i==2)
				gobs [i] = Instantiate (go1, firstpos, transform.rotation) as GameObject;
			
			if(i==1||i==3)
			{
				gobs [i] = Instantiate (go2, secondpos, transform.rotation) as GameObject;
				
			}
	*/





		

		
			if(i>=0&&i<4)
			{

				if(i==0)
				gobs [i] = Instantiate (go1, firstpos, transform.rotation) as GameObject;
				else
					if(i==1)
				gobs [i] = Instantiate (go1, secondpos, transform.rotation) as GameObject;
				else
					if(i==2)
						gobs [i] = Instantiate (go1, thirdpos, transform.rotation) as GameObject;
				else
					if(i==3)
						gobs [i] = Instantiate (go1, fourthpos, transform.rotation) as GameObject;




//				gobs [0] = Instantiate (go1, firstpos, transform.rotation) as GameObject;
			    
//				gobs [1] = Instantiate (go1, secondpos, transform.rotation) as GameObject;

//				gobs [2] = Instantiate (go1, thirdpos, transform.rotation) as GameObject;


			}
			if(i>=4&&i<8)
			{

//				gobs [i] = Instantiate (go2, secondpos, transform.rotation) as GameObject;


					if(i==4)
						gobs [i] = Instantiate (go2, secondpos, transform.rotation) as GameObject;
				else
					if(i==5)
						gobs [i] = Instantiate (go2, thirdpos, transform.rotation) as GameObject;
				else
					if(i==6)
						gobs [i] = Instantiate (go2, thirdpos, transform.rotation) as GameObject;
				else
					if(i==7)
						gobs [i] = Instantiate (go2, fourthpos, transform.rotation) as GameObject;




			}

			if(i>=8&&i<12)
			{


				if(i==8)
					gobs [i] = Instantiate (go3, firstpos, transform.rotation) as GameObject;
				else
					if(i==9)
						gobs [i] = Instantiate (go3, secondpos, transform.rotation) as GameObject;
				else
					if(i==10)
						gobs [i] = Instantiate (go3, thirdpos, transform.rotation) as GameObject;
				else
					if(i==11)
						gobs [i] = Instantiate (go3, fourthpos, transform.rotation) as GameObject;

			}



			if(i>=12&&i<16)
			{
				
				
				if(i==12)
					gobs [i] = Instantiate (go4, firstpos, transform.rotation) as GameObject;
				else
					if(i==13)
						gobs [i] = Instantiate (go4, secondpos, transform.rotation) as GameObject;
				else
					if(i==14)
						gobs [i] = Instantiate (go4, thirdpos, transform.rotation) as GameObject;
				if(i==15)
					gobs [i] = Instantiate (go4, fourthpos, transform.rotation) as GameObject;

			}


			if(i>=16&&i<20)
			{
				
				
				if(i==16)
					gobs [i] = Instantiate (go5, firstpos, transform.rotation) as GameObject;
				else
					if(i==17)
						gobs [i] = Instantiate (go5, secondpos, transform.rotation) as GameObject;
				else
					if(i==18)
						gobs [i] = Instantiate (go5, thirdpos, transform.rotation) as GameObject;
				else
					if(i==19)
						gobs [i] = Instantiate (go5, fourthpos, transform.rotation) as GameObject;

			}



			if(i>=20&&i<24)
			{
				
				
				if(i==20)
					gobs [i] = Instantiate (go6, firstpos, transform.rotation) as GameObject;
				else
					if(i==21)
						gobs [i] = Instantiate (go6, secondpos, transform.rotation) as GameObject;
				else
					if(i==22)
						gobs [i] = Instantiate (go6, thirdpos, transform.rotation) as GameObject;
				else
					if(i==23)
						gobs [i] = Instantiate (go6, fourthpos, transform.rotation) as GameObject;

			}






	//		gobs[i].renderer.material.shader = Shader.Find("Custom/Curved");


	//		renderer.material.SetFloat("Distance", 5);





		
		



//			if(i>sizeofarray/3-1)

			if(i>3)
			gobs[i].SetActive(false);





			
			/*
            gobs[0].renderer.material.color = new Color(0.7f,0.7f,0);

            if(gobs[1]!=null)
            gobs[1].renderer.material.color = new Color(0.7f,0.3f,0.5f);

            if(gobs[2]!=null)
            gobs[2].renderer.material.color = new Color(0.7f,0.7f,1f);


            if(gobs[3]!=null)
                gobs[3].renderer.material.color = new Color(0.3f,0.7f,0);
            
            if(gobs[4]!=null)
                gobs[4].renderer.material.color = new Color(0.3f,0.7f,0.5f);
            
            if(gobs[5]!=null)
                gobs[5].renderer.material.color = new Color(0.1f,0.1f,1f);

*/
			
			
			
		}
		
		size.z -= 1;


//		InvokeRepeating ("LoopStage",0.0001f,0.0001f);
	
	
	
	

	}
	
	
	
	float speed,counter;
	
	// Update is called once per frame
	void Update () 

//	void LoopStage()
	{
		
		
		
		delay = player.GetComponent<carMove> ().health;




		speed = 0.9f+obstaclemaker.GetComponent<Obstacle> ().speed;




		
		
		size.x = 0;
		
		
		size.y = 0;
		
		
		/*
        if (gobs[0].transform.position.z < -size.z )
            gobs[0].transform.position = gobs[2].transform.position + size;
        
        
        if (gobs[1].transform.position.z < -size.z )
            gobs[1].transform.position = gobs[0].transform.position + size;
        
        
        if (gobs[2].transform.position.z < -size.z )
            gobs[2].transform.position = gobs[1].transform.position + size;
*/
		
		
		
		
		
		for (int i=0; i<sizeofarray; i++) 
		{
			
			/*
            if (gobs [0].transform.position.z < -size.z)
            gobs [0].transform.position = gobs [2].transform.position + size;
            
            
            if (gobs [1].transform.position.z < -size.z)
            gobs [1].transform.position = gobs [0].transform.position + size;
            
            
            if (gobs [2].transform.position.z < -size.z)
            gobs [2].transform.position = gobs [1].transform.position + size;
        */    
			
			
			int arraypos=i-1;
			
			if(arraypos<0)
				arraypos=(int)sizeofarray-1;
			
			
			int nextpos=arraypos;
			
			if (gobs[i].transform.position.z < -size.z)
			{
				
				if(i==0)
				{
					
					counter++;
					

					
		//			print ("counter is : "+counter);

				}
				
				
				if(counter==3*2)
				{
					if(i>=0&&i<4)
						gobs[i].SetActive(true);
					else
						
						gobs[i].SetActive(false);
				}
				else if(counter==6*2)
				{
					
					if(i>=4&&i<8)
						gobs[i].SetActive(true);
					else
						gobs[i].SetActive(false);
				}
				else if(counter==9*2)
				{
					
					if(i>=8&&i<12)
						gobs[i].SetActive(true);
					else
						gobs[i].SetActive(false);
				}
				else if(counter==12*2)
				{
					
					if(i>=12&&i<16)
						gobs[i].SetActive(true);
					else
						gobs[i].SetActive(false);
				}
				else if(counter==15*2)
				{
					
					if(i>=16&&i<20)
						gobs[i].SetActive(true);
					else
						gobs[i].SetActive(false);
				}




				if(counter>15*2)
					counter=0;



				
				/*
                if(counter<5||counter>10)
                {
					if(i>=3&&i<6)
						gobs[i].SetActive(true);
                    else
                        
                        gobs[i].SetActive(false);
                }
                else if(counter>5&&counter<10)
                {
                
					if(i>=0&&i<3)
						gobs[i].SetActive(true);
                    else
                        gobs[i].SetActive(false);
                }


				*/
				
				
				gobs[i].transform.position = gobs[nextpos].transform.position + size;
				
			}
			
			
			
			
			
			
		}
		
		
		
		
		
		
		for (int i=0; i<sizeofarray; i++) 
		{
			
			
			/*
            int arraypos=i-1;
            
            if(arraypos<0)
                arraypos=2;
            
            
            int nextpos=arraypos;

            if (gobs[i].transform.position.z < -size.z )
                gobs[i].transform.position = gobs[nextpos].transform.position + size;

            */
			
			
			
			
			if(gobs[i].transform.position.z>65&&gobs[i].transform.position.y>-0.0005f)
				gobs[i].transform.Translate(Vector3.up*-0.00001f);
			else
				if(gobs[i].transform.position.z<2&&gobs[i].transform.position.y<0.1f)
					gobs[i].transform.Translate(Vector3.up*0.01f);
			
			
			
			
			
			int arraypos=i-1;
			
			if(arraypos<0)
				arraypos=(int)sizeofarray-1;
			
			
			int nextpos=arraypos;
			
			
			
			
			
			if(delay==0)
			gobs[i].transform.Translate (Vector3.forward*-speed*1.2f);


			
			/*
            int curpos=i;

            int arraypos=i-1;

            if(arraypos<0)
                arraypos=2;


            int nextpos=arraypos;
*/
			
			
			
			
		}
		
		
		/*
        g1.transform.Translate (Vector3.forward*-speed);

        g2.transform.Translate (Vector3.forward*-speed);

        g3.transform.Translate (Vector3.forward*-speed);


        size.x = 0;
        size.y = 0;




        if (g1.transform.position.z < -size.z )
            g1.transform.position = g3.transform.position + size;
    

        if (g2.transform.position.z < -size.z)
            g2.transform.position = g1.transform.position + size;




        if (g3.transform.position.z < -size.z)
            g3.transform.position = g2.transform.position + size;




*/




		
		
		if (Input.GetKey ("p"))
			speed += 0.02f;



		for (int i=0; i<sizeofarray; i++)
		for (int j=0; j<gobs[i].renderer.materials.Length; j++) 
		{
		
		//	gobs [i].renderer.materials [j].SetFloat ("_Dist", counter);

		


			gobs [i].renderer.materials [j].SetVector("_QOffset", obstaclemaker.GetComponent<Obstacle> ().curvect);


			gobs [i].renderer.materials [j].SetFloat ("_Dist", 8);



			//.SetFloat ("_QOffset.x", counter);

		}








	}

	bool turn=false;



}