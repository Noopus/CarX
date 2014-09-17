using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {


	public GameObject clone;


	public bool iscloned=false;


	// Use this for initialization
	void Start () {
	
		Vector3 pos=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+this.transform.renderer.bounds.size.z);

	
			GameObject instance = Instantiate(clone, pos, transform.rotation) as GameObject;



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
