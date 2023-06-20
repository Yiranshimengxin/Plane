using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    float missileHurt = 100;

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
        GeneraceExplode();
        other.GetComponent<Plane>().Hurt(plane, missileHurt);
        Destroy(gameObject);
    }
}
