using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	Mesh Capsule;
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
			GameObject.Find("EventSystem").GetComponent<GameRuleManager>().GoalChecked();
			//Destroy(gameObject);
			GetComponent<MeshFilter>().mesh = null;
			//GetComponent<CapsuleCollider>().enabled = false;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if(collider.transform.name.Contains("Ball"))
		{
			GameObject.Find("EventSystem").GetComponent<GameRuleManager>().GoalUnChecked();
			//Destroy(gameObject);
			GetComponent<MeshFilter>().mesh = Capsule;
			GetComponent<CapsuleCollider>().enabled = true;
		}
	}
}
