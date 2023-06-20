using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePink : Plane
{
    protected override void Init()
    {
        att = 1.2f;
        //bombAtt = 500;
        speed = 3.5f;
        hp = 120;
        maxHp = hp;
        kLevel = 1.4f;
        bombStr = "HeartBomb";
        base.Init();
        weapon = new WeaponHeart(this);
        Calculation();
        
    }
}
