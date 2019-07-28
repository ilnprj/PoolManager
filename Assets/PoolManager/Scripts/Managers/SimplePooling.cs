using System.Collections.Generic;
using UnityEngine;

namespace ManagerPooling
{
    public class SimplePooling : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab = default;

        [Header("Current Pooling this component:")]
        public List<GameObject> Pool = new List<GameObject>();

        public void PoolInstaller(int size)
        {
            for (int i = 0; i < size; i++)
            {
                InstantiateObject();
            }
        }

        public GameObject Spawn()
        {
            foreach (var item in Pool)
            {
                if (!item.activeSelf)
                {
                    item.SetActive(true);
                    return item;
                }
            }
            var newObject = InstantiateObject();
            newObject.SetActive(false);
            return newObject;
        }

        public void BackToPool(GameObject obj)
        {
            if (Pool.Contains(obj))
            {
                obj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Element - "+obj.name+" not contains in pool!");
            }
        }

        private GameObject InstantiateObject()
        {
            var newObject = Instantiate(prefab);
            newObject.transform.SetParent(transform);
            newObject.SetActive(false);
            Pool.Add(newObject);
            return newObject;
        }
    }
}
