#pragma strict

	//
	//Jobs: 0 = squire, 1 = apprentice
	//
	public var firstJob : int = 0;
	
	public var baseUnit : GameObject;
	public var nameInput : UI.InputField;
	
@SerializeField
	private var baseName : System.String = "baseName";
@SerializeField
	private var baseHealth : int = 50;
@SerializeField
	private var baseStrMin : int = 5;
@SerializeField
	private var baseStrMax : int = 10;
@SerializeField
	private var baseWisMin : int = 5;
@SerializeField
	private var baseWisMax : int = 10;
@SerializeField
	private var baseXp : int = 0;
	//to do:
	// randomize str/wis 
	

function Start () {

}

public function createNewCharacter () {
	//check if name is long enough
	
	//check if you have enough money
	
	//baseName = nameInput.text;
	var newCharacter = GameObject.Instantiate(baseUnit);
	var newCharStats = newCharacter.GetComponent(stats);
	newCharStats.strength = Random.Range(baseStrMin, baseStrMax);
	newCharStats.wisdom = Random.Range(baseWisMin, baseWisMax);
	newCharStats.myName = nameInput.text;
	
}

function Update () {

}