using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBoss : MonoBehaviour
{
    protected StateBoss stateInit;
    protected EnemyBoss boss;
    public float hpState;
    protected List<Weapon> weapons;
    protected float target = 2;
    protected float speed = 2;
    protected int dirc = 1;

    public StateBoss(EnemyBoss _boss, List<Weapon> weapons)
    {
        boss = _boss;
    }

    public virtual void ChangeState()
    {

    }

    public virtual void Move()
    {
        boss.transform.Translate(boss.transform.right * speed * Time.deltaTime * dirc);
        if (Mathf.Abs(boss.transform.position.x) > Mathf.Abs(target)&&(boss.transform.position.x*target>0))
        {
            dirc = -dirc;
            target = -target;
        }
    }

    public virtual void Fire()
    {
        foreach (Weapon item in weapons)
        {
            item.Fire();
        }
    }

    public virtual void TimeChange()
    {

    }
}
