using UnityEngine;
using System.Collections;

public class inputScript : MonoBehaviour {
	
	private float switchDelay = 1.7f;
	private float switchDelayLeft;
	
	private bool switchCountdown = false;
	private int sceneNumber = 0;
	
	//array maken voor gameobjecten
	public GameObject startButton;
	public GameObject howButton;
	public GameObject creditsButton;
	public GameObject facebookButton;
	public GameObject twitterButton;
	
	private bool buttonBool = false;

	public AudioClip sound;
	
	void Start(){
		switchDelayLeft = switchDelay;
		
	}
	
	void Update () {
		if(Input.touchCount > 0)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if(Input.GetTouch(0).phase == TouchPhase.Began){
				if(Physics.Raycast(ray, out hit)){
					if(hit.collider.name == "Play"){
						if(buttonBool == true){
							buttonBool = false;
						}
						else{
							buttonBool = true;
						}
					}
					else if(hit.collider.name == "start"){
						switchCountdown = true;
						sceneNumber = 1;
						AudioSource.PlayClipAtPoint(sound, transform.position);
						Camera.main.GetComponent<FadeScript>().fadingOut = true;
					}
					
					else if(hit.collider.name == "how"){
						switchCountdown = true;
						sceneNumber = 2;
						AudioSource.PlayClipAtPoint(sound, transform.position);
						Camera.main.GetComponent<FadeScript>().fadingOut = true;
					}
					
					else if(hit.collider.name == "credits"){
						Debug.Log("Credits scene load here");
						AudioSource.PlayClipAtPoint(sound, transform.position);
					}
					
					else if(hit.collider.name == "facebook"){
						Debug.Log("facebook");
						Application.OpenURL("https://www.facebook.com/IktomiMythe");
						
					}
					else if(hit.collider.name == "twitter"){
						Debug.Log("twitter");
						Application.OpenURL("https://twitter.com/IktomiMythe");
						
					}
					
					if(buttonBool == true){
						startButton.SetActive(true);
						howButton.SetActive(true);
						creditsButton.SetActive(true);
						twitterButton.SetActive(true);
						facebookButton.SetActive(true);
					}
					else{
						startButton.SetActive(false);
						howButton.SetActive(false);
						creditsButton.SetActive(false);
						twitterButton.SetActive(false);
						facebookButton.SetActive(false);
					}
				}
			}
		}
		
		if(switchCountdown == true){
			switchDelayLeft -= Time.deltaTime;
			
			if(switchDelayLeft <= 0)
			{
				Application.LoadLevel(sceneNumber);
			}
		}
	}
}

/*for(int i = 0; i < Input.touchCount; i++)
			{
				//executes this code for current touch (i)
				if(this.guiTexture.HitTest(Input.GetTouch(i).position))
				{
					//if current touch hits guitexture, run this code
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						Debug.Log("The touch has begun on" + this.name);
					}

					if(Input.GetTouch(i).phase == TouchPhase.Ended)
					{
						Camera.main.GetComponent<FadeScript>().fadingOut = true;
						Debug.Log("The touch has ended on" + this.name);

						if(this.name == "Button_Play")
						{
							switchCountdown = true;
							sceneNumber = 1;
						}
						if(this.name == "Button_Options")
						{
							switchCountdown = true;
							sceneNumber = 2;
						}
						if(this.name == "Button_Exit")
						{
							Application.Quit();
						}
					}
				}
			}*/	
