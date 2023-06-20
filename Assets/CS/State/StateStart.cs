using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStart : StateBoss
{
    public StateStart(EnemyBoss _boss, List<Weapon> _weapons) : base(_boss, _weapons)
    {
        boss = _boss;
        hpState = _boss.stateHp[0];
        weapons = new List<Weapon>();

        weapons.Add(boss.gameObject.AddComponent<WeaponCircle>());
        weapons[0].SetInit(boss.points[0],60,15,0.1f,360,50);
        boss.GetComponent<Collider>().enabled = true;
    }

    public override void ChangeState()
    {
        if (boss.hp < hpState)
        {
            boss.state = new StageMiddle(boss,weapons);
        }
    }
}
