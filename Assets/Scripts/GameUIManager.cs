using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	const string prefix = "rate: "; 
	Text XText, YText, ZText;

	void Start () {
		XText = GameObject.Find("XRateText").GetComponent<Text>();
		YText = GameObject.Find("YRateText").GetComponent<Text>();
		ZText = GameObject.Find("ZRateText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateTexts(float Xrate, float Yrate, float Zrate)
	{
		XText.text = "X" + prefix + Xrate.ToString();
		YText.text = "Y" + prefix + Yrate.ToString();
		ZText.text = "Z" + prefix + Zrate.ToString();
	}
}
