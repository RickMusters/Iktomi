using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {


	// -- Properties -- //

	// Range
	public bool inRange = false;

	// Audio
	public AudioClip[] sound;

	// -- Vars -- //

	public void AudioFunc(int pitch)
	{
		// Pitch Amount
		int p = pitch;

		if(p < 5)
		{
			AudioSource.PlayClipAtPoint(sound[p -1], transform.position);
		}
		else if(p >= 5)
		{
			AudioSource.PlayClipAtPoint(sound[4], transform.position);
		}
	}
}
