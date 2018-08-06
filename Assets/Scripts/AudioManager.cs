using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;
    private AudioManager() { }
    public static AudioManager Instance() { return instance; }

    public void BallRollingStart(float force)
    {

    }
    public void BallRollingEnd()
    {

    }
    public void GoalEntered()
    {
        
    }
    public void GoalExited()
    {
        
    }
    public void GamePause()
    {

    }
    public void GameRestart()
    {

    }
    public void GameCleared()
    {

    }

	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
