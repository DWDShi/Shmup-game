using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class ObjectPoolManager
    {
        private readonly Dictionary<string, ObjectPool> objectPools = new Dictionary<string, ObjectPool>();

        //Gets
        public ObjectPool<T> GetPool<T>(T prefab, int startcount = 1) where T : Component
        {
            //If no pool exists with the prefabs name in the dictionary, create a new one
            if (!objectPools.ContainsKey(prefab.name))
            {
                objectPools[prefab.name] = new ObjectPool<T>(prefab, startcount);
            }

            return (ObjectPool<T>)objectPools[prefab.name];
        }

        public T GetObject<T>(T prefab, int startCount = 1) where T : Component
        {
            return ( GetPool(prefab, startCount).GetObject() );
        }

        public void ReturnObject<T>(T returnedObject) where T : Component
        {
            var targetPool = GetPool(returnedObject);
            targetPool.ReturnObject(returnedObject);
        }

        public void Release() 
        {
            foreach (var pool in objectPools) 
            {
                pool.Value.Release();
            }
        }
    }


}
