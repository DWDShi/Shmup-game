using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class PlayerMoveShootState : PlayerNeutralState
    {
        public PlayerMoveShootState(Player conPlayer,  string conAnimBoolName) : base(conPlayer, conAnimBoolName)
        {
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
