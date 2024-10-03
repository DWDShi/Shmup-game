using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class PlayerMoveShootState : PlayerNeutralState
    {
        public PlayerMoveShootState(Player conPlayer, PlayerStateMachine conStateMachine, PlayerData conPlayerData, string conAnimBoolName) : base(conPlayer, conStateMachine, conPlayerData, conAnimBoolName)
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
