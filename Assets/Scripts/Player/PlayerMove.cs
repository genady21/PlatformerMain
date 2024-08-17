using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpSpeed = 1f;
    [SerializeField] private float _friction = 1f;
    [SerializeField] private float _maxSpeed = 1f;
    [SerializeField] private bool _grounded;
    [SerializeField] private float _compressionSpeed = 1f;

    [SerializeField] private Transform _colliderTransform;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || _grounded==false)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f),
                Time.deltaTime * _compressionSpeed);
        }
        else
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 1f, 1f),
                Time.deltaTime * _compressionSpeed);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_grounded)
                _rigidbody.AddForce(0,_jumpSpeed,0,ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
       
        float speedMultiplier = 1f;
        
        if (_grounded == false)
        {
            speedMultiplier = 0.1f;
            
            if (_rigidbody.velocity.x > _maxSpeed &&  Input.GetAxis("Horizontal")> 0)
            {
                speedMultiplier = 0;
            }
            if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }
        
        _rigidbody.AddForce(Input.GetAxis("Horizontal")*_moveSpeed*speedMultiplier,0,0,ForceMode.VelocityChange);
        if (_grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x*_friction,0,0,ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        
        if(angle<45f)
            _grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}
