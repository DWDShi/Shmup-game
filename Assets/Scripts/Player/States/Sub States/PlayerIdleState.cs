using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shmup
{
    public class PlayerIdleState : PlayerNeutralState
    {
        public PlayerIdleState(Player conPlayer,  string conAnimBoolName) : base(conPlayer, conAnimBoolName)
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
            player.Movement.SetVelocity(Vector2.zero);
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

        protected override void MoveEventChange(Vector2 newInput)
        {
            base.MoveEventChange(newInput);

            //if moving, change to move state
            if (newInput != Vector2.zero)
            {
                player.Movement.SetVelocity(newInput * playerData.moveSpeed);
                stateMachine.ChangeState(player.MoveState);
            }
        }

        protected override void ShootEventTrigger()
        {
            base.ShootEventTrigger();

            stateMachine.ChangeState(player.ShootState);
        }
    }
}
