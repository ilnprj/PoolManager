using UnityEngine;
using System.Collections.Generic;
using System;
public class Pool<T>
{
    public string id;
    public List<ItemPool<T>> ObjectsInPool = new List<ItemPool<T>>();

    public Pool(T inputObject,int size,string inputId)
    {
        id = inputId;
    }
}
