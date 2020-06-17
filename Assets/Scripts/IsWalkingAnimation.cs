﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketEvent;

// réception mouvements/aniamtions/jumps du joueur 1
namespace walkingPlayerAnimation
{
    public class IsWalkingAnimation : MonoBehaviour
    {
        public Animator anim;
        private Vector3 _direction;
        public static string moveAnimation;
        public static string jumpAnimation;
        public static string planteAnimation;
        public static string recolteAnimation;
        public static bool firstPlante = true;
        public static bool firstRecolte = true;


        void Start()
        {
            anim = GetComponent<Animator>();
        }

        public static void JoystickAnimation(string data)
        {
            // Debug.Log("Animation");
            moveAnimation = data;
        }

        public static void JumpAnimation(string data)
        {
            jumpAnimation = data;
        }

        public static void PlanteAnimation(string data)
        {
            planteAnimation = data;
        }

        public static void RecolteAnimation(string data)
        {
            recolteAnimation = data;
        }

        IEnumerator PlayAnimPlant()
        {
            anim.SetBool("isPlant", true);
            yield return new WaitForSeconds(15);
            anim.SetBool("isPlant", false);
        }

        IEnumerator PlayAnimRam()
        {
            anim.SetBool("isPick", true);
            yield return new WaitForSeconds(15);
            anim.SetBool("isPick", false);
        }


        void Update()
        {
            // _direction.x = Input.GetAxisRaw("Horizontal");
            // _direction.z = Input.GetAxisRaw("Vertical");

            // ------------------

            if (moveAnimation == "{\"data\":\"X0Y01\"}")
            {
                _direction.x = 0;
                _direction.z = 0;
            }

            if (moveAnimation == "{\"data\":\"X1Y11\"}")
            {
                _direction.x += 1;
                _direction.z += 1;
            }

            if (moveAnimation == "{\"data\":\"X-1Y-11\"}")
            {
                _direction.x -= 1;
                _direction.z -= 1;
            }

            if (moveAnimation == "{\"data\":\"X1Y01\"}" || moveAnimation == "{\"data\":\"X1Y-01\"}")
            {
                _direction.x += 1;
            }

            if (moveAnimation == "{\"data\":\"X0Y11\"}" || moveAnimation == "{\"data\":\"X-0Y11\"}")
            {
                _direction.z += 1;
            }

            if (moveAnimation == "{\"data\":\"X-1Y01\"}" || moveAnimation == "{\"data\":\"X-1Y-01\"}")
            {
                _direction.x -= 1;
            }

            if (moveAnimation == "{\"data\":\"X0Y-11\"}" || moveAnimation == "{\"data\":\"X-0Y-11\"}")
            {
                _direction.z -= 1;
            }

            if (_direction.z != 0 || _direction.x != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            if (jumpAnimation == "{\"data\":\"jump1\"}")
            {
                _direction.y += 1f;
                anim.SetBool("isJumping", true);
            }
            else
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    anim.SetBool("isJumping", false);
                }
            }

            if (firstPlante == true)
            {
                if (planteAnimation == "{\"data\":\"clickPlante\"}")
                {
                    StartCoroutine(PlayAnimPlant());
                    firstPlante = false;
                }
            }

            if (firstRecolte == true)
            {
                if (recolteAnimation == "{\"data\":\"clickRecolte\"}")
                {
                    StartCoroutine(PlayAnimRam());
                    firstRecolte = false;
                }
            }
        }
    }
}