using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtonEvent : MonoBehaviour {

	public void OnClickGameStart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

	public void OnClickSetting()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Setting");		//Need to be modified.
	}
	
	public void OnClickExit()
	{
		Application.Quit();
	}

	public void OnDebugLvSelectorExit(InputField inputField)
	{
		string text = inputField.text;
		if(	text.Length != 3
			|| inputField.text[1] != '-'
			|| !char.IsNumber(text[0])
			|| !char.IsNumber(text[2])) {
			Debug.Log("The input field is wrong.");
			inputField.text = "";
		}
		else {
			GameRuleManager.gameLv1 = int.Parse(char.ToString(inputField.text[0]));
			GameRuleManager.gameLv2 = int.Parse(char.ToString(inputField.text[2]));
			Debug.Log("setting the level is complete.");
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
