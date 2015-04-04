using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour {
	public GameObject player;
	UnitStats playerStats;
	public Slider playerHealthBar;
	float currentHP;
	float maxHP;

	// Use this for initialization
	void Start () {
		playerStats = player.GetComponent<UnitStats> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		playerHealthBar.maxValue = playerStats.unitMaxHealth;
		playerHealthBar.value = playerStats.unitCurrentHealth;
	}
}
