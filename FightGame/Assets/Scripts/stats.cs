using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

    // Use this for initialization
    Equipment myEquipment;
    GameObject myWeapon;
    Weapon currentWeapon;
    public float damageMultiplier;
	public string myName;
	public int strength;
	public int intelligence;
    public int dexterity;
    public int baseStrength;
    public int baseIntelligence;
    public int baseDexterity;
    public int currentHP;
	public int maxHP;
    public int baseMaxHP;
    public int level;
    public int currentXP;
    public string job;
    string weaponType;

    public int damage;

	void Awake (){
        myEquipment = GetComponent<Equipment>();
        myWeapon = myEquipment.weapon;
        strength = baseStrength;
        intelligence = baseIntelligence;
        dexterity = baseDexterity;
        maxHP = baseMaxHP;
        currentHP = maxHP;

    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int CalculateAttackDamage()
    {
        myWeapon = myEquipment.weapon;
        currentWeapon = myWeapon.GetComponent<Weapon>();
        weaponType = currentWeapon.type;
        if (weaponType == "Melee") {
            damage = strength + currentWeapon.bonusDamage;
            Debug.Log("Melee");
        }
        else if (weaponType == "Ranged")
        {
            damage = dexterity + currentWeapon.bonusDamage;
            Debug.Log("Ranged");
        }
        else if (weaponType == "Magic")
        {
            damage = intelligence + currentWeapon.bonusDamage;
            Debug.Log("Magic");
        }
        int damageRoll = Random.Range(damage, (int)((float)damage * damageMultiplier));
        Debug.Log("" + damageRoll);
        return damageRoll;

    }

    public void CheckForLevelUp ()
    {

    }

    void GainLevelBonuses()
    {

    }

    public void CheckForDeath ()
    {
        if (currentHP <= 0) {
            Debug.Log("Unit Died");
            //Destroy(gameObject);
        }
    }
}
