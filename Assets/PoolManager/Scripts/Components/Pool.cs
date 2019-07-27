using System.Collections.Generic;
using UnityEngine;
using System;

namespace ManagerPooling
{
    public class Pool<T> : MonoBehaviour
    {
        public Dictionary<T, ItemPool<T>> ObjectsInPool = new Dictionary<T, ItemPool<T>>();

        private Func<T> func;

        public Pool(Func<T> inputObject, int size)
        {
            func = inputObject;
            ObjectsInPool = new Dictionary<T, ItemPool<T>>();
            for (int i = 0; i < size; i++)
            {
                CreateNewObject();
            }
        }

        public T GetFromPool()
        {
            foreach (var item in ObjectsInPool)
            {
                if (item.Value.free)
                {
                    item.Value.free = false;
                    return item.Value.itemObject;
                }
            }
            return CreateNewObject();
        }

        public void BackToPool(T item)
        {
            if (ObjectsInPool.ContainsKey(item))
            {
                ObjectsInPool[item].free = true;
            }
        }

        private T CreateNewObject()
        {
            var newObject = new ItemPool<T>();
            newObject.itemObject = func();
            ObjectsInPool.Add(newObject.itemObject, newObject);
            return newObject.itemObject;
        }
    }
}
