using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour {

	int goalNum = 0;
	void SetCameraPosition()
	{
		return;
	}

	public void GoalDelete()
	{
		goalNum--;
		if(goalNum == 0)		// The scripts when game ends
		{
			Debug.Log("The game is end.");
			return;
		}
	}

	// Use this for initialization
	void Start () {
		MapGenerator mapGenerator = GetComponent<MapGenerator>();
		mapGenerator.Generate();
		goalNum = mapGenerator.GoalNum;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
