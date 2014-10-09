using UnityEngine;
using System.Collections;

public class SeaMove : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	public float speed = 0.6f;
	
	
	public const float conspeed = 0.9f;
	
	

	//Offset the material texture at a constant rate
	void LateUpdate () {
		

		float texoffset = Time.time * speed;                            
		
		float offset = Time.time * conspeed;                            
		
		
				renderer.material.mainTextureOffset = new Vector2 (texoffset,0);
		
		

		
		
	}
}