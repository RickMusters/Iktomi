using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSysteem : MonoBehaviour {
	//
	private float spawnDelay;
	public float setSpawnDelay;
	public bool spawnD = false;
	private float randomNumber;
	/*public enum dreamTypes
	{
		good,
		bad,
		powerUp
	}*/
	//
	public enum spawnTypes
	{
		normal,
		once,
		wave,
		timedWave
	}
	//
	//public dreamTypes dreamType = dreamTypes.good;
	public GameObject goodEnemy;
	public GameObject badEnemy;
	public GameObject powerUpEnemy;
	//private Dictionary<dreamTypes, GameObject> enemies = new Dictionary<dreamTypes, GameObject>(2);
	//
	public int totalEnemies;
	private int enemiesSpawned;
	private int numEnemies;
	//
	//private int spawnID;
	//
	private bool waveSpawn = false;
	public bool spawn = true;
	public spawnTypes spawnType = spawnTypes.normal;

	public float waveTimer = 30.0f;
	private float timeTillWave = 0.0f;

	public int totalWaves = 5;
	private int numWaves = 0;

	public bool startSpawn = false;

	void Start(){
		//spawnID = Random.Range(1,500);
		//enemies.Add(dreamTypes.good, goodEnemy);
		//enemies.Add(dreamTypes.bad, badEnemy);
		spawnDelay = 0.8f;
	}

	void Update(){
		if(startSpawn == true){
			if(spawnDelay >= 0f && !spawnD)
			{
				spawnD = false;
				spawnDelay -= Time.deltaTime;
			}
			if(spawnDelay <= 0f)
			{
				randomNumber = Random.Range(0f,3.0f);
				spawnD = true;
				spawnDelay = setSpawnDelay;
			}
			if(spawn){
				if(spawnType == spawnTypes.normal)
				{
					if(numEnemies < totalEnemies)
					{
						spawnEnemy();
					}
				}
				else if(spawnType == spawnTypes.once)
				{
					if(enemiesSpawned >= totalEnemies)
					{
						spawn = false;
					}
					else
					{
						spawnEnemy();
					}
				}
				else if(spawnType == spawnTypes.wave)
				{
					if(numWaves < totalWaves + 1)
					{
						if(waveSpawn)
						{
							spawnEnemy();
						}
						if(numEnemies == 0)
						{
							waveSpawn = true;
							numWaves++;
						}
						if(numEnemies == totalEnemies)
						{
							waveSpawn = false;
						}
					}
				}
				else if(spawnType == spawnTypes.timedWave)
				{
					if(numWaves <= totalWaves)
					{
						timeTillWave += Time.deltaTime;
						if(waveSpawn)
						{
							spawnEnemy();
						}
						if(timeTillWave >= waveTimer)
						{
							waveSpawn = true;
							timeTillWave = 0.0f;
							numWaves++;
							numEnemies = 0;
						}
						if(numEnemies >= totalEnemies)
						{
							waveSpawn = false;
						}
					}
					else
					{
						spawn = false;
					}
				}
			}
		}
	}

	private void spawnEnemy()
	{
		if(spawnD)
		{
			if(randomNumber <= 0.6f)
			{
				Instantiate(goodEnemy, gameObject.transform.position, Quaternion.identity);
			}else{
				Instantiate(badEnemy, gameObject.transform.position, Quaternion.identity);
			}
			//Enemy.SendMessage("setName", spawnID);
			numEnemies++;
			enemiesSpawned++;
			spawnD = false;
		}
	}
	public void killEnemy()
	{
		//if(spawnID == sID)
		//{
			numEnemies--;
		//}
	}
	public void enableSpawner()
	{
		//if(spawnID == sID)
		//{
			spawn = true;
		//}
	}
	public void disableSpawner()
	{
		//if(spawnID == sID)
		//{
			spawn = false;
		//}
	}
	public float TimeTillWave
	{
		get
		{
			return timeTillWave;
		}
	}
	public void enableTrigger()
	{
		spawn = true;
	}
}
