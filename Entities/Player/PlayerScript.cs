using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public GameObject[] particles;


	void Start(){

	}

	public void ComboParticle(bool active, int particleNr){
		if(active && particleNr == 1){
			particles[0].transform.position = transform.position;
			particles[0].SetActive(true);
		}
		else if(active && particleNr == 2){
			for(int t = 0; t < particles.Length; t++){
				particles[t].SetActive(false);
				particles[t].transform.position = transform.position;
				particles[t].SetActive(true);
			}
		}

		else{
			for(int t = 0; t < particles.Length; t++){
				particles[t].SetActive(false);
			}
		}
	}
}
