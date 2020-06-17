using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using SocketEvent;

// réception mouvements/aniamtions/jumps du joueur 3
namespace walkingPlayer3
{
    public class PlayerMovement3 : MonoBehaviour
    {
        private AfficheButton3 _testJson;
        public Animator anim;
        public static string move;
        public static string jump;
        public static string plante;
        public static string recolte;
        public GameObject Planter;
        public GameObject BoutonsPluie;
        public GameObject Ramasser;
        public static bool firstPlante = true;
        public static bool firstRecolte = true;
        public static string clickPluie;


        [SerializeField] private float speed = 15f;
        [SerializeField] private float jumpSpeed = 8f;
        [SerializeField] private Rigidbody rigidbody;
        private bool _isFalling = false;
        [SerializeField] private float minDistanceFloor = 1f;


        private Vector3 _direction;
        public GameObject Fruitier1;
        private bool apparition = false;


        private void Start()
        {
            //anim = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody>();
        }

        public static void Joystick(string data)
        {
            // Debug.Log(data);
            move = data;
        }

        public static void Jump(string data)
        {
            jump = data;
        }
        public static void Plante(string data)
        {
            plante = data;
        }
        public static void Recolte(string data)
        {
            recolte = data;
        }

        public static void PluieButton(string data)
        {
            Debug.Log("Bonjour Pluie");
            clickPluie = data;
        }
        private void Update()
        {

            if (Physics.Raycast(transform.position, Vector3.down, out var hit, Mathf.Infinity))
            {
                //Debug.Log($"hit distance {hit.distance}");
                _isFalling = (hit.distance > minDistanceFloor);
            }
            else
            {
                _isFalling = true;
            }

            // Joystick Direction

            // _direction.x = Input.GetAxisRaw("Horizontal");
            // _direction.z = Input.GetAxisRaw("Vertical");

            // ------------------

            if (move == "{\"data\":\"X1Y13\"}")
            {
                _direction.x += 1;
                _direction.z += 1;
            }

            if (move == "{\"data\":\"X0Y03\"}")
            {
                _direction.x = 0;
                _direction.z = 0;
            }

            if (move == "{\"data\":\"X-1Y-13\"}")
            {
                _direction.x -= 1;
                _direction.z -= 1;
            }

            if (move == "{\"data\":\"X1Y03\"}" || move == "{\"data\":\"X1Y03\"}")
            {
                _direction.x += 1;
            }

            if (move == "{\"data\":\"X0Y13\"}" || move == "{\"data\":\"X-0Y13\"}")
            {
                _direction.z += 1;
            }

            if (move == "{\"data\":\"X-1Y03\"}" || move == "{\"data\":\"X-1Y-03\"}")
            {
                _direction.x -= 1;
            }

            if (move == "{\"data\":\"X0Y-13\"}" || move == "{\"data\":\"X-0Y-13\"}")
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


            if (jump == "{\"data\":\"jump3\"}")
            {
                _direction.y += 1f;
                anim.SetBool("isJumping", true);
                // StartCoroutine(PlayAnimJump());
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
                if (plante == "{\"data\":\"clickPlante\"}")
                {
                    Planter.SetActive(false);
                    StartCoroutine(PlayAnimPlant());
                    firstPlante = false;
                }
            }

            if (firstRecolte == true)
            {
                if (recolte == "{\"data\":\"clickRecolte\"}")
                {
                    Ramasser.SetActive(false);
                    StartCoroutine(PlayAnimRam());
                    firstRecolte = false;
                }
            }

            if (apparition == false && clickPluie == "{\"data\":\"clickPluie\"}")
            {
                ArbreFruitier();
                apparition = true;
            }


        }

        public void ArbreFruitier()
        {
            Instantiate(Fruitier1, transform.position + (transform.forward * 0.5f), transform.rotation);
        }

        IEnumerator PlayAnimPlant()
        {
            anim.SetBool("isPlant", true);
            yield return new WaitForSeconds(15);
            anim.SetBool("isPlant", false);

            // Affiche Button pluie + set graine 0
            _testJson = new AfficheButton3();
            _testJson.eventName = "afficheContainerPluie";
            _testJson.eventContainer = true;
            _testJson.eventInventaire = "0 graine";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));


        }

        IEnumerator PlayAnimRam()
        {
            anim.SetBool("isPick", true);
            yield return new WaitForSeconds(15);
            anim.SetBool("isPick", false);

            // Retirer Bouton Recolte Fruit + Set Fruit 3
            _testJson = new AfficheButton3();
            _testJson.eventName = "setFruit";
            _testJson.eventContainer = false;
            _testJson.eventInventaire = "3 fruits";

            SocketEvent.Client.sendMessage(SocketEvent.Client.ConvertDataObject(_testJson));


        }

        private void FixedUpdate()
        {
            if (_direction.y > 0f)
            {
                rigidbody.AddForce(Vector3.up * jumpSpeed);
            }

            _direction = new Vector3(_direction.x, 0f, _direction.z);
            _direction.Normalize();

            if (_direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction.normalized), 0.1F);
            }
            transform.Translate(_direction * speed * Time.deltaTime, Space.World);

        }
    }

    [Serializable]
    public class AfficheButton3
    {
        public string eventName;
        public bool eventContainer;
        public string eventInventaire;
    }

}

