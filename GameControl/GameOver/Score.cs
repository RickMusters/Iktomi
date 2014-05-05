using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int nightmaresTapped;
	public int dreamsTapped;
	private GUIStyle style;

	public int score;
	public int nightmareScore;
	public int dreamScore;

	void  Update(){
		scoreTo ();
	}

	 public void scoreTo(){
		nightmareScore = nightmaresTapped * 10;
		dreamScore = dreamsTapped * 10;
		score = nightmareScore - dreamScore;
		if(score <= 0)
		{
			score = 0;
		}

	}
}
