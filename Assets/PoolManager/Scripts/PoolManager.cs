using UnityEngine;
using System.Collections.Generic;

namespace ManagerPooling
{
    public class PoolManager : MonoBehaviour
    {
        public static Pool<GameObject> pool;
        public enum SceneType
        {
            OnceLoad, DontDestroy
        }
        public SceneType TypeLoad;

        private PoolManager instance;

        private void Awake()
        {
            SetTypeManager();
        }

        private void SetTypeManager()
        {
            switch (TypeLoad)
            {
                case SceneType.OnceLoad: { break; }
                case SceneType.DontDestroy:
                    {
                        if (!instance)
                            DontDestroyOnLoad(this);
                        else Destroy(this);
                        break;
                    }
            }
        }

        public static void SetObjectInPool(GameObject prefab, int size)
        {
            var rootTransform = new GameObject();
            rootTransform.name = prefab.name + " Pool";
            pool = new Pool<GameObject>(() => { return InstantiateObject(prefab, rootTransform); }, size);
        }

        private static GameObject InstantiateObject(GameObject prefab, GameObject rootTransform)
        {
            var go = Instantiate(prefab) as GameObject;
            go.transform.SetParent(rootTransform.transform);
            go.SetActive(false);
            return go;
        }

        public static void SpawnObject()
        {
            var objectFromPool = pool.GetFromPool();
            objectFromPool.SetActive(true);
        }

        public static void BackToPool(GameObject item)
        {
            item.SetActive(false);
            pool.BackToPool(item);
        }
    }
}
