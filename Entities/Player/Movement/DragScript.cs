using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

	public float dragSpeed = 0.1f;
	
	void Update () 
	{
		if(Input.touchCount >0)
		{
			Touch touch = Input.GetTouch(0);
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{

				Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x,touch.position.y ));
				transform.position = Vector2.Lerp(transform.position, newPos, Time.deltaTime * dragSpeed);

			}
		}
	}
}
