using UnityEngine;
using ManagerPooling;

public class MouseSpawner : MonoBehaviour
{
    public GameObject ExamplePrefab;
    void Start()
    {
        PoolManager.SetObjectInPool(ExamplePrefab,10);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            PoolManager.SpawnObject();
        }
    }
}
