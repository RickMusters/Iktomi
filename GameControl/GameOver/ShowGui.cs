using UnityEngine;
using System.Collections;

public class ShowGui : MonoBehaviour {
	public GUIStyle style;
	private GameObject controll;
	private Score score;

	void Awake(){

	}
	void Start(){
		controll = GameObject.Find("GameControl");
		score = controll.gameObject.GetComponent<Score>();
	}

	void OnGUI(){

		GUI.Label(new Rect(100,60,100f,100f),"NightmareScore \n  " + score.nightmaresTapped + "\n  " + score.nightmareScore,style);
		GUI.Label(new Rect(800,60,100,100),"DreamScore \n  " + score.dreamsTapped + "\n  " + -score.dreamScore,style);
		GUI.Label(new Rect (500, 180, 100, 100), "Score: \n  " + score.score,style);
		GUI.Label(new Rect(500,360,100,100),"HighScore:\n  " + PlayerPrefs.GetInt("HighScore"),style);
	}
}
