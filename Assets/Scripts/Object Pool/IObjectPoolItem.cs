using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public interface IObjectPoolItem
    {
        void SetObjectPool<T>(ObjectPool pool, T comp) where T : Component;

        void Release();
    }
}
