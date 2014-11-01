using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Obstacle : MonoBehaviour {
	public GameObject ob1,ob2,player;
	GameObject curob,curob2;
	Vector3 spawnpos;
	Vector3 size,size2;
	Transform firstpos;
	Renderer rende,rende2;
	Vector3[] childpos,childpos2,ob1pos,ob2pos;
	bool firstwave=false,secondwave=true;
	int delay;
	bool start=false;
	int val;
	bool[] reg1,reg2;
	public float speed,time=0,turntime=0;
	public bool upturn=true;
	/// <summary>
	/// ///////////////
	/// </summary>
	Vector3[] par1pos,par2pos;
	public GameObject vehicle,vcar,vredcar,vpinkcar,vtruck,vtaxi,vltruck,vftruck,vbus,vrover;
	GameObject[] veh,veh2,car,redcar,pinkcar,truck,ltruck,ftruck,taxi,bus,rover,car2,redcar2,pinkcar2,truck2,taxi2,ltruck2,ftruck2,bus2,rover2;
	/////////
	///
	///
	///
	// Use this for initialization
	bool readytomove1,readytomove2;
	int[] x,x2;
	int randrange=9;
	public void Randomizer(int[] x)
	{
		x[0] = Random.Range(0,randrange);
		x[1] = Random.Range(0,randrange/2);
		x[2] = Random.Range(0,randrange/2);
		x[3] = Random.Range(0,randrange);
	}
	public float latestspeed=0.4f;
	void Start () {
		readytomove1 = false;
		readytomove2 = false;
		x=new int[4];
		x2=new int[4];
		speed = 0.2f;
		//////////////
		veh=new GameObject[4];
		veh2=new GameObject[4];
		car=new GameObject[4];
		redcar=new GameObject[4];
		pinkcar=new GameObject[4];
		truck=new GameObject[4];
		taxi=new GameObject[4];
		ltruck=new GameObject[4];
		ftruck=new GameObject[4];
		rover=new GameObject[4];
		bus=new GameObject[4];
		car2=new GameObject[4];
		redcar2=new GameObject[4];
		pinkcar2=new GameObject[4];
		truck2=new GameObject[4];
		taxi2=new GameObject[4];
		ltruck2=new GameObject[4];
		ftruck2=new GameObject[4];
		rover2=new GameObject[4];
		bus2=new GameObject[4];
		par1pos = new Vector3[8];
		curob = new GameObject ();
		curob.transform.position = new Vector3 (0,0,190);
		par2pos = new Vector3[8];
		curob2 = new GameObject ();
		curob2.transform.position = new Vector3 (0,0,190);
		for (int i=0; i<veh.Length; i++)
		{
			veh [i] = Instantiate (vehicle, new Vector3 (3.7f - 3.2f * i, 0, 190), transform.rotation) as GameObject;
			car [i] = Instantiate (vcar, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			redcar [i] = Instantiate (vredcar, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			pinkcar [i] = Instantiate (vpinkcar, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			truck [i] = Instantiate (vtruck, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			taxi [i] = Instantiate (vtaxi, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			ltruck [i] = Instantiate (vltruck, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			ftruck [i] = Instantiate (vftruck, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			rover [i] = Instantiate (vrover, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			bus [i] = Instantiate (vbus, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			// veh[i]=truck[i];
			par1pos[i]=veh[i].transform.position;
			veh[i].transform.parent = curob.transform;
			BoxCollider col=veh[i].AddComponent<BoxCollider>();
			/*
Rigidbody gameObjectsRigidBody = veh[i].AddComponent<Rigidbody>(); // Add the rigidbody.
gameObjectsRigidBody.mass = 5;
gameObjectsRigidBody.useGravity=false;
gameObjectsRigidBody.isKinematic=true;
*/
		}
		for (int i=0; i<veh2.Length; i++)
		{
			veh2 [i] = Instantiate (vehicle, new Vector3 (3.7f - 3.2f * i, 0, 190), transform.rotation) as GameObject;
			redcar2 [i] = Instantiate (vredcar, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			pinkcar2 [i] = Instantiate (vpinkcar, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			car2 [i] = Instantiate (vcar, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			truck2 [i] = Instantiate (vtruck, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			taxi2 [i] = Instantiate (vtaxi, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			ltruck2 [i] = Instantiate (vltruck, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			ftruck2 [i] = Instantiate (vftruck, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			rover2 [i] = Instantiate (vrover, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			bus2 [i] = Instantiate (vbus, new Vector3 (3.7f - 3.2f * i, 0, 10*190), transform.rotation) as GameObject;
			par2pos[i]=veh2[i].transform.position;
			veh2[i].transform.parent = curob2.transform;
			BoxCollider col=veh2[i].AddComponent<BoxCollider>();
			/* Rigidbody gameObjectsRigidBody = veh2[i].AddComponent<Rigidbody>(); // Add the rigidbody.
gameObjectsRigidBody.mass = 5;
gameObjectsRigidBody.useGravity=false;
gameObjectsRigidBody.isKinematic=true;
*/
		}
		////////////
		reg1=new bool[10];
		reg2=new bool[10];
		for (int r=0; r<reg1.Length; r++)
			reg1 [r] = false;
		for (int r=0; r<reg2.Length; r++)
			reg2 [r] = false;
		firstwave = false;
		childpos = new Vector3[10];
		childpos2 = new Vector3[10];
		ob1pos = new Vector3[ob1.transform.childCount];
		ob2pos = new Vector3[ob2.transform.childCount];
		ob1=Instantiate (ob1, new Vector3(player.transform.position.x,0,190), transform.rotation) as GameObject;
		ob2=Instantiate (ob2, new Vector3(player.transform.position.x,0,190), transform.rotation) as GameObject;
		val = 0;
		spawnpos = curob.transform.position;
		rende = curob.GetComponentInChildren<Renderer> ();
		rende2 = curob2.GetComponentInChildren<Renderer> ();
		size = rende.bounds.size;
		size2 = rende2.bounds.size;
		firstpos = curob.transform;
		for (int j = 0; j < curob.transform.childCount; j++)
		{
			ob1pos[j]=curob.transform.GetChild(j).transform.position;
		}
		for (int j = 0; j < curob2.transform.childCount; j++)
		{
			ob2pos[j]=curob2.transform.GetChild(j).transform.position;
		}
		childpos = ob1pos;
		childpos2 = ob2pos;
		reset (curob, childpos,reg1);
		reset (curob2, childpos2,reg2);
		Randomizer(x);
		for (int i=0; i<4; i++) {
			veh[i].transform.parent=null;
			vchooser1(i);
			veh[i].transform.parent = curob.transform;
			reset (curob, childpos,reg1);
			Randomizer (x2);
			veh2[i].transform.parent=null;
			vchooser2(i);
			veh2[i].transform.parent = curob2.transform;
			reset (curob2, childpos2,reg2);
		}
		setKin (curob);
		setKin (curob2);
		curvect = new Vector3 (0,0,0);
	}
	void setKin(GameObject curob)
	{
		for (int j=0; j<curob.transform.childCount; j++) {
			// if(curob.transform.GetChild(j).transform.rigidbody!=null)
			// curob.transform.GetChild (j).transform.rigidbody.isKinematic = false;
		}
	}
	void setGra(GameObject curob)
	{
		for (int j=0; j<curob.transform.childCount; j++) {
			curob.transform.GetChild (j).transform.rigidbody.useGravity=true;
		}
	}
	float uprange=0,siderange=0;
	void vchooser1(int i)
	{
		if (x [i] == 0) {
			veh [i] = car [i];
		} else
		if (x [i] == 1) {
			veh [i] = rover [i];
		} else
		if (x[i] == 2) {
			veh [i] = taxi [i];
		}
		else
		if (x [i] == 3) {
			veh [i] = redcar [i];
		}
		else
		if (x [i] == 4) {
			veh [i] = pinkcar [i];
		}
		if (x [i] == 5) {
			veh [i] = truck [i];
		}
		else
		if (x [i] == 6) {
			veh [i] = ftruck [i];
		}
		else
		if (x [i] == 7) {
			veh [i] = bus [i];
		}
		else
		if (x [i] == 8) {
			veh [i] = ltruck [i];
		}
	}
	void vchooser2(int i)
	{
		// for (int i=0; i<10; i++)
		{
			if (x2 [i] == 0) {
				veh2 [i] = car2 [i];
			} else
			if (x2 [i] == 1) {
				veh2 [i] = rover2 [i];
			} else
			if (x2[i] == 2) {
				veh2 [i] = taxi2 [i];
			}
			else
			if (x2 [i] == 3) {
				veh2 [i] = redcar2 [i];
			}
			else
			if (x2 [i] == 4) {
				veh2 [i] = pinkcar2 [i];
			}
			if (x2 [i] == 5) {
				veh2 [i] = truck2 [i];
			}
			else
			if (x2 [i] == 6) {
				veh2 [i] = ftruck2 [i];
			}
			else
			if (x2 [i] == 7) {
				veh2 [i] = bus2 [i];
			}
			else
			if (x2 [i] == 8) {
				veh2 [i] = ltruck2 [i];
			}
		}
	}
	bool turn=false;
	public Vector3 curvect;
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("p"))
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		delay = player.GetComponent<carMove> ().health;
		if (latestspeed < speed*Time.timeScale)
			latestspeed = speed*Time.timeScale;
		// print ("hit is detec"+latestspeed*Time.timeScale);
		for (int i=0; i<4; i++) {
			for (int j=0; j<veh[i].renderer.materials.Length; j++) {
				// gobs [i].renderer.materials [j].SetFloat ("_Dist", counter);
				veh [i].renderer.materials [j].SetVector ("_QOffset", curvect);
				veh[i].renderer.materials [j].SetFloat ("_Dist", 8);
				//.SetFloat ("_QOffset.x", counter);
			}
			for (int j=0; j<veh2[i].renderer.materials.Length; j++) {
				// gobs [i].renderer.materials [j].SetFloat ("_Dist", counter);
				veh2 [i].renderer.materials [j].SetVector ("_QOffset", curvect);
				veh2 [i].renderer.materials [j].SetFloat ("_Dist", 8);
				//print(veh[i].renderer.material.GetFloat("_Dist"));
				// print ("curv .x" + curvect.x);
				//.SetFloat ("_QOffset.x", counter);
			}
		}
		if (!turn)
		{
			curvect.x -= 0.0003f*Time.timeScale;
		}
		else if (turn)
		{
			curvect.x += 0.0003f*Time.timeScale;
		}
		if (!upturn)
			curvect.y -= 0.0001f*Time.timeScale;
		else if(upturn)
			curvect.y += 0.0001f*Time.timeScale;
		if (curvect.x < -0.10f+siderange)
		{
			turn = true;
			siderange=Random.Range(0,0.1f);
		}
		if (curvect.x > 0.10f-siderange)
		{
			turn = false;
			siderange=Random.Range(0,0.1f);
		}
		if (curvect.y < -0.03f+uprange)
		{
			upturn = true;
			uprange=Random.Range(0,0.03f);
		}
		if (curvect.y > 0.03f-uprange)
		{
			upturn = false;
			uprange=Random.Range(0,0.03f);
		}
		if (delay > 0)
		{
			setKin (curob);
			setKin (curob2);
			setGra (curob);
			setGra (curob2);
			speed=-0.2f;
			speed=0;
		}
		if (curob.transform.position.z < player.transform.position.z - 4 * size.z&&delay==0) {
			reset (curob, childpos,reg1);
			curob.transform.position = new Vector3(curob.transform.position.x,curob.transform.position.y,150+20);
			Randomizer(x);
			// curob=ob1;
			reshuffle(childpos);
			for(int i=0;i<4;i++)
			{
				veh[i].transform.parent=null;
				reset (curob, childpos,reg1);
				// if(i>1)
				vchooser1(i);
				/*
if(x[i]==0)
{
veh[i]=car[i];
}
else
if(x[i]==1)
{
veh[i]=truck[i];
}
else
if (x [i] == 2) {
veh [i] = taxi [i];
}
*/
				// veh[i]=car[i];
				veh[i].transform.parent = curob.transform;
				reset (curob, childpos,reg1);
			}
			for(int j=0;j<curob.transform.childCount;j++)
			{
				// curob.transform.GetChild(j).transform.rigidbody.isKinematic = false;
				if(!curob.transform.GetChild(j).transform.rigidbody.isKinematic)
				{
					curob.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
					curob.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;
				}
				curob.transform.GetChild(j).transform.position=new Vector3(childpos[j].x,childpos[j].y,childpos[j].z);
				// curob.transform.GetChild(j).transform.rotation=Quaternion.identity;
				// curob.transform.GetChild(j).transform.rigidbody.Sleep( );
			}
			// firstwave=false;
		} else
		{
			if(firstwave)
			{
				// if(delay==0)
				curob.transform.Translate (Vector3.forward * -speed*Time.timeScale);
				for(int j=0;j<curob.transform.childCount;j++)
				{
					if(delay==0)
					{
						if(curob.transform.GetChild (j).rigidbody.angularVelocity.y==0)
						{
							curob.transform.GetChild (j).transform.Translate (Vector3.forward * -Time.timeScale*(0.045f+0.05f*j+0.15f*j+j*speed*Time.timeScale/250));
							Ray ray = new Ray(curob.transform.GetChild (j).position,-curob.transform.GetChild (j).forward);
							RaycastHit hit;
							//if (curob2.transform.GetChild (j).transform.collider.Raycast (ray,out hit,100.0))
							if(Physics.Raycast(ray,out hit,250))
							{
								// Debug.DrawLine (ray.origin, hit.point);
								if(readytomove1)
								{
									movefunc (hit);
								}
								if(!hit.collider.name.Equals("BottomBlock")&&hit.collider.renderer.enabled)
								{
									// Debug.Log("The object in front of 1st is "+curob.transform.GetChild (j).transform.name+" is "+hit.collider.name);
									readytomove1=true;
								}
							}
						}
						else
						{
							//curob.transform.GetChild (j).transform.Translate (Vector3.forward * -speed*Time.timeScale*(1.5f));
							curob.transform.GetChild (j).transform.rigidbody.AddForce(Vector3.forward * -speed*Time.timeScale*(500.5f));
						}
						curob.transform.GetChild (j).renderer.enabled=true;
					}else
						if(curob.transform.GetChild (j).transform.position.z<player.transform.position.z)
					{
						// curob.transform.GetChild (j).transform.Translate (Vector3.forward *-(0.045f+0.05f*j+0.05f*j+j*speed*Time.timeScale/250));
					}
					else
						// if(curob.transform.GetChild (j).transform.position.z>player.transform.position.z+10)
						if(curob.transform.GetChild (j).transform.rotation.x==0)
					{
						if(j==0)
							curob.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*1+0.03f*1+1*speed*Time.timeScale/250));
						curob.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*j+0.03f*j+j*speed*Time.timeScale/250));
					}
					if(curob.transform.GetChild (j).transform.position.z<player.transform.position.z&&reg1[j]==false)
					{
						reg1 [j] = true;
						time+=1;
						if(time==5+turntime)
						{
							if(speed<1.20f)
								speed+=0.1f;
							time=0;
							turntime+=1;
						}
					}
				}
			}
		}
		if (curob.transform.position.z < player.transform.position.z + 40)
		{
			secondwave = true;
		}
		// if (curob2.transform.position.z < player.transform.position.z + 4* size2.z)
		if (curob2.transform.position.z < player.transform.position.z + 90)
			firstwave = true;
		// if (curob2.transform.position.z < player.transform.position.z - 4 * size.z)
		if (curob2.transform.position.z < player.transform.position.z - 4 * size.z&&delay==0)
		{
			curob2.transform.position = new Vector3(curob2.transform.position.x,curob2.transform.position.y,150+20);
			// curob2=ob2;
			reset (curob2, childpos2,reg1);
			reshuffle(childpos2);
			Randomizer(x2);
			for(int i=0;i<4;i++)
			{
				veh2[i].transform.parent=null;
				// if(i>1)
				vchooser2(i);
				// veh[i]=car[i];
				veh2[i].transform.parent = curob2.transform;
				// reset (curob2, childpos2,reg2);
			}
			for(int j=0;j<curob2.transform.childCount;j++)
			{
				reset (curob2, childpos2,reg2);
				if(!curob2.transform.GetChild(j).transform.rigidbody.isKinematic&&(curob.transform.GetChild(j).transform.rigidbody!=null))
				{
					curob2.transform.GetChild(j).transform.rigidbody.velocity = Vector3.zero;
					curob2.transform.GetChild(j).transform.rigidbody.angularVelocity = Vector3.zero;
				}
			}
		} else
		{
			if(secondwave)
			{
				// if(delay==0)
				curob2.transform.Translate (Vector3.forward * -speed*Time.timeScale);
				for(int j=0;j<curob.transform.childCount;j++)
				{
					if(delay==0)
					{
						if(curob2.transform.GetChild (j).rigidbody.angularVelocity.y==0)
						{
							curob2.transform.GetChild (j).transform.Translate (Vector3.forward * -Time.timeScale*(0.045f+0.05f*j+0.15f*j+j*speed*Time.timeScale/250));
							Ray ray = new Ray(curob2.transform.GetChild (j).position,-curob2.transform.GetChild (j).forward);
							RaycastHit hit;
							//if (curob2.transform.GetChild (j).transform.collider.Raycast (ray,out hit,100.0))
							if(Physics.Raycast(ray,out hit,250))
							{
								// Debug.DrawLine (ray.origin, hit.point);
								if(readytomove2)
								{
									movefunc (hit);
								}
								if(!hit.collider.name.Equals("BottomBlock")&&hit.collider.renderer.enabled)
								{
									// Debug.Log("The object in front of "+curob2.transform.GetChild (j).transform.name+" is "+hit.collider.name);
									// hit.transform.Translate (hit.transform.right * -Time.timeScale*1);
									readytomove2=true;
								}
							}
						}
						else
						{
							// curob2.transform.GetChild (j).transform.Translate (Vector3.forward * -speed*Time.timeScale*(1.5f));
							curob2.transform.GetChild (j).transform.rigidbody.AddForce(Vector3.forward * -speed*Time.timeScale*(500.5f));
						}
						curob2.transform.GetChild (j).renderer.enabled=true;
					}else
						if(curob2.transform.GetChild (j).transform.position.z<player.transform.position.z)
					{
						// curob2.transform.GetChild (j).transform.Translate (Vector3.forward * (0.045f+0.05f*j+0.05f*j+j*speed*Time.timeScale/500));
					}
					else
						// if(curob2.transform.GetChild (j).transform.position.z>player.transform.position.z+8)
						if(curob2.transform.GetChild (j).transform.rotation.x==0)
					{
						if(j==0)
							curob2.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*1+0.03f*1+1*speed*Time.timeScale/250));
						curob2.transform.GetChild (j).transform.Translate (Vector3.forward * (0.04f*j+0.03f*j+j*speed*Time.timeScale/250));
					}
					if(curob2.transform.GetChild (j).transform.position.z<player.transform.position.z&&curob2.transform.GetChild (j).transform.position.y>0&&reg2[j]==false)
					{
						reg2 [j] = true;
						// print ("hit is detected");
					}
				}
			}
		}
		// print ("xa:"+x[0]+"xb:"+x[1]+"xc:"+x[2]+"xd:"+x[3]);
		if (delay == 50) {
			reset (curob, childpos,reg1);
			reset (curob2, childpos2,reg2);
		}
	}
	void movefunc(RaycastHit hit)
	{
		Vector3 newpos=new Vector3(hit.transform.position.x+5,hit.transform.position.y,hit.transform.position.z);
		hit.transform.position = Vector3.Lerp(hit.transform.position, newpos, Time.deltaTime * 3000);
	}


	public Transform[] prefabpos,prefabinipos;
	// List of prefab childs.
	private List<Transform>[] prefabReferences;
	void reshuffle(Vector3[] obje)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < obje.Length; t++ )
		{
			Vector3 tmp = obje[t];
			int r = Random.Range(t, obje.Length);
			obje[t] = obje[r];
			obje[r] = tmp;
		}
	}
	void reset(GameObject curo,Vector3[] child,bool[] reg)
	{
		if (delay == 0) {
			for (int j=0; j<curo.transform.childCount; j++) {
				reg [j] = false;
				if (!curo.transform.GetChild (j).transform.rigidbody.isKinematic && curo.transform.GetChild (j).transform.rigidbody != null) {
					curo.transform.GetChild (j).transform.rigidbody.velocity = Vector3.zero;
					curo.transform.GetChild (j).transform.rigidbody.angularVelocity = Vector3.zero;
					curo.transform.GetChild (j).rigidbody.isKinematic=true;
					curo.transform.GetChild (j).rigidbody.useGravity=false;
				}
				curo.transform.GetChild (j).transform.position = new Vector3 (child [j].x, child [j].y, child [j].z);
				curo.transform.GetChild (j).transform.rotation = Quaternion.identity;
				curo.transform.GetChild (j).renderer.enabled=false;
			}
		}
	}
}