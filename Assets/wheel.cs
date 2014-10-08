using UnityEngine;
using System.Collections;

public class wheel : MonoBehaviour 
{


	public Texture nrmltex,dmgtex;


	public GameObject parent;



	int delay;

	// Use this for initialization
	void Start () 
	{
	
	


	}
	
	// Update is called once per frame
	void Update () 
	{
	
		delay=parent.GetComponent<carRotate> ().delay;



		if(delay>0)
		renderer.material.SetTexture("_MainTex", dmgtex);



	}




}
