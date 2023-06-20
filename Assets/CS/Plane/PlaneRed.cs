using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRed : Plane
{
    protected override void Init()
    {
        att = 0.9f;
        //bombAtt = 100;
        speed = 4;
        hp = 100;
        maxHp = hp;
        kLevel = 1.6f;
        bombStr = "ThunderBomb";
        bombPos = new Vector3(0.5f,2.5f,-5);
        base.Init();
        weapon = new WeaponThunder(this);
        Calculation();
    }
}
