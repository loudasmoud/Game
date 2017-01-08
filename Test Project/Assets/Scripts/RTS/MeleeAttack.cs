using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	Animator anim;
	Transform weapon;
	int swing;
	// Use this for initialization
	void Start () {
		foreach (Transform children in transform) {
			if (children.CompareTag("MeleeWeapon")){
			    weapon = children;
				anim = weapon.GetComponent<Animator>();
				Debug.Log(weapon);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				Vector3 lookDelta = (hit.point - this.transform.position);
				Quaternion targetRotation = Quaternion.LookRotation(lookDelta);
				Quaternion.RotateTowards(transform.rotation, targetRotation, 10);
			}

			anim.SetTrigger("Swing");
		}
	
	}
}
