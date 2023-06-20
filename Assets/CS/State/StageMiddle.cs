using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMiddle : StateBoss
{
    public StageMiddle(EnemyBoss _boss, List<Weapon> _weapons) : base(_boss, _weapons)
    {
        boss = _boss;
        hpState = _boss.stateHp[1];
        weapons = _weapons;

        weapons.Add(boss.gameObject.AddComponent<WeaponS>());
        weapons[1].SetInit(boss.points[1], 30, 20, 0.5f, 10, 20);

        weapons.Add(boss.gameObject.AddComponent<WeaponS>());
        weapons[2].SetInit(boss.points[2], 30, 20, 0.5f, 10, 20);
    }

    public override void ChangeState()
    {
        if (boss.hp < hpState)
        {
            boss.state = new StateFinal(boss, weapons);
        }
    }
}
