using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : FlyObj
{
    float att;
    Plane p;
    public Plane plane
    {
        set
        {
            p = value;
            att = value.realAtt * 2;
        }
        get
        {
            return p;
        }
    }

    protected override void Effect(Collider other)
    {
        if (other.tag == tag)
        {
            return;
        }

        if (other.tag != "Player" && other.tag != "Enemy")
        {
            return;
        }
        Plane p = other.GetComponent<Plane>();
        if (p)
        {
            other.GetComponent<Plane>().Hurt(plane, att);
        }
    }


    private void Update()
    {
        
    }
}
