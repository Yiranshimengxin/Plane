using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFinal : StateBoss
{
    public StateFinal(EnemyBoss _boss, List<Weapon> _weapons) : base(_boss, _weapons)
    {
        boss = _boss;
        hpState = _boss.stateHp[2];
        weapons = _weapons;


        weapons.Add(boss.gameObject.AddComponent<WeaponLaser>());
        weapons[3].SetInit(boss.points[3], 1, 6);

        weapons.Add(boss.gameObject.AddComponent<WeaponLaser>());
        weapons[4].SetInit(boss.points[4], 1, 6);
    }


    public override void ChangeState()
    {
        if (boss.hp <= hpState)
        {
            print("over");
            GameManager._instance.NextStage();
        }
    }
}
