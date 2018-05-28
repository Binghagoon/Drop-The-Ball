using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.name.Contains("Ball"))
		{
			GameObject.Find("EventSystem").GetComponent<GameRuleManager>().GoalDelete();
			Destroy(gameObject);
		}
	}
}
