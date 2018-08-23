using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus { Playing, Paused, Defeated, Cleared };
public class GameRuleManager : MonoBehaviour {

    private static GameRuleManager instance;    //This is a singletone

	int ballNum = 0;
	GameObject[] balls;
	GameObject[] goals;
	GameObject[] walls;
    float AllCheckedTime = 0f;
    bool AllChecked = false;
    GameUIManager _ui;

    public GameObject[] GetBalls() { return balls; }
    public GameObject[] GetGoals() { return goals; }
    public GameObject[] GetWalls() { return walls; }

	public int GetBallNum() { return ballNum; }
	public GameObject GetBallObject(int index) { return balls[index]; }
	public GameObject[] GetBallObject() { return balls; }
	public GameObject GetGoalObject(int index) { return goals[index]; }
	public GameObject[] GetGoalObject() { return goals; }
	public GameObject GetWallObject(int index) { return walls[index]; }
	public GameObject[] GetWallObject() { return walls; }

    [SerializeField]
    static float ClearTime;
    GameStatus status = GameStatus.Playing;
    GameStatus GetStatus() { return status; }
    private void SetStatus(GameStatus status)
    {
        this.status = status;
        StatusChanged();
    }

    public static GameRuleManager Instance() { return instance; }

	public void GoalChecked(GameObject goal)
	{
		ballNum--;
		if(ballNum == 0)		// The scripts when game ends
		{
			Debug.Log("The game almost goes to end.");
            AllChecked = true;
		}
        _ui.GoalImageChange(goal, true);
        AudioManager.Instance().GoalEntered();
	}
	public void GoalUnChecked(GameObject goal)
	{
		ballNum++;
        AllChecked = false;
        AllCheckedTime = 0;
        _ui.GoalImageChange(goal, false);
        AudioManager.Instance().GoalExited();
	}

    void StatusChanged()
    {
        if (status == GameStatus.Paused)
        {
            GameUIManager.Instance().GamePaused();
            InputController.Instance().GamePaused();
        }
        else if (status == GameStatus.Playing)
        {
            GameUIManager.Instance().GamePlaying();
            InputController.Instance().GamePlaying();
        }
        else if (status == GameStatus.Defeated)
        {
            //GameUIManager.Instance().GameDefeated();
            InputController.Instance().GameDefeated();
        }
        else
        {
            SetGameObject(true);
            AllChecked = false;
            GameUIManager.Instance().GameCleared();
            InputController.Instance().GameCleared();

        }

    }

    public void EscapePushed()
    {
        if(status == GameStatus.Playing)
        {
            SetStatus(GameStatus.Paused);
        }
        else if(status == GameStatus.Paused)
        {
            SetStatus(GameStatus.Playing);
        }
        else
        {
            //TBD
        }
    }
    public void GamePause() { SetGameObject(false); }
    public void GameDepause() { SetGameObject(true); }


    private void SetGameObject(bool isActive)
    {
        if(isActive)
        {
            foreach (GameObject obj in balls)
                obj.SetActive(true);
        }
        else
        {
            foreach (GameObject obj in balls)
                obj.SetActive(false);
        }
    }

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else return;
        MapGenerator mapGenerator = GetComponent<MapGenerator>();
        int gameLv1 = MainData.Instance().gameLv1;
        int gameLv2 = MainData.Instance().gameLv2;
        mapGenerator.Generate(gameLv1, gameLv2);
        ballNum = mapGenerator.GoalNum;
        goals = GameObject.FindGameObjectsWithTag("Goal");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        walls = GameObject.FindGameObjectsWithTag("Wall");
        if (ClearTime == 0f)
            ClearTime = 1f;
        _ui = FindObjectOfType<GameUIManager>();
        AudioManager.Instance().GameStart();
	}
	
    void Update()
    {
        if (!AllChecked) return;

        if (AllCheckedTime > 1f)
            SetStatus(GameStatus.Cleared);
        else AllCheckedTime += Time.deltaTime;
    }
}