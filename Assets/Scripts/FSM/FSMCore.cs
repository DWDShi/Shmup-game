using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public abstract class FSMCore : MonoBehaviour
    {
        public Animator Anim { get; protected set; }
        public Rigidbody2D RB { get; protected set; }

        public StateMachine StateMachine { get; protected set; }
        [Header("Core Components", order =0)]
        public Movement Movement;
        
        


        protected virtual void Awake()
        {
            StateMachine = new StateMachine();
        }
    }
}
