using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBomb : Bomb
{
    public override void Init(Plane _plane)
    {
        base.Init(_plane);
        att = 500;
        r = 4;
        bombTime = 2;
        interval = 3;
    }
}
