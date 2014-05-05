
using UnityEngine;
using System.Collections;

public class ViewScript : MonoBehaviour {

	public bool scaleBool;
	public bool unScaleBool;
	public bool smallScale;
	public float scaleDur;
	public float scaleSize;
	public float smallScaleSize;
	private Vector3 minimumScale = new Vector3(1f,1f,1f);

	void Start(){

		scaleBool = false;
		unScaleBool = false;
		smallScale = false;
	}
	

	void Update(){


		if(smallScale == true){
			if(transform.localScale.x > minimumScale.x && transform.localScale.y > minimumScale.y){
				StartCoroutine(Small());
				smallScale = false;
			}
			else{
				GameObject.Find("Darkness").GetComponent<DarkScript>().FadeIn();
				smallScale = false;

			}
		}

		if(scaleBool == true){
			StartCoroutine(Scale(true));
			scaleBool = false;
		}
		else if(unScaleBool == true)
		{
			if(transform.localScale.x > minimumScale.x && transform.localScale.y > minimumScale.y){
				StartCoroutine(Scale(false));
				unScaleBool = false;
			}
			else{
				unScaleBool = false;
			}
		}

		if(transform.localScale.x <= minimumScale.x && transform.localScale.y <= minimumScale.y){
			transform.localScale = minimumScale;
		}
	}

	private IEnumerator Small(){
		yield return StartCoroutine(ScaleView(transform.localScale,new Vector3(transform.localScale.x - smallScaleSize, transform.localScale.y - smallScaleSize, 1f), scaleDur));
	}

	private IEnumerator Scale(bool s){
		if(s == true){
			yield return StartCoroutine(ScaleView(transform.localScale,new Vector3(transform.localScale.x + scaleSize, transform.localScale.y + scaleSize, 1f), scaleDur));
		}
		else{
			yield return StartCoroutine(ScaleView(transform.localScale, new Vector3(transform.localScale.x - scaleSize, transform.localScale.y - scaleSize, 1f), scaleDur));
		}
	}

	private IEnumerator ScaleView(Vector3 startLevel, Vector3 endLevel, float time)
	{
		float speed = 1.0f/time;
		for(float t = 0.0f; t < 1.0; t += Time.deltaTime * speed)
		{
			Vector3 a = Vector3.Lerp(startLevel,endLevel, t);
			transform.localScale = a;
			yield return 0;
		}
	}
}
