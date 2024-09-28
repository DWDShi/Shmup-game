using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class PlayerIdleState : PlayerNeutralState
    {
        public PlayerIdleState(Player conPlayer, PlayerStateMachine conStateMachine, PlayerData conPlayerData, string conAnimBoolName) : base(conPlayer, conStateMachine, conPlayerData, conAnimBoolName)
        {
        }
    }
}
