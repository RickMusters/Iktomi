using UnityEngine;
using System.Collections;

public class LoaderScript : MonoBehaviour {
	
	private float switchDelay = 3.0f;
	private float switchDelayLeft;
	private bool switchbool = false;
	private bool switched = false;
	
	void Start () {
		switchDelayLeft = switchDelay;
		switchbool = true;
		
	}
	
	void Update(){
		Debug.Log(switchDelayLeft);
		if(switchbool == true){
			switchDelayLeft -= Time.deltaTime;
			
			if(switchDelayLeft <= 0)
			{
				Application.LoadLevelAdditive(1);
				switchbool = false;
				switched = true;
				switchDelayLeft = switchDelay;
			}
		}
		if(switched == true){
			switchDelayLeft -= Time.deltaTime;
			
			if(switchDelayLeft <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}