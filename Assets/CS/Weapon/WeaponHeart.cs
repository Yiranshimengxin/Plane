using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHeart : Weapon
{
    public WeaponHeart(Plane _plane) : base(_plane)
    {
        plane = _plane;
        type = ToolType.Heart;
        Init();
    }

    protected override void Init()
    {
        base.Init();
        timeCd = 0.5f;
        att = 20;
        clip = "Bomb";
        bulletPrefab = LoadManager.LoadObj("BulletHeart");
    }

    public override void FireGunLevel()
    {
        GameObject go = Instantiate(bulletPrefab,GameManager._instance.bulletBox);
        go.GetComponent<Bullet>().plane = plane;
        go.transform.position = firePos.position;
        go.transform.localScale = (Level * 0.1f + 0.2f) * Vector3.one;
    }

    public virtual int Level
    {
        set
        {
            Level = Mathf.Clamp(value, 0, 6);
            timeCd = 0.5f - (value * 0.03f);
        }
        get
        {
            return level;
        }
    }

    public override void WeaponLevel()
    {
        Level++;
        timeCd = 0.5f - (Level * 0.03f);
        att = 20 * Level + 15;
        plane.Calculation();
    }
}
