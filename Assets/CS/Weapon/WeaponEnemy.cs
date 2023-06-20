using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : Weapon
{
    public WeaponEnemy(Plane _plane):base(_plane)
    {
        plane = _plane;
    }
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        plane = GetComponent<Enemy>();
        plane.weapon = this;
        firePos = plane.firePoint;
        timeCd = 2;
        time = Time.time;
        bulletPrefab = LoadManager.LoadObj("EBullet");
    }

    new void Fire()
    {
        if (!GameManager._instance.myPlane)
        {
            return;
        }
        GameObject go = Instantiate(bulletPrefab,firePos.position,firePos.rotation);
        go.transform.parent = GameManager._instance.bulletBox;
        Bullet b = go.GetComponent<Bullet>();
        b.plane = plane;
        Vector3 dir = GameManager._instance.myPlane.transform.position - firePos.position;
        b.SetDirect(dir);

    }

    void Update()
    {
        if (Time.time-time<timeCd)
        {
            return;
        }
        time = Time.time;
        Fire();
    }
}
