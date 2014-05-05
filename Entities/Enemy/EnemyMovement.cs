using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


	// -- Properties -- //

	// Speed
	public float speed = 0;

	// Rotate Speed
	public float rotateSpeed = 0;

	// -- Vars -- //

	// Path
	private GameObject pathPoint;

	// Spawner
	private GameObject spawner;

	// View
	private GameObject view;

	// Scripts
	private ViewScript viewScript;
	private WaveSysteem wave;
	private WaypointPath varW;

	// Waypoint
	private int waypointIndex = 0;

	// Random
	private float randomNumber;

	void Start()
	{
		// Random Number
		randomNumber = Random.Range(0f,3.0f);

		// Get Path
		if(randomNumber <= 1f){
			pathPoint = GameObject.Find("Path_1");
		}

	 	if(randomNumber >= 1.0f && randomNumber <= 2.0f){
			pathPoint = GameObject.Find("Path_2");
		}

		if(randomNumber > 2.0f){
			pathPoint = GameObject.Find("Path_3");
		}

		// Load GameObjects
		spawner = GameObject.FindGameObjectWithTag("Spawner");
		view = GameObject.FindGameObjectWithTag("View");

		// Load Scripts
		viewScript = view.GetComponent<ViewScript>();
		wave = spawner.gameObject.GetComponent<WaveSysteem>();
		varW = pathPoint.gameObject.GetComponent<WaypointPath>();
	}
	
	void Update(){

		rotateSpeed = speed - 1f;

		if(waypointIndex < varW.waypoints.Length)
		{
			if(Vector3.Distance(transform.position,varW.waypoints[waypointIndex].position) < 1)
			{
				waypointIndex++;
			}
		}
		
		if (waypointIndex == varW.waypoints.Length) 
		{
			if(gameObject.tag == "Enemy"){
				viewScript.smallScale = true;
			}
			wave.killEnemy();
			Destroy(gameObject);

		}
		else {
			Vector3 targetDis = varW.waypoints[waypointIndex].position - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDis,Vector3.forward), rotateSpeed * Time.deltaTime);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}
}
