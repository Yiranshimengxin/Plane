using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAwake : StateBoss
{
    float timeChange = 3;
    float time;
    public StateAwake(EnemyBoss _boss, List<Weapon> _weapons) : base(_boss, _weapons)
    {
        boss = _boss;
        hpState = _boss.stateHp[0];
        weapons = new List<Weapon>();
        speed = 1;
        time = Time.time;
    }

    public override void ChangeState()
    {
        boss.state = new StateStart(boss, weapons);
    }

    public override void Move()
    {
        boss.gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public override void TimeChange()
    {
        if (Time.time - time > timeChange)
        {
            ChangeState();
        }
    }
}
