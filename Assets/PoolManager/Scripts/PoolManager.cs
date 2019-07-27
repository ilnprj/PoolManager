using UnityEngine;
using System.Collections.Generic;
public class PoolManager : MonoBehaviour
{
    private PoolManager instance;

    public enum SceneType
    {
        OnceLoad, DontDestroy
    }

    public SceneType TypeLoad;
    
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
}



