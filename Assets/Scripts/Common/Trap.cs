﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Ball"))
        {
		    UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
        }
    }
}
