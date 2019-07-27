using UnityEngine;
using System.Collections;
using ManagerPooling;

public class MoveSphere : MonoBehaviour
{
    private Rigidbody rg;
    public float Speed;
    public float TimeToDisable;
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 7f));
        transform.position = pos;
        transform.rotation = Quaternion.identity;
        StopCoroutine(Delay());
        StartCoroutine(Delay());
    }

    private void FixedUpdate()
    {
        rg.AddForce(Vector3.right * Speed);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(TimeToDisable);
        PoolManager.BackToPool(gameObject);
    }
}
