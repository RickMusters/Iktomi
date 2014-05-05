using UnityEngine;
using System.Collections;

public class HowToInput : MonoBehaviour {

	public GameObject[] pages;
	public GameObject[] buttons;
	private int pageCount = 0;
	
	void Update () {
		if(Input.touchCount > 0)
		{
			//Debug.Log("touchcount");
			
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				if(Physics.Raycast(ray, out hit)){
					Debug.Log(hit.collider.name);
					if(hit.collider.name == "Next"){
						if(pageCount == 0){
							pages[pageCount].SetActive(false);
							pageCount ++;
							buttons[1].SetActive(true);

						}
						else if(pageCount == 1){
							pages[pageCount].SetActive(false);
							pageCount ++;
							buttons[0].SetActive(false);
							buttons[2].SetActive(true);
						}
					}
					else if(hit.collider.name == "Previous"){
						if(pageCount == 1){
							pageCount --;
							pages[pageCount].SetActive(true);
							buttons[1].SetActive(false);
						}
						else if(pageCount == 2){
							pageCount --;
							pages[pageCount].SetActive(true);
							buttons[0].SetActive(true);
							buttons[2].SetActive(false);
						}
					}
					else if(hit.collider.name == "Back"){
						Application.LoadLevel(0);
					}
				}
			}
		}
//		/*for(int i = 0; i < Input.touchCount; i++)
//			{
//				//executes this code for current touch (i)
//				if(this.guiTexture.HitTest(Input.GetTouch(i).position))
//				{
//					//if current touch hits guitexture, run this code
//					if(Input.GetTouch(i).phase == TouchPhase.Began)
//					{
//						Debug.Log("The touch has begun on" + this.name);
//					}
//
//					if(Input.GetTouch(i).phase == TouchPhase.Ended)
//					{
//						Camera.main.GetComponent<FadeScript>().fadingOut = true;
//						Debug.Log("The touch has ended on" + this.name);
//
//						if(this.name == "Button_Play")
//						{
//							switchCountdown = true;
//							sceneNumber = 1;
//						}
//						if(this.name == "Button_Options")
//						{
//							switchCountdown = true;
//							sceneNumber = 2;
//						}
//						if(this.name == "Button_Exit")
//						{
//							Application.Quit();
//						}
//					}
//				}
	}
}
