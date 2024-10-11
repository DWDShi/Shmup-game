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



        public override void LogicUpdate()
        {
            base.LogicUpdate();

            player.Shooting.Shoot(playerData.bulletSizeMult, playerData.bulletVelocity);
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
