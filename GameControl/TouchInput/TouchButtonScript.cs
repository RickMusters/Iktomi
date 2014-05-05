using UnityEngine;
using System.Collections;

public class TouchButtonScript : MonoBehaviour {
	

	void Update () 
	{
		//is there a touch on screen?
		if(Input.touches.Length <= 0)
		{

		}

		else //if there is a touch
		{
			//loop through all the touches
			for(int i = 0; i < Input.touchCount; i++)
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
						Debug.Log("The touch has ended on" + this.name);
						if(this.name == "Play")
						{
							Application.LoadLevel("scene");
						}
						if(this.name == "Options")
						{
							Debug.Log("Options touched");
						}
					}
				}
			}
		}
	}
}
