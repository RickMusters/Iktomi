using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			//Debug.Log ("BackButton on Phone");
			Application.LoadLevel(0);
		}
	}
}
