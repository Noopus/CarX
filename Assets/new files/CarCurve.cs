using UnityEngine;
using System.Collections;

public class CarCurve : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	public GameObject obstaclemaker;


	// Update is called once per frame
	void Update () {





		foreach (Transform t in transform)
		{
			
			
					for(int i=0;i<t.GetComponentsInChildren<Transform>().Length;i++)
				{			


				//t.GetComponentsInChildren<Transform>()[i].renderer.enabled=false;
		
				//print ("Tr : "+t.GetComponentsInChildren<Transform>()[i].name);

				for (int j=0; j<t.GetComponentsInChildren<Transform>()[i].renderer.materials.Length; j++) 
				{
					
					//	gobs [i].renderer.materials [j].SetFloat ("_Dist", counter);
					
					t.GetComponentsInChildren<Transform>()[i].renderer.materials [j].SetVector("_QOffset", obstaclemaker.GetComponent<Obstacle> ().curvect);
			
			    }

			
			    }
		}




	
	}
}
