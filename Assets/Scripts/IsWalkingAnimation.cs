﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWalkingAnimation : MonoBehaviour
{
    public Animator anim;
    private Vector3 _direction;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
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
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
}
