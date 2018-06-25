using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour {

	static int ballNum = 0;
	static public int gameLv1 = 1;
	static public int gameLv2 = 1;
	static GameObject[] balls;
	static GameObject[] goals;

	public static int GetBallNum() { return ballNum; }
	public static GameObject GetBallObject(int index) { return balls[index]; }
	public static GameObject[] GetBallObject() { return balls; }
	public static GameObject GetGoalObject(int index) { return goals[index]; }
	public static GameObject[] GetGoalObject() { return goals; }

	//Deprecated.
	void SetCameraPosition() { return; }

	public void GoalChecked()
	{
		ballNum--;
		if(ballNum == 0)		// The scripts when game ends
		{
			Debug.Log("The game is end.");
			FindObjectOfType<GameUIManager>().LoadGameEndUI();
			foreach(GameObject obj in balls)
			{
				obj.SetActive(false);
			}
			return;
		}
	}

	public void GoalUnChecked()
	{
		ballNum++;
	}

	// Use this for initialization
	void Awake () {
		MapGenerator mapGenerator = GetComponent<MapGenerator>();
		mapGenerator.Generate(gameLv1, gameLv2);
		ballNum = mapGenerator.GoalNum;
		goals = GameObject.FindGameObjectsWithTag("Goal");
		balls = GameObject.FindGameObjectsWithTag("Ball");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
