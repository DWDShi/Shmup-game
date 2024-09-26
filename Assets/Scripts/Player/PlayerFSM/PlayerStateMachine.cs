using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Very simple script which handles the transition between states

namespace Shmup
{
    //MonoBehaviour unneeded, this wont be directly attached to anything
    public class PlayerStateMachine 
    {
        public PlayerState CurrentState { get; private set; }   //easy getters and setters

        public void Initialise(PlayerState startingState) 
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(PlayerState newState) 
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
