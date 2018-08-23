using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Must be attached to canvas
public class GameUIManager : MonoBehaviour {

    private static GameUIManager instance;
	Text XText, YText, ZText;		//Shows forces of accelerometer
	public static GameObject canvas;		//The canvas which attaches it

    [SerializeField]
    GameObject Sprite2D;
    [SerializeField]
    Sprite BallImage;
    [SerializeField]
    Sprite GoalImage;
    [SerializeField]
    Sprite GoalClearImage;
    [SerializeField]
    Sprite[] WallImage;
    [SerializeField]
    Sprite Wall_movableImage;
    [SerializeField]
    Sprite TrapImage;

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
        Random.InitState(65819200);

        foreach(GameObject obj in GameRuleManager.Instance().GetBalls())
            CreateHanger(obj, BallImage, new Vector3(0.6f, 0.6f, 0.6f));

        foreach(GameObject obj in GameRuleManager.Instance().GetGoals())
            CreateHanger(obj, GoalImage, new Vector3(1, 1.5f, 1));

        foreach(GameObject obj in GameRuleManager.Instance().GetWalls())
            CreateHanger(obj, WallImage[Random.Range(0, WallImage.Length)], new Vector3(0.75f, 0.75f, 0.75f));
	}

    void CreateHanger(GameObject target, Sprite sprite, Vector3 scale)
    {
            GameObject hanger = Instantiate(Sprite2D, canvas.transform) as GameObject;
            hanger.GetComponent<ImageHanger>().
                Initialize(target, sprite, scale);
    }

    public void GoalImageChange(GameObject goal, bool isEntered)
    {
        CreateHanger(goal, isEntered ? GoalClearImage : GoalImage, new Vector3(1, 1.5f, 1));
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
