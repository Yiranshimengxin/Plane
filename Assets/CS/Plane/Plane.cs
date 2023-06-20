using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float realAtt;
    public float att;
    public float speed { set; get; }
    public int hp;
    public int bombAtt { set; get; }
    public Weapon weapon { set; get; }
    protected string bombStr;
    protected int bombNum = 3;
    protected Vector3 bombPos=new Vector3(0,1,-5);

    public int maxHp;
    protected int exp;
    protected int expLevel = 500;
    protected int planeLevel;
    protected float kLevel;
    public int weaponLevel { set; get; }
    public Transform firePoint { set; get; }
    void Start()
    {
        Init();
    }

    protected void SkillBomb()
    {
        if (bombNum <= 0)
        {
            return;
        }
        AddBomb(-1);
        GameObject go = LoadManager.LoadObj(bombStr);
        GameObject bomb = Instantiate(go,bombPos,Quaternion.identity);
        bomb.GetComponent<Bomb>().Init(this);
    }

    public void AddBomb(int n)
    {
        bombNum += n;
        GameManager._instance.UpdateBomb(bombNum);
    }

    public void Calculation()
    {
        realAtt = weapon.att * att;
    }

    protected void UpdateValue()
    {
        maxHp = (int)(maxHp*kLevel);
        att = att * kLevel;
        speed = speed * 1.2f;
        Calculation();
    }

    protected virtual void Init()
    {
        firePoint = transform.Find("Point");
        weaponLevel = 0;
        hp = maxHp;
    }

    public void PlaneLevel(int _exp)
    {
        exp += _exp;
        if (exp >= expLevel&& planeLevel < 3)
        {
            planeLevel = Mathf.Clamp(++planeLevel, 0, 3);
            exp -= expLevel;
            expLevel *= 2;
            LoadPlaneUp();
        }
    }

    protected void LoadPlaneUp()
    {
        Sprite sprite = Resources.Load<Sprite>("Plane/" + transform.name + planeLevel);
        GetComponent<SpriteRenderer>().sprite = sprite;
        UpdateValue();
        GameManager._instance.AddStar();
    }

    protected void Ctrl()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xpos = x * speed * Time.deltaTime + transform.position.x;
        xpos = Mathf.Clamp(xpos, GameManager.xWidth.x, GameManager.xWidth.y);

        float ypos = y * speed * Time.deltaTime + transform.position.y;
        ypos = Mathf.Clamp(ypos, GameManager.yHeight.x, GameManager.yHeight.y);


        transform.position = new Vector3(xpos, ypos, GameManager.planeZ);
    }


    public void Fire()
    {
        if (Input.GetKey(KeyCode.J))
        {
            weapon.Fire();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SkillBomb();
        }
    }

    void Update()
    {
        Ctrl();
        Fire();
        if (Input.GetKeyDown(KeyCode.L))
        {
            weapon.Level++;
        }
    }

    public virtual void Hurt(Plane plane,float f)
    {
        hp -=Mathf.CeilToInt(f);
        hp = Mathf.Clamp(hp, -100, maxHp);
        MyPlaneHurt();
        if (hp > 0)
        {
            return;
        }
        PlaneDeath(plane);
    }

    protected virtual void MyPlaneHurt()
    {
        float f = (float)hp / maxHp;
        GameManager._instance.UpdateHp(f);
    }

    //public void Hurt(Plane plane,int hurt)
    //{
    //    hp -= Mathf.CeilToInt(hurt);
    //    if (hp > 0)
    //    {
    //        return;
    //    }
    //    PlaneDeath(plane);
    //}

    protected virtual void PlaneDeath(Plane plane)
    {
        GameManager.PlayAudio("Bomb");
        GameObject go = GetLeftTool("Bomb");
        Destroy(go, 1);
        Destroy(gameObject);
    }

    protected virtual GameObject GetLeftTool(string n)
    {
        if (n == "BagNone")
        {
            return null;
        }
        return LoadManager.LoadObj(n, transform.position);
    }

    public void WeapnLevelUp(ToolType type)
    {
        if (type==weapon.type)
        {
            weapon.WeaponLevel();
        }
        else
        {
            int num = 0;
            num = weapon.Level;
            weapon = Weapon.MyWeapon[type](this);
            weapon.Level = num;
        }
    }
}
