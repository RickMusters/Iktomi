using UnityEngine;
using System.Collections;

public class BackgroundFade : MonoBehaviour {
	public float fadeDur;
	//private bool p;

	public void FadeOut(bool f){
		if(f == true){
			//p = true;
			StartCoroutine(FadeInOut(true));
		}
		else{
//			p = false;
//			StartCoroutine(Fade(gameObject.renderer.material.color.a, 1.0f, fadeDur));
			StartCoroutine(FadeInOut(false));
		}
	}

	private IEnumerator FadeInOut(bool i){
		if(i == true){
			yield return StartCoroutine(Fade(gameObject.renderer.material.color.a, 0.0f, fadeDur));
		}
		else{
			yield return StartCoroutine(Fade(gameObject.renderer.material.color.a, 1.0f, fadeDur));
		}
	}


	private IEnumerator Fade(float startLevel, float endLevel, float time){
		float speed = 1.0f/time;
		for(float t = 0.0f; t < 1.0; t += Time.deltaTime * speed){
			float a = Mathf.Lerp(startLevel,endLevel, t);
			renderer.material.color = new Color(gameObject.renderer.material.color.r,gameObject.renderer.material.color.g,gameObject.renderer.material.color.b, a);
			yield return 0;
		}
	}	
}