using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shmup
{
    public class PlayerIdleState : PlayerNeutralState
    {
        public PlayerIdleState(Player conPlayer, PlayerStateMachine conStateMachine, PlayerData conPlayerData, string conAnimBoolName) : base(conPlayer, conStateMachine, conPlayerData, conAnimBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            //Stop movement once idle
            player.SetVelocity(Vector2.zero);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            //if moving, change to move state
            if (playerMoveInput != Vector2.zero) 
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
