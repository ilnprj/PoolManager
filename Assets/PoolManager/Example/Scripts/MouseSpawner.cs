using UnityEngine;
using ManagerPooling;

public class MouseSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject examplePrefab = default;

    [SerializeField]
    private int numPreparedObjects = 10;
    void Start()
    {
        PoolManager.PoolInstaller(examplePrefab,numPreparedObjects,"Sphere");
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            PoolManager.SpawnObject(examplePrefab,"Sphere");
        }
    }
}
