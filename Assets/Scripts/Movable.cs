using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    float speed = 3.0f;
    Rigidbody rigidbody;

    void SetVelocity(Vector3 vec, double force)
    {
        regidbody.velocity = vec;
    }

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        SetVelocity(InputController.instance.vec, 1f);
    }
}