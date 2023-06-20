using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTool : MoveStyle
{
    float time;
    public float maxTime = 5;
    bool isGo;
    void Start()
    {
        targetPos = GameManager.GetRandomPos();
        time = Time.time;
    }

    public override void Move()
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            targetPos = GameManager.GetRandomPos();
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (isGo)
        {
            return;
        }
        if (Time.time-time>=maxTime)
        {
            isGo = true;
            targetPos = GameManager.GetRandomPosOut();
        }
    }
}
