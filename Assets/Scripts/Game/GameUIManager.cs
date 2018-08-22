using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Must be attached to canvas
public class GameUIManager : MonoBehaviour {

    private static GameUIManager instance;
	Text XText, YText, ZText;		//Shows forces of accelerometer
	GameObject canvas;		//The canvas which attaches it

	[SerializeField]
	GameObject ballImg;
	[SerializeField]
	GameObject goalImg;
	[SerializeField]
	GameObject goalClearImg;
	[SerializeField]
	GameObject[] wallImg;
	GameObject[] ballImgs;
	GameObject[] goalImgs;
	GameObject[] wallImgs;

	[SerializeField]
	GameObject fin;
	[SerializeField]
	GameObject defeat;
	[SerializeField]
	GameObject escape;

    public static GameUIManager Instance() { return instance; }

	void Start () {
        if (instance == null) instance = this;
        else return;
		XText = transform.Find("XRateText").GetComponent<Text>();
		YText = transform.Find("YRateText").GetComponent<Text>();
		ZText = transform.Find("ZRateText").GetComponent<Text>();
		canvas = this.gameObject;
		ballImgs = new GameObject[GameRuleManager.Instance().GetBallNum()];
		goalImgs = new GameObject[GameRuleManager.Instance().GetBallNum()];
		wallImgs = new GameObject[GameRuleManager.Instance().GetWallObject().Length];

		for (int i = 0; i < ballImgs.Length; i++)
		{
			ballImgs[i] = Instantiate(ballImg, canvas.transform);
			goalImgs[i] = Instantiate(goalImg, canvas.transform);
            HangImgOnScreen(GameRuleManager.Instance().GetGoalObject(i), goalImgs[i].GetComponent<Image>());
		}
        Transform Walls = canvas.transform.Find("Walls");
        for (int i = 0; i < wallImgs.Length; i++)
        {
            wallImgs[i] = Instantiate(wallImg[Random.Range(0, 6)], Walls);
            HangImgOnScreen(GameRuleManager.Instance().GetWallObject(i), wallImgs[i].GetComponent<Image>());
        }
        foreach(GameObject obj in goalImgs)
            obj.transform.SetAsLastSibling();
	}
	
	void Update () {
		for (int i = 0; i < ballImgs.Length; i++)
        {
            HangImgOnScreen(GameRuleManager.Instance().GetBallObject(i), ballImgs[i].GetComponent<Image>());
        }

	}

    Vector3 GetImagePos(GameObject obj)
    {
		Vector3 objPos = Camera.main.WorldToViewportPoint(obj.transform.position);
		RectTransform CanvasRect = canvas.GetComponent <RectTransform>();
		objPos.x = objPos.x * CanvasRect.sizeDelta.x - CanvasRect.sizeDelta.x * 0.5f;
		objPos.y = objPos.y * CanvasRect.sizeDelta.y - CanvasRect.sizeDelta.y * 0.5f;
        return objPos;
    }

	void HangImgOnScreen(GameObject obj, Image img)
	{
		img.rectTransform.anchoredPosition = GetImagePos(obj);
	}

    public void GoalImageChange(GameObject goal, bool isEntered)
    {
        Vector3 pos3 = GetImagePos(goal);
        Vector2 pos2 = new Vector2(pos3.x, pos3.y);
        foreach(GameObject obj in goalImgs)
        {
            Image img = obj.GetComponent<Image>();
            if(img.rectTransform.anchoredPosition == pos2)
                img.sprite = isEntered ? 
                    goalClearImg.GetComponent<Image>().sprite : 
                    goalImg.GetComponent<Image>().sprite;
        }
    }
	
	const string prefix = "rate: ";

	public void UpdateTexts(float Xrate, float Yrate, float Zrate)
	{
		XText.text = "X" + prefix + Xrate.ToString();
		YText.text = "Y" + prefix + Yrate.ToString();
		ZText.text = "Z" + prefix + Zrate.ToString();
	}

    public void GamePaused()
    {
		escape.transform.SetAsLastSibling();
        escape.SetActive(true);
    }
    public void GamePlaying()
    {
        escape.SetActive(false);
    }
    public void GameDefeated()
    {
        defeat.SetActive(true);
    }
    public void GameCleared()
    {
		fin.transform.SetAsLastSibling();
		fin.SetActive(true);
    }

}
