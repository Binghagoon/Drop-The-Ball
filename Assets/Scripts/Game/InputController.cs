using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    
    private static InputController instance;
    bool isGyroAble;
    bool isPaused = false;
    float time = 0f;
    float esctime = 0f;
    public Vector3 Delta { get; private set; }
    GameUIManager _ui;

    protected InputController() { }

    public static InputController Instance() { return instance; }

    Vector3 ReducedAcceleration() {
        Vector3 ac = Input.acceleration;
        ac *= MainData.Instance().sensitivity;
        return new Vector3(ac.x, 0, ac.y);
    }

    Vector3 DebugController() {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void Quantization(Vector3 v) {
        if(v.x < 0.5) v.x = 0;
        if(v.y < 0.5) v.y = 0;
        if(v.z < 0.5) v.z = 0;
    }    

    void Awake() {
        if(instance == null)
        {
            if (SystemInfo.supportsAccelerometer) {
                Debug.Log("Accelerometer is found successfully.");
                isGyroAble = true;
            }
            else {
                Debug.Log("Accelerometer is not found.");
                isGyroAble = false;
            }
            _ui = FindObjectOfType<GameUIManager>();
            instance = this;
        }
        else return;       //TBD

    }

    public void PauseInput()
    {
        Delta = new Vector3();
        isPaused = true;
    }

    public void RestartInput()
    {
        isPaused = false;
        Update();
    }

    void Update() {
        if(instance != this)    return;

        if(isGyroAble && !isPaused)
        {
            Delta = ReducedAcceleration();
            _ui.UpdateTexts(Delta.x, Delta.y, Delta.z);
        }
        else if(!isPaused)
        {
            Delta = DebugController();
            _ui.UpdateTexts(Delta.x, Delta.y, Delta.z);
        }

        AudioManager.Instance().BallRolling(Delta.magnitude);
        if (Input.GetKey(KeyCode.Escape) && esctime <= 0f)
        {
            
            bool b = GameObject.Find("Canvas").GetComponent<GameUIManager>().EscapePushed();
            //if (b) RestartInput();
            //else PauseInput();
            esctime = 0.5f;
        }

        time += Time.deltaTime;
        esctime -= Time.deltaTime;
    }
}