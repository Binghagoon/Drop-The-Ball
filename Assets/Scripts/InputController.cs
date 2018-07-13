using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    
    private static InputController instance;
    bool isGyroAble;
    float time = 0f;
    Vector2 vec;
    public Vector2 Delta {
        get {return vec;}
    }

    public InputController()
    {
        if(instance == this)
            return this;
        else
            return instance;
    }

    Vector3 CalGyro() {
        return Input.acceleration * 90;
    }

    void DebugController() {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void Quantization(vector3 v) {
        if(v.x < 0.5) v.x = 0;
        if(v.y < 0.5) v.y = 0;
        if(v.z < 0.5) v.z = 0;
    }    

    void Awake() {
        if(instance == null)
            instance == this;
        else return;       //TBD

        if (SystemInfo.supportsGyroscope) {
            Debug.Log("Gyroscope is found successfully.");
            isGyroAble = true;
        }
        else {
            Debug.Log("Gyroscope is not found.");
            isGyroAble = false;
        }
    }

    void Update() {
        if(instance != this)    return;

        if(isGyroAble)
            vec = CalGyro();
        else
            vec = DebugController();
    }
}