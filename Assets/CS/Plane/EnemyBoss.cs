using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public StateBoss state { set; get; }
    public const int stateNum = 3;
    public List<float> stateHp = new List<float>();
    public List<Transform> points = new List<Transform>();
    void Start()
    {
        base.Start();
        Init();
        state = new StateAwake(this,null);
    }

    new void Init()
    {
        realAtt = 10;
        for (int i = stateNum - 1; i >= 0; i--)
        {
            stateHp.Add(hp * i /(float)stateNum);
        }
        foreach (Transform item in transform)
        {
            points.Add(item);
        }
    }

    void Update()
    {
        state.TimeChange();
        state.Fire();
        state.Move();
    }

    protected override void BossHurt()
    {
        float f = hp / (float)maxHp;
        GetComponent<SpriteRenderer>().color = new Color(1, f, f);
        state.ChangeState();
    }
}
