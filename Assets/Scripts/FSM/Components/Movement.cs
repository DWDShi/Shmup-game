using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class Movement : FSMCoreComponent
    {
        protected override void Awake()
        {
            base.Awake();
        }

        #region Setters

        public void SetVelocity(Vector2 newVelocity)
        {
            core.RB.velocity = newVelocity;
        }

        #endregion
    }
}
