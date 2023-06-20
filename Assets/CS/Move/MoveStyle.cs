using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStyle : MonoBehaviour
{
    public float speed;
    protected Vector3 targetPos;
    public Vector3 dirc;
    public void Init(float s,Vector3 tp)
    {
        speed = s;
        targetPos = tp;
    }

    public virtual void Move()
    {

    }

    public void SetAngle(Vector3 dir)
    {
        transform.up = dir.normalized;
    }

}
