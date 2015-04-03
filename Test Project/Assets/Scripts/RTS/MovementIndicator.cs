using UnityEngine;
using System.Collections;

public class MovementIndicator : MonoBehaviour {
	public float time;
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (time < timer) {
			Destroy(gameObject);
		}
	}
}
