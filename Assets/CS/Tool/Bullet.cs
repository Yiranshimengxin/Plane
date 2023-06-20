using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : FlyObj
{
    float att;
    Plane p;
    protected string explode="Explode";
    public Plane plane {
        set {
            p = value;
            tag = value.tag;
            att = value.realAtt;
        }
        get {
            return p;
        }
    }

    protected void GeneraceExplode()
    {
        GameObject exp = LoadManager.LoadObj(explode,transform.position+new Vector3(0,0,-0.1f));
        Destroy(exp,1);
    }

    protected override void Effect(Collider other)
    {
        if (other.tag== tag)
        {
            return;
        }

        if (other.tag!="Player"&&other.tag!="Enemy")
        {
            return;
        }
        //Destroy(other.gameObject);
        GeneraceExplode();
        other.GetComponent<Plane>().Hurt(plane,att);
        Destroy(gameObject);
    }

    public void SetDirect(Vector3 direct)
    {
        GetComponent<MoveStyle>().SetAngle(direct);
    }
}
