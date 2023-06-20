using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : Weapon
{
    public WeaponFire(Plane _plane) : base(_plane)
    {
        plane = _plane;
        type = ToolType.Fire;
        Init();
    }

    protected override void Init()
    {
        base.Init();
        timeCd = 0.3f;
        att = 10;
        clip = "Bullet";
        bulletPrefab = LoadManager.LoadObj("BulletFire");
    }
}
