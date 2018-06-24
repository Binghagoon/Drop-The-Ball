using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	const string prefix = "rate: "; 
	Text XText, YText, ZText;
	GameObject canvas;
	[SerializeField]
	GameObject ballImg;
	GameObject[] ballImgs;

	void Start () {
		XText = GameObject.Find("XRateText").GetComponent<Text>();
		YText = GameObject.Find("YRateText").GetComponent<Text>();
		ZText = GameObject.Find("ZRateText").GetComponent<Text>();
		canvas = GameObject.Find("Canvas");
		ballImgs = new GameObject[GameRuleManager.GetBallNum()];

		for (int i = 0; i < GameRuleManager.GetBallNum(); i++)
		{
			ballImgs[i] = Instantiate(ballImg, canvas.transform);
		}
	}
	
	void Update () {
		for (int i = 0; i < ballImgs.Length; i++)
			HangImgOnScreen(GameRuleManager.GetBallObject(i), ballImgs[i].GetComponent<Image>());
	}

	void HangImgOnScreen(GameObject obj, Image img)
	{
		Vector3 objPos = Camera.main.WorldToViewportPoint(obj.transform.position);
		RectTransform CanvasRect = canvas.GetComponent <RectTransform>();
		objPos.x = objPos.x * CanvasRect.sizeDelta.x - CanvasRect.sizeDelta.x * 0.5f;
		objPos.y = objPos.y * CanvasRect.sizeDelta.y - CanvasRect.sizeDelta.y * 0.5f;
		img.rectTransform.anchoredPosition = objPos;
	}

	
	public void UpdateTexts(float Xrate, float Yrate, float Zrate)
	{
		XText.text = "X" + prefix + Xrate.ToString();
		YText.text = "Y" + prefix + Yrate.ToString();
		ZText.text = "Z" + prefix + Zrate.ToString();
	}
}
