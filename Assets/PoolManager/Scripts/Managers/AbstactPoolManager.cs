using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ManagerPooling
{
    public static class AbstactPoolManager<T>
    {
        public static Dictionary<string, Pool<T>> AllPools = new Dictionary<string, Pool<T>>();

        public static void CreateNewPool()
        {

        }

        public static void GetFromPool()
        {

        }

        public static void BackToPool(string idGroup, T item)
        {
            if (AllPools.ContainsKey(idGroup) && AllPools[idGroup].ObjectsInPool.ContainsKey(item))
            {
                AllPools[idGroup].ObjectsInPool[item].Free = true;
            }
        }
    }
}
