using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	Mesh Capsule;
    bool isChecked = false;
	// Use this for initialization
	void Start () {
		Capsule = GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.transform.name.Contains("Ball"))
		{
            if (isChecked) return;
            GameRuleManager.Instance().GoalChecked(collider.gameObject);
			//Destroy(gameObject);
			GetComponent<MeshFilter>().mesh = null;
            //GetComponent<CapsuleCollider>().enabled = false;
            isChecked = true;
            AudioManager.Instance().GoalEntered();
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if(collider.transform.name.Contains("Ball"))
		{
            if (!isChecked) return;
            GameRuleManager.Instance().GoalUnChecked(collider.gameObject);
			//Destroy(gameObject);
			GetComponent<MeshFilter>().mesh = Capsule;
			GetComponent<CapsuleCollider>().enabled = true;
            isChecked = false;
            AudioManager.Instance().GoalExited();
		}
	}
}
