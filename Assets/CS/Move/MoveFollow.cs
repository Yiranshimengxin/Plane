using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollow : MoveStyle
{
    float waitTime;
    float time;
    Transform target;

    private void Start()
    {
        time = Time.time;
    }

    public void SetInit(float _speed,Transform t,float _time)
    {
        waitTime = _time;
        target = t;
        base.Init(_speed,t.position);
    }

    private void Update()
    {
        if (!target)
        {
            return;
        }
        if (Time.time-time<waitTime)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, target.position, speed);
    }
}
