using UnityEngine;
using System.Collections;

public class LilyMovement : MonoBehaviour {

	private Vector3 pos;
	private Vector3 scale;


	// Use this for initialization
	void Start () {
		pos = new Vector3(11f, Random.Range(-2f, -4.5f), 14.05f);
		scale = new Vector3(Random.Range(0.5f,1f),Random.Range(0.5f,1f),1);
		
		transform.position = pos;
		transform.localScale = scale;
	}
	

	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime);

		if(transform.position.x <= -12.5f){
			Destroy(gameObject);
		}
	}
}
