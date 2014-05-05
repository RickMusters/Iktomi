using UnityEngine;
using System.Collections;

public class WaveUp : MonoBehaviour {


	// -- Properties -- //

	// Enemy Movement
	public float enemyMove = 0.5f;

	// Viewsprite
	public Transform viewSprite;

	// GameObjects - Nightmare and Dream
	public GameObject enemy;
	public GameObject dream;

	// -- Vars -- //

	// Spawner
	private GameObject spawner;

	// Scripts
	private WaveSysteem wave;
	private EnemyMovement enemyN;
	private EnemyMovement enemyD;

	void Start()
	{
		// Load GameObjects
		spawner	= 	GameObject.Find("Spawner");

		// Load Scripts
		wave 	= 	spawner.gameObject.GetComponent<WaveSysteem>();
		enemyN 	= 	enemy.gameObject.GetComponent<EnemyMovement> ();
		enemyD 	= 	dream.gameObject.GetComponent<EnemyMovement> ();
	}

	void Update()
	{
		enemyN.speed = viewSprite.localScale.x + viewSprite.localScale.y + enemyMove;
		enemyD.speed = viewSprite.localScale.x + viewSprite.localScale.y + enemyMove;

		if(viewSprite.localScale.x < 1.1f && viewSprite.localScale.y < 1.1f)
		{
			wave.setSpawnDelay = 0.8f;
			wave.totalEnemies = 4;
		}
		else if(viewSprite.localScale.x > 1.1f && viewSprite.localScale.y > 1.1f && viewSprite.localScale.x < 1.7f && viewSprite.localScale.y < 1.7f)
		{
			wave.setSpawnDelay = 0.7f;
			wave.totalEnemies = 6;
			enemyMove = 0.5f;
		}
		else if(viewSprite.localScale.x > 1.8f && viewSprite.localScale.y > 1.8f)
		{
			wave.setSpawnDelay = 0.5f;
			wave.totalEnemies = 8;
			enemyMove = 0.75f;
		}
	}
}
