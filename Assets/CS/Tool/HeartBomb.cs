using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBomb : Bomb
{
    public override void Init(Plane _plane)
    {
        base.Init(_plane);
        att = 600;
        r = 6;
        bombTime = 2;
        interval = 3;
    }
}
