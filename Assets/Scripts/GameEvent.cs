using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour {
	
	public void OnClickExit(Button button)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
	}
}

