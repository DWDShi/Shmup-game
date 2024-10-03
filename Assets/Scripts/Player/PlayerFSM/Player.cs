using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class Player : FSMCore
    {
        //chunks of code such as variables are put into regions for organisation, expand them if needed
        #region State Variables


        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }

        #endregion

        #region Components

        [field: Space(10)]
        [field: Header("Other")]
        [field: SerializeField] public PlayerData playerData { get; private set; }
        [field: SerializeField] public InputReader PlayerInput { get; private set; }
        
        


        #endregion

        #region Unity Callback Functions

        protected override void Awake()
        {
            //create state machine and states
            base.Awake();

            IdleState = new PlayerIdleState(this, "idle");
            MoveState = new PlayerMoveState(this, "move");
        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            //Give the state machine an initial state
            RB = GetComponent<Rigidbody2D>();

            //initialise any components before this, or else IT ALL BREAKS!!!
            StateMachine.Initialise(IdleState);
            
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

       

        #endregion


    }
}
