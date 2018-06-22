using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {

	Gyroscope gyro;
	GameUIManager ui_;
	bool isGyroAble = true;
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
	/*
		     y+
		 	  |
		x- <-  -> x+
	*/
	Vector3 CalculateGyro()
	{
		return Input.acceleration * 90;
	}

	// Use this for initialization
	void Start () {
		ui_ = GameObject.Find("EventSystem").GetComponent<GameUIManager>();
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			Debug.Log("Gyroscope is found successfully.");
			isGyroAble = true;
		}
		else
		{
			Debug.Log("Gyroscope is not found.");
			isGyroAble = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isGyroAble && time > 0.1f)
		{
			time = 0f;
			Vector3 v = CalculateGyro();
			ui_.UpdateTexts(v.x, v.y, v.z);
			Movement(v);
		}
		else if (!isGyroAble && time > 0.1f)
		{
			time = 0f;
			DebugMovement();
		}
		else
			time += Time.deltaTime;
	}
}
