using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour {

    private static GameRuleManager instance;    //This is a singletone

	int ballNum = 0;
	GameObject[] balls;
	GameObject[] goals;
    float AllCheckedTime = 0f;
    bool AllChecked = false;

	public int GetBallNum() { return ballNum; }
	public GameObject GetBallObject(int index) { return balls[index]; }
	public GameObject[] GetBallObject() { return balls; }
	public GameObject GetGoalObject(int index) { return goals[index]; }
	public GameObject[] GetGoalObject() { return goals; }
    [SerializeField]
    static float ClearTime;

    private GameRuleManager() { }
    public static GameRuleManager Instance() {
        if (instance == null) return instance = new GameRuleManager();
        return instance;
    }

    private static void SingletonInitialize(GameRuleManager method)
    {
        if (instance == null)
            instance = method;
        else
        {
            Debug.Log("GameRuleManager should exist only one. Destroy.");
        }
    }

	public void GoalChecked()
	{
		ballNum--;
		if(ballNum == 0)		// The scripts when game ends
		{
			Debug.Log("The game almost goes end.");
            AllChecked = true;
		}
	}

	public void GoalUnChecked()
	{
		ballNum++;
        AllChecked = false;
	}

	// Use this for initialization
	void Awake () {
        SingletonInitialize(this);
        MapGenerator mapGenerator = GetComponent<MapGenerator>();
        int gameLv1 = MainData.Instance().gameLv1;
        int gameLv2 = MainData.Instance().gameLv2;
        mapGenerator.Generate(gameLv1, gameLv2);
        ballNum = mapGenerator.GoalNum;
        goals = GameObject.FindGameObjectsWithTag("Goal");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if (ClearTime == 0f)
            ClearTime = 1f;
	}
	
    void Update()
    {
        if (!AllChecked) return;

        if (AllCheckedTime > 1f)
        {
            Debug.Log("The game is end!");
            FindObjectOfType<GameUIManager>().LoadGameEndUI();
            foreach (GameObject obj in balls)
                obj.SetActive(false);
        }
        else AllCheckedTime += Time.deltaTime;
    }
}