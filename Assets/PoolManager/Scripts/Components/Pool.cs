using System.Collections.Generic;
using UnityEngine;
using System;

namespace ManagerPooling
{
    public class Pool<T>
    {
        public Dictionary<T, ItemPool<T>> ObjectsInPool = new Dictionary<T, ItemPool<T>>();

        private Func<T> fucntionInstanced;

        public Pool(Func<T> inputObject, int size)
        {
            fucntionInstanced = inputObject;
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
            newObject.itemObject = fucntionInstanced();
            ObjectsInPool.Add(newObject.itemObject, newObject);
            return newObject.itemObject;
        }
    }
}
