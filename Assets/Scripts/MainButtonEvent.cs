using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtonEvent : MonoBehaviour {

	[SerializeField]
	GameObject levelSelector;

    bool isOnce = false;

	public void OnClickGameStart()
	{
		levelSelector.SetActive(true);
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
			MainData.Instance().gameLv1 = int.Parse(char.ToString(inputField.text[0]));
			MainData.Instance().gameLv2 = int.Parse(char.ToString(inputField.text[2]));
			Debug.Log("setting the level is complete.");
		}
	}

	public void OnClickLvSelectorExit()
	{
		levelSelector.SetActive(false);
	}

	public void OnClickStageButton(Button button)
	{
		string lv1 = button.transform.parent.name.Substring(5);
		Debug.Log(lv1);
		string lv2 = button.name.Substring(1);
		Debug.Log(lv2);
		MainData.Instance().gameLv1 = int.Parse(lv1);
		MainData.Instance().gameLv2 = int.Parse(lv2);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!isOnce)
                Application.Quit();
            else
            {
                Debug.Log("Game will be exited if escape key is pressed once more.");
                isOnce = true;
            }
        }
    }
}
