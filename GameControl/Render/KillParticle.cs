using UnityEngine;
using System.Collections;

public class KillParticle : MonoBehaviour {


	void Start(){
		Destroy(gameObject, 2f);
	}
}
