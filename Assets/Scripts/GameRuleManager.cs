using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour {

	static int ballNum = 0;
	static public int gameLv1 = 1;
	static public int gameLv2 = 1;
	static GameObject[] balls;
	static GameObject[] goals;
    static float AllCheckedTime = 0f;
    static bool AllChecked = false;

	public static int GetBallNum() { return ballNum; }
	public static GameObject GetBallObject(int index) { return balls[index]; }
	public static GameObject[] GetBallObject() { return balls; }
	public static GameObject GetGoalObject(int index) { return goals[index]; }
	public static GameObject[] GetGoalObject() { return goals; }

    [SerializeField]
    static float ClearTime;

	//Deprecated.
	void SetCameraPosition() { return; }

	public static void GoalChecked()
	{
		ballNum--;
		if(ballNum == 0)		// The scripts when game ends
		{
			Debug.Log("The game almost goes end.");
            AllChecked = true;
		}
	}

	public static void GoalUnChecked()
	{
		ballNum++;
        AllChecked = false;
	}

	// Use this for initialization
	void Awake () {
		MapGenerator mapGenerator = GetComponent<MapGenerator>();
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