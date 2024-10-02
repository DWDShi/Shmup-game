using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Shmup
{
    public class PlayerNeutralState : PlayerState
    {
        protected Vector2 playerMoveInput;
        public PlayerNeutralState(Player conPlayer, PlayerStateMachine conStateMachine, PlayerData conPlayerData, string conAnimBoolName) : base(conPlayer, conStateMachine, conPlayerData, conAnimBoolName)
        {
            /* Needed here rather than on enter so that all states in the neutral situation can read inputs always, fixes issue in transitions as sometime it can get looped as the variable
            doesnt update since it has never been entered before and therefore hasnt sunscribed to the events :( */
            player.PlayerInput.MoveEvent += ChangeMoveVector;
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

        //Change the movement vector to the new one received from event
        private void ChangeMoveVector(Vector2 newInput)
        {
            playerMoveInput = newInput;
        }
    }
}
