using UnityEngine;
using System.Collections;

public class LilySpawn : MonoBehaviour {	
	private float delay = 6;

	void Update () {
		delay -= Time.deltaTime;
			
		if(delay <= 0){
			Instantiate(Resources.Load("Lily"),transform.position, Quaternion.identity);
			delay = Random.Range(5f,11f);
		}
	}
}
