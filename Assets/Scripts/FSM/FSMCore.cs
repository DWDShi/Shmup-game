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
        
        public Movement Movement {  get; private set; }  
        public Shooting Shooting {  get; private set; }        
        


        protected virtual void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            Shooting = GetComponentInChildren<Shooting>();


            StateMachine = new StateMachine();
        }
    }
}
