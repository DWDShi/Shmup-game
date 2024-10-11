using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")]
        [Space(10)]
        public float moveSpeed = 4.0f;
        [Space(20)]
        [Header("Shoot State")]
        [Space(10)]
        public float bulletSizeMult = 1.0f;
        public float bulletVelocity = 5.0f;
        public float fireRate = 5.0f;
    }
}
