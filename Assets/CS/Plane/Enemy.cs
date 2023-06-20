using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Plane
{
    MoveStyle ms;
    Plane plane;
    
    public List<int> leftToolRate = new List<int>();

    protected void Start()
    {
        base.Init();
        ms = GetComponent<MoveStyle>();
        weapon = GetComponent<Weapon>();
        realAtt = 10;
    }

    int GetLeftObj()
    {
        int num = Random.Range(0, 100);
        int objNum = leftToolRate.Count;
        for (int i=0;i<objNum;i++)
        {
            int sum = 0;
            for (int j=0;j<=i;j++)
            {
                sum += leftToolRate[j];
            }
            if (num<sum)
            {
                return i;
            }
        }
        return -1;
    }

    protected override void MyPlaneHurt()
    {
        
    }

    public override void Hurt(Plane plane, float f)
    {
        hp -= Mathf.CeilToInt(f);
        BossHurt();
        if (hp > 0)
        {
            return;
        }
        PlaneDeath(null);
    }

    protected virtual void BossHurt()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        ms.Move();
    }

    protected override void PlaneDeath(Plane _plane)
    {
        plane = GameManager._instance.myPlane.GetComponent<Plane>();
        int n = GetLeftObj();
        GetLeftTool("Bag" + ((ToolType)n).ToString());
        GetGold(0.5f);
        plane.PlaneLevel(maxHp);
        base.PlaneDeath(plane);

    }

    void GetGold(float r)
    {
        GameObject gold = LoadManager.LoadObj("Gold");
        for (int i = 0; i <= maxHp/50; i++)
        {
            Vector3 v2 = Random.insideUnitCircle * r;
            Vector3 v3 = v2 + transform.position;
            GameObject g = Instantiate(gold,v3,Quaternion.identity);
            g.GetComponent<MoveFollow>().SetInit(0.1f,GameManager._instance.myPlane.transform,0.2f);
        }
    }
}
