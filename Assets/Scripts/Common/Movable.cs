using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
    
    [SerializeField]
    float speed = 3.0f;
    new Rigidbody rigidbody;

    void SetVelocity(Vector3 vec)
    {
        vec.Scale(new Vector3(speed, 0, speed));
        rigidbody.velocity = vec;
    }

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        SetVelocity(InputController.Instance().Delta);
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name.Contains("1x1"))
        {
            float force = rigidbody.velocity.sqrMagnitude;
            AudioManager.Instance().BallCollision(force);
        }
    }
    */

}