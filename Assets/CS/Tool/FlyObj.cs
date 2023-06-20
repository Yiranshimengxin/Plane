using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObj : MonoBehaviour
{
    protected MoveStyle ms;
    protected AudioClip clip;
    protected void Start()
    {
        ms = GetComponent<MoveStyle>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Effect(other);
    }

    protected virtual void Effect(Collider other)
    {

    }

    private void Update()
    {
        ms.Move();
    }
}
