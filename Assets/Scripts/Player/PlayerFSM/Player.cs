using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class Player : MonoBehaviour
    {
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }

        public Animator Anim { get; private set; }

        [SerializeField] private PlayerData playerData;
        
        [field: SerializeField] public InputReader PlayerInput { get; private set; }

        public Rigidbody2D RB {  get; private set; }
        

        private void Awake()
        {
            //create state machine and states
            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
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

        public void SetVelocity(Vector2 newVelocity) 
        { 
            RB.velocity = newVelocity;
        }
    }
}
