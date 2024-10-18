using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Shmup
{
    public class ObjectPoolItem : MonoBehaviour, IObjectPoolItem
    {
        private ObjectPool objectPool;
        private Component component;

        //3 Functions below handle the returning of this object to the connected pool, with or without delay. 
        public void ReturnObject(float delay = 0f)
        {
            if (delay > 0)
            {
                StartCoroutine(delayReturn(delay));
            }
            else
            {
                ReturnToPool();
            }
        }

        private IEnumerator delayReturn(float seconds) 
        { 
            yield return new WaitForSeconds(seconds);
            ReturnToPool();    
        }

        private void ReturnToPool() 
        {
            //Return object to pool if the relvant pool exists, if not then fallback to destroying it
            if (objectPool != null)
            {
                objectPool.ReturnObject(component);
            }
            else 
            {
                Debug.LogWarning($"{gameObject.name} does not have a relevant pool to fit in and will be destroyed, please check this!");
                Destroy(gameObject);
            }
        
        }

        //Stops all co routines if disabled, as they are not needed anymore
        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void Release()
        {
            objectPool = null;
        }

        public void SetObjectPool<T>(ObjectPool pool, T comp) where T : Component
        {
            objectPool = pool;

            //get compnent of the smae type of compnent passed in
            component = GetComponent(comp.GetType());
        }
    }
}
