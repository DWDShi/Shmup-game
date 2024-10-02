using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shmup
{
    public class PlayerMoveState : PlayerNeutralState
    {
        public PlayerMoveState(Player conPlayer, PlayerStateMachine conStateMachine, PlayerData conPlayerData, string conAnimBoolName) : base(conPlayer, conStateMachine, conPlayerData, conAnimBoolName)
        {
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
            //Move player
            player.SetVelocity(playerMoveInput * playerData.moveSpeed);
           
            if (playerMoveInput == Vector2.zero) 
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
