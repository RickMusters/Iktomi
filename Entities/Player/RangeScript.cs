using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeScript : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.GetComponent<EnemyScript>().inRange = true;
		}
		else if(col.gameObject.tag == "Dream"){
			col.gameObject.GetComponent<DreamScript>().inRange = true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.GetComponent<EnemyScript>().inRange = false;
		}
		else if(col.gameObject.tag == "Dream"){
			col.gameObject.GetComponent<DreamScript>().inRange = false;
		}
	}
}
