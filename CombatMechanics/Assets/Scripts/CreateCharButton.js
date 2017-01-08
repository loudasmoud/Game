#pragma strict
import UnityEngine.UI;

public var minimumCharacters : int;

var button : Button;
var nameInputField : InputField;
button = GetComponent("Button");

function Start () {

}
//check for name length

public function Enabler() {
	Debug.Log(nameInputField.textComponent.text.Length);
	button.interactable = false;
	var inputLength : int = nameInputField.textComponent.text.Length;
	if (inputLength >= minimumCharacters){
		button.interactable = true;
	}
	
}

function Update () {

}