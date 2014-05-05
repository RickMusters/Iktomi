using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {
	public GameObject[] player;
	private int playerIndex = 0;
	public int lifes = 4;


	public void KillPlayer(){
		if(lifes == 1 || lifes == 2 || lifes == 3 || lifes == 4)
		{
			lifes --;
			Destroy(player[playerIndex]);
			playerIndex++;
		}
	}
}
