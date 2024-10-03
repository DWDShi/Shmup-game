using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shmup
{
    public class PlayerMoveState : PlayerNeutralState
    {
        public PlayerMoveState(Player conPlayer,  string conAnimBoolName) : base(conPlayer, conAnimBoolName)
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
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void MoveEventChange(Vector2 newInput)
        {
            base.MoveEventChange(newInput);

            player.Movement.SetVelocity(newInput * playerData.moveSpeed);

            if (newInput == Vector2.zero)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            
        }

        protected override void ShootEventTrigger()
        {
            base.ShootEventTrigger();
        }
    }
}
