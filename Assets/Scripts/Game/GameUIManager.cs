﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Must be attached to canvas
public class GameUIManager : MonoBehaviour {

	Text XText, YText, ZText;		//Shows forces of accelerometer
	GameObject canvas;		//The canvas which attaches it

	[SerializeField]
	GameObject ballImg;
	[SerializeField]
	GameObject goalImg;
	GameObject[] ballImgs;
	GameObject[] goalImgs;

	[SerializeField]
	GameObject fin;

	[SerializeField]
	GameObject escape;

    public void EscapePushed()
    {
		escape.transform.SetAsLastSibling();
        escape.SetActive(!escape.activeSelf);
    }

	void Start () {
		XText = transform.Find("XRateText").GetComponent<Text>();
		YText = transform.Find("YRateText").GetComponent<Text>();
		ZText = transform.Find("ZRateText").GetComponent<Text>();
		canvas = this.gameObject;
		ballImgs = new GameObject[GameRuleManager.Instance().GetBallNum()];
		goalImgs = new GameObject[GameRuleManager.Instance().GetBallNum()];

		for (int i = 0; i < GameRuleManager.Instance().GetBallNum(); i++)
		{
			ballImgs[i] = Instantiate(ballImg, canvas.transform);
			goalImgs[i] = Instantiate(goalImg, canvas.transform);
		}
        foreach(GameObject obj in goalImgs)
            obj.transform.SetAsLastSibling();
	}
	
	void Update () {
		for (int i = 0; i < ballImgs.Length; i++)
        {
            HangImgOnScreen(GameRuleManager.Instance().GetBallObject(i), ballImgs[i].GetComponent<Image>());
            HangImgOnScreen(GameRuleManager.Instance().GetGoalObject(i), goalImgs[i].GetComponent<Image>());
        }

	}

	void HangImgOnScreen(GameObject obj, Image img)
	{
		Vector3 objPos = Camera.main.WorldToViewportPoint(obj.transform.position);
		RectTransform CanvasRect = canvas.GetComponent <RectTransform>();
		objPos.x = objPos.x * CanvasRect.sizeDelta.x - CanvasRect.sizeDelta.x * 0.5f;
		objPos.y = objPos.y * CanvasRect.sizeDelta.y - CanvasRect.sizeDelta.y * 0.5f;
		img.rectTransform.anchoredPosition = objPos;
	}

	
	const string prefix = "rate: ";

	public void UpdateTexts(float Xrate, float Yrate, float Zrate)
	{
		XText.text = "X" + prefix + Xrate.ToString();
		YText.text = "Y" + prefix + Yrate.ToString();
		ZText.text = "Z" + prefix + Zrate.ToString();
	}

	public void LoadGameEndUI()
	{
		fin.transform.SetAsLastSibling();
		fin.SetActive(true);
	}
}