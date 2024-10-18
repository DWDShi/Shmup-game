using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Shmup
{
    public abstract class ObjectPool
    {
        public abstract void Release();

        public abstract void ReturnObject(Component comp);
    }

    //Keeping this class generic allows us to use pools for any type of projectile, or any prefab we wish to have pooled. 
    public class ObjectPool<T>: ObjectPool where T : Component 
    {
        private readonly T prefab;

        private readonly string pooledObjectName;
        private readonly Queue<T> inactiveObjects;

        private readonly List<IObjectPoolItem> allObjects = new List<IObjectPoolItem>();



        public ObjectPool(T poolPrefab, int startCount = 1)
        {
            prefab = poolPrefab;

            for (var i = 0; i < startCount; i++)
            {
                var initialObject = CreateNewObject();

                inactiveObjects.Enqueue(initialObject);
            }
        }

        //destructor of sorts, used when this pool is no longer needed
        public override void Release()
        {
            foreach (var obj in inactiveObjects) 
            {
                allObjects.Remove(obj as IObjectPoolItem);
                Object.Destroy(obj.gameObject);
            }

            foreach(var obj in allObjects)
            {
                obj.Release();
            }
        }


        //Object returns to queue, same as destroyig a game object for pools
        public override void ReturnObject(Component comp)
        {
           if(comp is T compObj)
            {
                compObj.gameObject.SetActive(false);
                inactiveObjects.Enqueue(compObj);
            }
        }

        public T GetObject() 
        {
            //Tries to grab object from queue, if it doesnt find one it creates a new one and adds it, if it does then it returns that object
            if (!inactiveObjects.TryDequeue(out var obj))
            {
                obj = CreateNewObject();
            }
            else
            {
                obj.gameObject.SetActive(true);
            }
            return obj;
        }

        public T CreateNewObject() 
        {
            var newObject = Object.Instantiate(prefab);
            newObject.name = prefab.name;

            if (!newObject.TryGetComponent<IObjectPoolItem>(out var objectPoolItemComp))
            {
                Debug.LogWarning($"{newObject.name} does not implement an appropriate interface for object pooling, please check this!");
            }
            else 
            {
                objectPoolItemComp.SetObjectPool(this,newObject);
                allObjects.Add( objectPoolItemComp );
            }

            return newObject;
        }
    }
}
