using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class PlayerShootState : PlayerNeutralState
    {
        public PlayerShootState(Player conPlayer,  string conAnimBoolName) : base(conPlayer, conAnimBoolName)
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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void MoveEventChange(Vector2 newInput)
        {
            base.MoveEventChange(newInput);
        }

        protected override void ShootEventCancel()
        {
            base.ShootEventCancel();
        }
    }
}
