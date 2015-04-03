using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Transform projectileSpawnLocation;
	public int bulletSpeed;
	public Rigidbody projectile;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				Vector3 shootAt = new Vector3(hit.point.x, gameObject.transform.position.y, hit.point.z);
				gameObject.transform.LookAt(shootAt);
			}
			SpawnBullet();
		}
	}

	void SpawnBullet () {
		Rigidbody instance = Instantiate (projectile, projectileSpawnLocation.position, transform.rotation) as Rigidbody;
		instance.AddForce (instance.gameObject.transform.forward * bulletSpeed);
		instance.GetComponent<Projectile> ().damage = gameObject.GetComponent<UnitStats> ().unitStrength;
	}
}
