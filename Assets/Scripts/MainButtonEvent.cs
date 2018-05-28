using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonEvent : MonoBehaviour {

	public void OnClickGameStart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");		//Need to be modified.
	}

	public void OnClickSetting()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Setting");		//Need to be modified.
	}
	
	public void OnClickExit()
	{
		Application.Quit();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
