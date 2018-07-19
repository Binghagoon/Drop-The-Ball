using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    
    private static InputController instance;
    bool isGyroAble;
    float time = 0f;
    Vector3 vec;
    public Vector3 Delta { get {return vec;} }

    protected InputController()
    {

    }

    public static InputController Instance()
    {
        return instance;
    }

    Vector3 CalGyro() {
        return Input.acceleration * 90;
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
            if (SystemInfo.supportsGyroscope) {
                Debug.Log("Gyroscope is found successfully.");
                isGyroAble = true;
            }
            else {
                Debug.Log("Gyroscope is not found.");
                isGyroAble = false;
            }
            instance = this;
        }
        else return;       //TBD

    }

    void Update() {
        if(instance != this)    return;

        if(isGyroAble)
            vec = CalGyro();
        else
            vec = DebugController();
    }
}