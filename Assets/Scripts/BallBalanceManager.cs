using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBalanceManager : MonoBehaviour {

	Quaternion rotInit;

	private void OnCollisionEnter(Collision collision)
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}
	// Use this for initialization
	void Start () {
		rotInit = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
