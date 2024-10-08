using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")]
        public float moveSpeed = 4.0f;
    }
}
