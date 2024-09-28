using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class PlayerNeutralState : PlayerState
    {
        public PlayerNeutralState(Player conPlayer, PlayerStateMachine conStateMachine, PlayerData conPlayerData, string conAnimBoolName) : base(conPlayer, conStateMachine, conPlayerData, conAnimBoolName)
        {
        }
    }
}
