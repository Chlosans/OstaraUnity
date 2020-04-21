using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;


    [SerializeField] private float speed = 15f;
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private Rigidbody rigidbody;
    private bool _isFalling = false;
    [SerializeField] private float minDistanceFloor = 1f;


    private Vector3 _direction;


    private void Start()
    {
        //anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Physics.Raycast(transform.position, Vector3.down, out  var hit , Mathf.Infinity))
        {
            //Debug.Log($"hit distance {hit.distance}");
            _isFalling = (hit.distance > minDistanceFloor);
        }
        else
        {
            _isFalling = true;
        }
        
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.z = Input.GetAxisRaw("Vertical");

        if (_direction.z != 0 || _direction.x != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        if (Input.GetKeyDown(KeyCode.Space)&& !_isFalling)
        {
            _direction.y += 1f;
            anim.SetBool("isJumping", true);
        }
        else
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                anim.SetBool("isJumping", false);
            }
        }
        
        if (Input.GetKey(KeyCode.P))
        {
            anim.SetBool("isPick", true);
        }
        else
        {
            anim.SetBool("isPick", false);
        }
        if (Input.GetKey(KeyCode.U))
        {
            anim.SetBool("isPlant", true);
        }
        else
        {
            anim.SetBool("isPlant", false);
        }



    }


    private void FixedUpdate()
    {
        if (_direction.y > 0f)
        {
            rigidbody.AddForce(Vector3.up * jumpSpeed);
        }

        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _direction.Normalize();

        if(_direction != Vector3.zero)
        { 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction.normalized), 0.1F);
        }
        transform.Translate(_direction * speed * Time.deltaTime, Space.World);

    }
}