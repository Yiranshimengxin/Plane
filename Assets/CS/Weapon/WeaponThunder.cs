using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThunder : Weapon
{
    GameObject missilePrefab;
    float missileAtt;

    public WeaponThunder(Plane _plane) : base(_plane)
    {
        plane = _plane;
        type = ToolType.Thunder;
        Init();
    }

    protected override void Init()
    {
        base.Init();
        timeCd = 0.8f;
        att = 20;
        missileAtt = 100;
        clip = "Thunder";
        bulletPrefab = LoadManager.LoadObj("BulletThunder");
        missilePrefab = LoadManager.LoadObj("BulletMissile");
    }

    void ThunderFire(GameObject prefab,int n,Vector3 v)
    {
        GameObject go = Instantiate(prefab, GameManager._instance.bulletBox);
        go.GetComponent<Bullet>().plane = plane;
        go.transform.position = firePos.position + v;
    }

    public override void FireGunLevel()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 v = Vector3.right * (i - 0.5f) * 0.3f;
            ThunderFire(bulletPrefab, i, v);
        }
        for(int i = 0; i < Level+2; i++)
        {
            Vector3 v = Vector3.right * (i - 0.5f*(Level+1)) * 0.5f-Vector3.up*0.5f;
            ThunderFire(missilePrefab, i, v);
        }
    }
}
