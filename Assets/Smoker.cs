using UnityEngine;
using System.Collections;



public class Smoker : MonoBehaviour 
{
	
	

	public GameObject parent;
	
	
	
	int delay;
	
	// Use this for initialization
	void Start () 
	{
		

		this.particleEmitter.emit = false;

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		delay=parent.GetComponent<carRotate> ().delay;
		
		
		
	//	if (delay > 0)
	//					this.particleEmitter.emit = true;


		
	}
	
	
	
	
}
