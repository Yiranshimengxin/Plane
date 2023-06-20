using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : FlyObj
{
    
    public void Start()
    {
        base.Start();
    }

    protected override void Effect(Collider other)
    {
        if (other.tag=="Player")
        {
            GameManager._instance.AddGold(1);
            GameManager.PlayAudio("Gold");
            Destroy(gameObject);
        }
    }
}
