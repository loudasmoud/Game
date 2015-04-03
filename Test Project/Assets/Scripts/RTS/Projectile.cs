using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float lifetime;
	public int damage;
	// Use this for initialization
	void Awake () {
		Destroy (gameObject, lifetime);	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<UnitStats>().unitCurrentHealth-= damage;
			Destroy (gameObject);

		}
		if (col.gameObject.tag != "Player") {
			Destroy (gameObject);
		}
	}
}
