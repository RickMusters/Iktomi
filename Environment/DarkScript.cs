using UnityEngine;
using System.Collections;

public class DarkScript : MonoBehaviour {


	// -- Properties -- //

	public bool back = false;
	public bool fadeIsIn = false;

	void Start () 
	{
		// Fade
		Alpha();
	}

	public void Alpha()
	{
		renderer.material.color = new Color(gameObject.renderer.material.color.r,gameObject.renderer.material.color.g,gameObject.renderer.material.color.b, 0);
	}
	
	public void FadeIn() 
	{
		if(gameObject.renderer.material.color.a < 1f){
			renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b, renderer.material.color.a + 0.35f);
		}
		else if(renderer.material.color.a >= 1f){
			//renderer.material.color.a = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1);
			GameObject.Find("CenterObject").GetComponent<LifeScript>().lifes = 0;
		}
	}
}
