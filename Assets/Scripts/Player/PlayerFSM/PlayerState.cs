using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    //MonoBehaviour unneeded, this wont be directly attached to anything
    public class PlayerState 
    {
        //Allows object which inherit from this to access these variables
        protected Player player;
        protected StateMachine stateMachine;
        protected PlayerData playerData;

        //set when state entered, helps track how long we have been in the state for
        protected float startTime;

        //used to tell animator what animation should play IF RELEVANT
        private string animBoolName;

        //simple constructor, things needed for the creation of each state
        public PlayerState(Player conPlayer , string conAnimBoolName) 
        {
            player = conPlayer;
            animBoolName = conAnimBoolName;
            stateMachine = player.StateMachine;
            playerData = player.playerData;
        }
        //Virtual functions so that subsequent states can overwrite the basic code

        //Called when entering state
        public virtual void Enter() 
        {
            DoChecks();
            player.Anim.SetBool(animBoolName, true);
            startTime = Time.time;
            Debug.Log(animBoolName);
        }

        //Called when exiting state
        public virtual void Exit() 
        {
            player.Anim.SetBool(animBoolName, false);
        }

        //same as Update(), runs every frame
        public virtual void LogicUpdate() 
        { 

        }

        //Same as FixedUpdate(), runs every fixed update
        public virtual void PhysicsUpdate() 
        {
            DoChecks();
        }

        //Checks for collisions, called here in Enter() and PhysicsUpdate() as it will be done in all states
        public virtual void DoChecks() 
        { 

        }
    }
}
