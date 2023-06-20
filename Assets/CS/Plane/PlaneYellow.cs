using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneYellow : Plane
{
    protected override void Init()
    {
        att = 1.5f;
        //bombAtt = 400;
        speed = 3;
        hp = 150;
        maxHp = hp;
        kLevel = 1.2f;
        bombStr = "FireBomb";
        base.Init();
        weapon = new WeaponFire(this);
        Calculation();
    }
}
