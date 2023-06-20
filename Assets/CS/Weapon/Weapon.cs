using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public delegate Weapon GetWeapon(Plane _plane);
    public static Dictionary<ToolType, GetWeapon> MyWeapon = new Dictionary<ToolType, GetWeapon>();
    public ToolType type { set; get; }
    protected GameObject bulletPrefab;
    protected int level;
    public int Level 
    {
        set 
        {
            level = Mathf.Clamp(value, 0, 6);   
        }
        get
        {
            return level;
        } 
    }
    protected delegate void FireGun();
    protected FireGun gun;
    protected Transform firePos;
    protected string clip;
    protected float time;
    public float att;
    protected float timeCd;
    public Plane plane;
    
    public Weapon(Plane _plane)
    {
        plane = _plane;
        Init();
    }

    protected virtual void Init()
    {
        firePos = plane.firePoint;
        Level = plane.weaponLevel;
        gun = FireGunLevel;
    }

    public virtual void WeaponLevel()
    {
        Level++;
        plane.Calculation();
    }

    static Weapon GetWeaponFire(Plane _plane)
    {
        return new WeaponFire(_plane);
    }
    
    static Weapon GetWeaponThunder(Plane _plane)
    {
        return new WeaponThunder(_plane);
    }
    
    static Weapon GetWeaponHeart(Plane _plane)
    {
        return new WeaponHeart(_plane);
    }

    public static void SetMyWeapon()
    {
        MyWeapon.Add(ToolType.Fire, GetWeaponFire);
        MyWeapon.Add(ToolType.Thunder, GetWeaponThunder);
        MyWeapon.Add(ToolType.Heart, GetWeaponHeart);
    }

    public virtual void FireGunLevel()
    {
        if (Level==0)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 offset = Vector3.right * 0.25f * (i - 0.5f);
                GameObject go = Instantiate(bulletPrefab);
                go.transform.parent = GameManager._instance.bulletBox;
                go.GetComponent<Bullet>().plane=plane;
                go.transform.position = firePos.position + offset;
            }
        }
        else
        {
            for (int i = -Level; i <= Level; i++)
            {
                Vector3 offset = Vector3.right * 0.25f * (i * 0.5f);
                GameObject go = Instantiate(bulletPrefab);
                go.transform.parent = GameManager._instance.bulletBox;
                go.GetComponent<Bullet>().plane = plane;
                go.transform.position = firePos.position + offset;
                go.transform.localEulerAngles = new Vector3(0, 0, -5 * i);
            }
        }
    }

    public virtual void SetInit(params object[] obj)
    {

    }


    public void Fire()
    {
        if (Time.time-time<timeCd)
        {
            return;
        }
        time = Time.time;
        gun();
        GameManager.PlayAudio(clip);
    }

}
