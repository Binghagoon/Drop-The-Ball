using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;
    private AudioManager() { }
    public static AudioManager Instance() { return instance; }
    [SerializeField]
    GameObject SoundEffect;
    AudioSource rolling;
    AudioSource enter;

    public void BallRolling(float force)
    {
        if(rolling == null)
        {
            if (force == 0f) return;
            string num = Random.Range(1, 4).ToString();
            rolling = CreateEffect("Musics/Ball_Rolling" + num);
            rolling.volume = force;
        }
        else if(force == 0f || !rolling.isPlaying)
        {
            Destroy(rolling.gameObject);
            rolling = null;
        }
        else
            rolling.volume = force;
    }
    public void GoalEntered()
    {
        Destroy(enter.gameObject);
        enter = CreateEffect("Musics/Ball_IntoGoal");
    }
    public void GoalExited()
    {
        Destroy(enter.gameObject);
        enter = CreateEffect("Musics/ball_OutfromGoal");
    }
    public void GamePause()
    {

    }
    public void GameStart()
    {
        string num = Random.Range(1, 3).ToString();
        CreateEffect("Musics/Ball_Start" + num);
    }
    public void GameRestart()
    {

    }
    public void GameCleared()
    {

    }

    AudioSource CreateEffect(string path)
    {
        GameObject effect = Instantiate(SoundEffect);
        effect.transform.SetParent(gameObject.transform);
        AudioClip clip = Resources.Load(path) as AudioClip;
        effect.GetComponent<AudioSource>().clip = clip;
        effect.GetComponent<AudioSource>().Play();
        return effect.GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
