using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class FSMCoreComponent : MonoBehaviour
    {
        protected FSMCore core;

        protected virtual void Awake()
        {
            core = transform.parent.GetComponent<FSMCore>();

            if (core == null) 
            {
                Debug.LogError("no core on parent :(");
            }
        }
    }
}
