using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	const string prefix = "rate: "; 
	Text XText, YText, ZText;
	GameObject canvas;
	[SerializeField]
	Image ballImg;

	void Start () {
		XText = GameObject.Find("XRateText").GetComponent<Text>();
		YText = GameObject.Find("YRateText").GetComponent<Text>();
		ZText = GameObject.Find("ZRateText").GetComponent<Text>();
		canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 ballPos = Camera.main.WorldToViewportPoint(GameObject.Find("Ball(Clone)").transform.position);
		RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
		ballPos.x = ballPos.x * CanvasRect.sizeDelta.x - CanvasRect.sizeDelta.x * 0.5f;
		ballPos.y = ballPos.y * CanvasRect.sizeDelta.y - CanvasRect.sizeDelta.y * 0.5f;
		ballImg.rectTransform.anchoredPosition = ballPos;
		
	}

	void HangObjOnScreen()
	{
		
	}

	
	public void UpdateTexts(float Xrate, float Yrate, float Zrate)
	{
		XText.text = "X" + prefix + Xrate.ToString();
		YText.text = "Y" + prefix + Yrate.ToString();
		ZText.text = "Z" + prefix + Zrate.ToString();
	}
}
