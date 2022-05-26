using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 20f;
    Rigidbody _rigidbody;
    Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.down*_speed;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set the velocity always constant
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed; //normalized means the value is 1 unit in any direction
        _velocity =  _rigidbody.velocity; //maybe upon colllision the rigidbody velocity gets 0 but _velocity is unchanged 
    }


    //reflect the ball upon collision
    private void OnCollisionEnter(Collision collision) {
        _rigidbody.velocity = Vector3.Reflect(_velocity,collision.contacts[0].normal);
        
    }
}
