using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Shmup
{
    public class PlayerNeutralState : PlayerState
    {
        public PlayerNeutralState(Player conPlayer, string conAnimBoolName) : base(conPlayer, conAnimBoolName)
        {
            /* Needed here rather than on enter so that all states in the neutral situation can read inputs always, fixes issue in transitions as sometime it can get looped as the variable
            doesnt update since it has never been entered before and therefore hasnt sunscribed to the events :( */
            player.PlayerInput.MoveEvent += MoveEventChange;
            player.PlayerInput.ShootEvent += ShootEventTrigger;
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

        }


        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected virtual void ShootEventTrigger() 
        {
        
        }
        protected virtual void ShootEventCancel() 
        {
        
        }

        //Change the movement vector to the new one received from event
        protected virtual void MoveEventChange(Vector2 newInput)
        {

        }
    }
}
