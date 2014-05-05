using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	private GameObject player;
	private LifeScript lifeP;
	private Score score;
	public GameObject game;
	public GameObject endScreen;
	public GameObject control;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("CenterObject");
		lifeP = player.gameObject.GetComponent<LifeScript> ();
		score = control.gameObject.GetComponent<Score> ();
		game.SetActive (true);
		endScreen.SetActive (false);
	
	}

	void Update () {
		if (lifeP.lifes == 0 || lifeP.lifes <= 0){
			game.SetActive(false);
			endScreen.SetActive(true);

		}
	}
}
