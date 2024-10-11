using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Shmup
{
    public class Shooting : FSMCoreComponent
    {
        [SerializeField] private Transform shootPosition;
        [SerializeField] private GameObject bullet;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Shoot(float bulletScale, float bulletSpeed) 
        { 
            GameObject newBullet = Instantiate(bullet, shootPosition);

            newBullet.transform.localScale *= bulletScale;
        }

    }
}
