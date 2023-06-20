using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBomb : Bomb
{
    public override void Init(Plane _plane)
    {
        base.Init(_plane);
        att = 100;
        r = 5;
        bombTime = 2;
        interval = 0.5f;
    }
}
