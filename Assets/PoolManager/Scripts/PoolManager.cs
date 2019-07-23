namespace PoolManager
{
    using UnityEngine;
    public class PoolManager : MonoBehaviour
    {
        public enum SceneType
        {
            OnceLoad, DontDestroy
        }

        public SceneType TypeLoad;

        private void Awake()
        {

        }
    }
}


