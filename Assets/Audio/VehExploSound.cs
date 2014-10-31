using UnityEngine;
using System.Collections;

public class VehExploSound : MonoBehaviour {




	public AudioClip explodesound;


	AudioSource audio2,audio1;


	AudioSource[] aSources;

	public void explode()
	{
		
		audio2.clip = explodesound;

		audio2.loop = false;

		audio2.Play ();


		if (!audio2.isPlaying) 
		{
			audio2.clip=null;
		}



	}



	// Use this for initialization
	void Start () {



		aSources = this.GetComponents<AudioSource> ();


		audio1 = aSources [0];

//		if(aSources.Length>1)

		/*
		audio2 = aSources [1];

		audio2.clip = explodesound;
		
		audio2.loop = false;
*/


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
