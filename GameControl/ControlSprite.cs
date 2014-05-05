using UnityEngine;
using System.Collections;

public class ControlSprite : MonoBehaviour {
	public bool f = false;
	private bool t = false;
	private float fadeDur = 2;
	private float delay = 2;

	private GameObject spawner;
	private WaveSysteem wave;

	void Start()
	{
		spawner = GameObject.FindGameObjectWithTag("Spawner");
		wave = spawner.GetComponent<WaveSysteem>();
	}

	void Update()
	{
		if(f == true)
		{
			StartCoroutine(FadeInOut());
		} 
		if(t == true)
		{
			delay -= Time.deltaTime;	
			if(delay <= 0)
			{
				wave.startSpawn = true;
				t = false;
			}
		}
	}

	private IEnumerator FadeInOut()
	{
		yield return StartCoroutine(Fade(gameObject.renderer.material.color.a, 0.0f, fadeDur));
		t = true;
	}

	private IEnumerator Fade(float startLevel, float endLevel, float time)
	{
		float speed = 1.0f/time;
		for(float t = 0.0f; t < 1.0; t += Time.deltaTime * speed){
			float a = Mathf.Lerp(startLevel,endLevel, t);
			renderer.material.color = new Color(gameObject.renderer.material.color.r,gameObject.renderer.material.color.g,gameObject.renderer.material.color.b, a);
			yield return 0;
		}
	}
}
