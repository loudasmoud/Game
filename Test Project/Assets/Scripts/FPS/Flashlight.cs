using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public GameObject playerCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = playerCamera.transform.rotation;
	}
}
