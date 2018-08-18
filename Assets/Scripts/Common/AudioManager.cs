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
    AudioSource intro;

    public void BallRolling(float force)
    {
        if(rolling == null)
        {
            if (force == 0f) return;
            string num = Random.Range(1, 4).ToString();
            rolling = CreateEffect("Ball_Rolling" + num);
            if(rolling != null) rolling.volume = force;
        }
        else if(force == 0f || !rolling.isPlaying)
        {
            if(rolling != null)
                Destroy(rolling.gameObject);
            rolling = null;
        }
        else
            rolling.volume = force;
    }

    public void BallCollision(float force)
    {
        if (force < 0.3f) return;
        AudioSource c = CreateEffect("Ball_Collision");
        c.volume = force;
    }
    public void GoalEntered()
    {
        if(enter != null)               //Why should this code be alive????
            Destroy(enter.gameObject);
        enter = CreateEffect("Ball_IntoGoal");
    }
    public void GoalExited()
    {
        if(enter != null)
            Destroy(enter.gameObject);
        enter = CreateEffect("Ball_OutfromGoal");
    }
    public void GamePause()
    {

    }
    public void GameStart()
    {
        string num = Random.Range(1, 3).ToString();
        intro = CreateEffect("Ball_Start" + num);
    }
    public void GameRestart()
    {

    }
    public void GameCleared()
    {

    }

    AudioSource CreateEffect(string path)
    {
        if (MainData.Instance().EffectMute) return null;
        GameObject effect = Instantiate(SoundEffect);
        effect.transform.SetParent(gameObject.transform);
        AudioClip clip = Resources.Load("Musics/" + path) as AudioClip;
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
