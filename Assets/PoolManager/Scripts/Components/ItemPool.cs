using UnityEngine;

namespace ManagerPooling
{
    public class ItemPool<T> : MonoBehaviour
    {
        public T itemObject;
        public bool free;
    }
}
