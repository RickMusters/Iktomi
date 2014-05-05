using UnityEngine;
using System.Collections;

public class ComboScript : MonoBehaviour {


	// -- Properties -- //

	// Combo
	public int comboCount = 0;
	public int comboMultiply = 1;
	public bool combo = false;

	// Timer
	public float delay;

	// GameObjects - Nightmare and Dream
	public GameObject enemy;
	public GameObject dream;

	// -- Vars -- //

	// Combo
	private int comboInt = 5;

	// Spawner
	private GameObject spawner;

	// Waves
	private WaveSysteem wave;

	// Timer
	private float delayLeft;

	// Enemy Movement
	private EnemyMovement enemyN;
	private EnemyMovement enemyD;

	void Start(){
		spawner	= 	GameObject.Find("Spawner");
		enemyN	= 	enemy.gameObject.GetComponent<EnemyMovement> ();
		enemyD	= 	dream.gameObject.GetComponent<EnemyMovement> ();
		wave	= 	spawner.gameObject.GetComponent<WaveSysteem>();
	}
	
	public int AddCombo(){

		if(combo == false)
		{
			combo = true;
			delayLeft = delay;
		}

		if (combo == true)
		{
			// Add Combo
			comboCount += 1;
			// Reset Timer
			delayLeft = delay;

			// Checking Combo amount
			if(comboCount == comboInt * comboMultiply)
			{
				if(comboCount == comboInt * 2)
				{
					GameObject.Find("CenterObject").GetComponent<PlayerScript>().ComboParticle(true, 2);
					GameObject.Find("layer5").GetComponent<BackgroundFade>().FadeOut(true);
				}

				else if(comboCount == comboInt * 3)
				{
					GameObject.Find("layer4").GetComponent<BackgroundFade>().FadeOut(true);
				}

				wave.totalEnemies += 1;

				GameObject.Find("CenterObject").GetComponent<PlayerScript>().ComboParticle(true, 1);
				GameObject.Find("ViewSprite").GetComponent<ViewScript>().scaleBool = true;

				enemyN.speed += 0.05f;
				enemyD.speed += 0.05f;
				comboMultiply ++;
			}
		}
		// Return Combo amount
		return comboCount;
	}

	void Update () 
	{
		if(wave.totalEnemies == 14)
		{
			wave.totalEnemies =  14;
		}
		if(combo == true)
		{
			// Combo Timer
			delayLeft -= Time.deltaTime;
			
			if(delayLeft <= 0)
			{
				// Combo stopped
				combo = false;
				comboCount = 0;
				comboMultiply = 1;
				GameObject.Find("CenterObject").GetComponent<PlayerScript>().ComboParticle(false, 0);
			}
		}
	}
}
