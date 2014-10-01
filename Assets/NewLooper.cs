using UnityEngine;
using System.Collections;

public class NewLooper : MonoBehaviour {
	
	
	
	
	public GameObject go1,go2,go3;
	
	
	GameObject g1,g2,g3;
	
	
	GameObject[] gobs;
	
	
	Vector3 size;
	
	
	
	float sizeofarray;
	
	// Use this for initialization
	void Start () {
		
		gobs = new GameObject[6];
		
		speed = 1f;


//		sizeofarray = 4;

		sizeofarray = 6;


		
		Renderer renderer = go1.GetComponent< Renderer >();
		
		size = renderer.bounds.size;
		
		
		
		Vector3 firstpos, secondpos,thirdpos;
		
		firstpos = new Vector3 (0,0,0);
		
		secondpos = new Vector3 (0,0,firstpos.z+size.z-speed);
		
		thirdpos = new Vector3 (0,0,secondpos.z+size.z);
		
		
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



			if(i==0||i==3)
				gobs [i] = Instantiate (go1, firstpos, transform.rotation) as GameObject;
			
			if(i==1||i==4)
			{
				gobs [i] = Instantiate (go2, secondpos, transform.rotation) as GameObject;
				
			}

		if(i==2||i==5)
				gobs [i] = Instantiate (go3, thirdpos, transform.rotation) as GameObject;
			
			
			
			
			if(i>sizeofarray/2-1)
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
					
					
				}
				
				
				
				
				/*
                if(counter<5||counter>10)
                {
                    if(i==3||i==4||i==5)
                        gobs[i].SetActive(true);
                    else
                        
                        gobs[i].SetActive(false);
                }
                else if(counter>5&&counter<10)
                {
                    if(i==0||i==1||i==2)
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
			
			
			
			
			
			
			gobs[i].transform.Translate (Vector3.forward*-speed);
			
			
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
		
	}
}