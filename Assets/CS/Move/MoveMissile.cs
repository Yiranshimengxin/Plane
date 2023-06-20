using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMissile : MoveStyle
{
    float contraForce = -6;
    void Update()
    {
        speed += 0.1f;
        float force = speed + contraForce;
        transform.Translate(Vector3.up * force * Time.deltaTime);
    }
}
