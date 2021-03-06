﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {
    
    //Deprecated
    /*
	GameUIManager ui_;
	bool IsAccelerometerAble = true;
	float horizontal = 0f;
	float vertical = 0f;
	float speed = 3f;
	float time = 0f;

	void AddVectorForce(Vector2 vec, double force)
	{
		GetComponent<Rigidbody>().AddForce(new Vector3(vec.x, 0, vec.y));
		//GetComponent<Rigidbody>().Force
	}

	void DebugMovement()
	{
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		//GetComponent<Transform>().Translate(new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime));
		GetComponent<Rigidbody>().velocity = new Vector3(horizontal * speed , 0, vertical * speed);
	}

	void Movement(Vector3 ac)
	{
		horizontal = ac.x;
		vertical = ac.y;

		GetComponent<Transform>().Translate(new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime));
	}
	//
	//	     y+
	//	 	  |
	//	x- <-  -> x+
	//
	Vector3 Accelerometer()
	{
		return Input.acceleration * 90;
	}

	// Use this for initialization
	void Start () {
		ui_ = GameObject.Find("EventSystem").GetComponent<GameUIManager>();
		if (SystemInfo.supportsAccelerometer)
		{
			Debug.Log("Accelerometer is found successfully.");
			IsAccelerometerAble = true;
		}
		else
		{
			Debug.Log("Accelerometer is not found.");
			IsAccelerometerAble = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAccelerometerAble && time > 0.1f)
		{
			time = 0f;
			Vector3 v = Accelerometer();
			ui_.UpdateTexts(v.x, v.y, v.z);
			Movement(v);
		}
		else if (!IsAccelerometerAble && time > 0.1f)
		{
			time = 0f;
			DebugMovement();
		}
		else
			time += Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.name.Contains("Goal")) return;

		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}*/
}
