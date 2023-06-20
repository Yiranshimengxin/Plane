using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCircle : Weapon
{
    int angleValue;
    int angleInterval;
    int angleStart;
    int fireNum;
    float fireInterval;
    int dir;
    public WeaponCircle(Plane _plane) : base(_plane)
    {
        plane = _plane;
        Init();
    }

    protected override void Init()
    {
        plane = GetComponent<Enemy>();
        plane.weapon = this;
        att = 10;
        clip = "Bullet";
        bulletPrefab = LoadManager.LoadObj("EBullet");
        time = -1000;
    }

    public override void SetInit(params object[] obj)
    {
        Init();
        firePos = (Transform)obj[0];
        int n = int.Parse(obj[1].ToString());
        angleStart = (int)transform.localEulerAngles.z - n;
        angleValue = (int)transform.localEulerAngles.z + n;
        angleInterval = int.Parse(obj[2].ToString());
        fireInterval = float.Parse(obj[3].ToString());
        fireNum = int.Parse(obj[4].ToString());
        timeCd = float.Parse(obj[5].ToString());
        gun = GunFire;
        dir = 1;
    }

    void GunFire()
    {
        StartCoroutine(_Fire());
    }

    IEnumerator _Fire()
    {
        int angle = angleStart;
        for (int i = 0; i <= fireNum; i++)
        {
            GameObject go = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            go.GetComponent<Bullet>().plane=this.plane;
            go.transform.parent = GameManager._instance.bulletBox;
            angle += angleInterval * dir;
            go.transform.localEulerAngles = new Vector3(0, 0, angle);
            if (angle < angleStart || angle > angleValue)
            {
                dir = -dir;
            }
            yield return new WaitForSeconds(fireInterval);
        }
    }


}
