using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 3.0f;
        [SerializeField]
        private float rateOfFire = 2.0f;

        [SerializeField]
        private InputReader input;

        private Vector2 moveDirection;
        private bool isShooting;

        // Start is called before the first frame update
        void Start()
        {
            input.MoveEvent += MovePlayer;
            input.ShootEvent += FirePlayerWeapon;
            input.ShootCancelledEvent += StopPlayerWeapon;
        }

        private void FirePlayerWeapon()
        {
            isShooting = true;
            Debug.Log("pew pew");
        }

        private void StopPlayerWeapon()
        {
            isShooting = false;

            Debug.Log("no shooting");
        }

        private void MovePlayer(Vector2 newDirection)
        {
            moveDirection = newDirection;
        }

        private void ExecuteMovement() 
        {
            if (moveDirection != Vector2.zero) 
            {
                transform.position += ((Vector3)moveDirection * (moveSpeed * Time.deltaTime)) ; 
            }
        }

        // Update is called once per frame
        void Update()
        {
            ExecuteMovement();
        }
    }
}
