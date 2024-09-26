using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class Player : MonoBehaviour
    {
        public PlayerStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
        }

        private void Start()
        {
            //INIT STATE MACHINE
        }

        private void Update()
        {
            //Ensures that the update functions in the states run at the same time, same for fixedupdate below
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
    }
}
