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
            input.ShootEvent += firePlayerWeapon;
        }

        private void firePlayerWeapon()
        {
            isShooting = true;
            Debug.Log("pew pew");
        }

        private void MovePlayer(Vector2 newDirection)
        {
            moveDirection = newDirection;
        }

        private void ExecuteMovement() 
        {
            if (moveDirection != Vector2.zero) 
            {
                transform.position += (new Vector3(moveDirection.x, moveDirection.y, 0) * (moveSpeed * Time.deltaTime)) ; 
            }
        }

        // Update is called once per frame
        void Update()
        {
            ExecuteMovement();
        }
    }
}
