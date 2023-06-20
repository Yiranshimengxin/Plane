using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : Weapon
{
    float fireInterval;
    public WeaponLaser(Plane _plane) : base(_plane)
    {
        plane = _plane;
        Init();
    }

    protected override void Init()
    {
        plane = GetComponent<Enemy>();
        plane.weapon = this;
        att = 10;
        clip = "Thunder";
        bulletPrefab = LoadManager.LoadObj("Laser");
        time = Time.time;
    }

    public override void SetInit(params object[] obj)
    {
        Init();
        firePos = (Transform)obj[0];
        fireInterval = float.Parse(obj[1].ToString());
        timeCd = float.Parse(obj[2].ToString());
        gun = GunFire;
    }

    void GunFire()
    {
        StartCoroutine(_Fire());
    }

    IEnumerator _Fire()
    {
        GameObject go = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        go.GetComponent<Laser>().plane = plane;
        go.transform.parent = firePos;
        yield return new WaitForSeconds(fireInterval);
        go.transform.localScale = new Vector3(1, -10, 1);
        yield return new WaitForSeconds(fireInterval);
        Destroy(go);
    }
}
