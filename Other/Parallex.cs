using UnityEngine;
using System.Collections;

public class Parallex : MonoBehaviour {

	public float scrollspeed = 0.5f;
	private float offset;
	private float rotate;

	void Update () {
		offset += (Time.deltaTime * scrollspeed)/10.0f;
		renderer.material.SetTextureOffset("_MainTex", new Vector2(offset,0));

	}
}
