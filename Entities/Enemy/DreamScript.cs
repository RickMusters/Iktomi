using UnityEngine;
using System.Collections;

public class DreamScript : MonoBehaviour {
	public AudioClip sound;
	public bool inRange = false;

	public void DeathSound(){
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}
