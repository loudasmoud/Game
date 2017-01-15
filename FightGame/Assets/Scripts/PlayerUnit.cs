using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour {

    public GameObject player;
    GameObject healthBar;
    public GameObject healthBarUI;
    public GameObject overlord;
    Selector overlordSelector;
    PlayerParty party;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        party = player.GetComponent<PlayerParty>();
    }

    // Use this for initialization
    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartBattle()
    {
        Debug.Log("Battle Started PLAYER");
        overlord = GameObject.FindGameObjectWithTag("UnitSelector");
        overlordSelector = overlord.GetComponent<Selector>();
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //overlordSelector.playerUnits.Add(gameObject);
        CreateHealthBar();
        SetPlayerUnitPosition();

    }

    public void EndBattle()
    {
        //clean up the unit from the screen, also remove health bar
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(healthBar);
    }

    private void OnMouseDown()
    {
        //need to be able to target allies for healing
    }

    public void CreateHealthBar()
    {
        healthBar = Instantiate(healthBarUI);
        healthBar.GetComponent<HealthBar>().unit = gameObject;
        healthBar.transform.SetParent(GameObject.FindGameObjectWithTag("Player Stat Display").transform);
        healthBar.transform.localPosition = new Vector3(-3, 50 - (overlordSelector.playerUnits.IndexOf(gameObject) * 20));
    }

    public void SetPlayerUnitPosition()
    {
        gameObject.transform.localPosition = new Vector3(-15, 3 - (overlordSelector.playerUnits.IndexOf(gameObject) *2));
    }


}
