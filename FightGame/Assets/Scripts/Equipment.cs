using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
    /// <summary>
    /// Items equiped on current unit
    /// Save bonuses in one value to be output to the units stats. Add that value to it's base max HP, not current max HP (to avoid doubling up)
    /// 
    /// </summary>
    public GameObject weapon;
    public GameObject chest;
    public GameObject head;
    public GameObject feet;
    public GameObject offhand;
    int tempInt;

    public int bonusInt;
    public int bonusHP;
    public int bonusDex;
    public int bonusStr;
    public int bonusDamage;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UpdateBonuses();
	}

    void UpdateBonuses()
    {
        if (chest)
        {
            bonusInt = chest.GetComponent<Armor>().bonusInt;
        }
        //tempInt = gameObject.GetComponent<stats>().intelligence;
        gameObject.GetComponent<stats>().intelligence = gameObject.GetComponent<stats>().baseIntelligence + bonusInt;
    }
}
