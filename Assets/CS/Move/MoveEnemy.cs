using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MoveStyle
{
    public int turnDirc;
    public float flyTime;
    float time;
    public int turnAngle;
    public float angleSpeed;
    float angle;

    private void Start()
    {
        time = Time.time;
    }

    public  void SetMoveData(float _speed,int _turnDirc,float _flyTime ,int _turnAngle,float _angleSpeed)
    {
        speed = _speed;
        turnDirc = _turnDirc;
        flyTime = _flyTime;
        turnAngle = _turnAngle;
        angleSpeed = _angleSpeed;
    }

    public void SetMoveData(MoveEnemy me)
    {
        SetMoveData(me.speed,me.turnDirc,me.flyTime,me.turnAngle,me.angleSpeed);
    }

    public override void Move()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
        if (Time.time-time<flyTime)
        {
            return;
        }
        if (Mathf.Abs(angle)<turnAngle)
        {
            angle -= angleSpeed * turnDirc;
            transform.eulerAngles = new Vector3(0,0,angle);
        }
    }
}
