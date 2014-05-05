using UnityEngine;
using System.Collections;

public class TapScript : MonoBehaviour {


	// -- Properties -- //

	// GameObjects - Background Layers
	public GameObject layer4;
	public GameObject layer5;

	// -- Vars -- //

	// Timer
	private float switchDelayLeft;
	private bool switchCountdown = false;

	// Scene Number
	private int sceneNumber = 0;

	// Raycast
	private RaycastHit hit; 

	// Spawner
	private GameObject spawner;

	// Orbit
	private GameObject orbit;

	// Game Control
	private GameObject controll;

	// Score
	private Score score;

	// Player Life
	private LifeScript lifeP;

	// Waves
	private WaveSysteem wave;

	// Combo
	private ComboScript combo;

	// Touch
	private bool firstTouch = false;

	void Start()
	{
		// Load GameObjects
		orbit 		=	GameObject.Find("CenterObject");
		controll 	=	GameObject.Find("GameControl");
		spawner 	=	GameObject.FindGameObjectWithTag("Spawner");

		// Load Scripts
		lifeP 		= 	orbit.gameObject.GetComponent<LifeScript>();
		wave		= 	spawner.gameObject.GetComponent<WaveSysteem>();
		score 		= 	controll.gameObject.GetComponent<Score>();
		combo 		= 	controll.gameObject.GetComponent<ComboScript> ();

	}
	
	void Update () 
	{
		// Number of Touches
		if(Input.touchCount > 0)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if(Physics.Raycast(ray,out hit))
			{
				// Back to Menu
				if(hit.collider.name == "back to menu"){
					switchCountdown = true;
					sceneNumber = 0;	
					Camera.main.GetComponent<FadeScript>().fadingOut = true;
				}

				if(firstTouch == false)
				{
					// Fade Instructions
					GameObject.Find("hand_text").GetComponent<ControlSprite>().f = true;
					GameObject.Find("handje").GetComponent<ControlSprite>().f = true;
					firstTouch = true;
				}

				if(hit.transform.tag == "Enemy")
				{
					// Range check
					if(hit.transform.gameObject.GetComponent<EnemyScript>().inRange == true)
					{
						// Spawn Particle
						Instantiate(Resources.Load("DeathParticle"),hit.transform.position, Quaternion.identity);

						// Adjust Score
						score.nightmaresTapped++;

						// Destroy collider
						Destroy(hit.collider.gameObject);

						wave.killEnemy();
						GameObject.Find("Darkness").GetComponent<DarkScript>().Alpha();

						// Add combo
						int p = combo.AddCombo();

						// Play audio
						hit.collider.gameObject.GetComponent<EnemyScript>().AudioFunc(p);
					}
				}
				else if(hit.transform.tag == "Dream")
				{
					// Range check
					if(hit.transform.gameObject.GetComponent<DreamScript>().inRange == true)
					{
						// Fade background
						layer4.GetComponent<BackgroundFade>().FadeOut(false);
						layer5.GetComponent<BackgroundFade>().FadeOut(false);

						// Scale View
						GameObject.Find("ViewSprite").GetComponent<ViewScript>().unScaleBool = true;

						// Spawn Particle
						Instantiate(Resources.Load("New"),hit.transform.position, Quaternion.identity);

						// Play audio
						hit.collider.gameObject.GetComponent<DreamScript>().DeathSound();

						// Destroy Collider
						Destroy(hit.collider.gameObject);

						score.dreamsTapped++;
						lifeP.KillPlayer();
						combo.combo = false;
						combo.comboCount = 0;
						combo.comboMultiply =1;
						GameObject.Find("CenterObject").GetComponent<PlayerScript>().ComboParticle(false, 0);
						wave.killEnemy();
					}
				}
			}	
		}
		if(switchCountdown == true)
		{
			// Timer start
			switchDelayLeft -= Time.deltaTime;	

			if(switchDelayLeft <= 0)
			{
				// Adjust Score
				if(score.score > PlayerPrefs.GetInt("HighScore"))
				{
					PlayerPrefs.SetInt("HighScore",score.score);
					PlayerPrefs.Save();
				}
				Application.LoadLevel(sceneNumber);
			}
		}
	}
}