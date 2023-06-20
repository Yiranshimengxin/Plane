using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Plane plane { set; get; }
    public int att { set; get; }
    public int r { set; get; }
    public float bombTime;
    public float interval { set; get; }
    protected float time=-100;

    public virtual void Init(Plane _plane)
    {
        plane = _plane;
    }
    private void Start()
    {
        //StartCoroutine(BombHurt());
        InvokeRepeating("Hun",0,interval);
        Destroy(gameObject,bombTime);
    }

    //IEnumerator BombHurt()
    //{
    //    time = Time.time;
    //    while (Time.time - time < bombTime)
    //    {
    //        Collider[] colls = Physics.OverlapSphere(transform.position,
    //        r, LayerMask.GetMask("Enemy"), QueryTriggerInteraction.Collide);
    //        foreach (Collider c in colls)
    //        {
    //            Hurt(c.GetComponent<Plane>());
    //        }

    //        yield return new WaitForSeconds(interval);
    //    }
    //}

    void Hun()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position,
           r, LayerMask.GetMask("Enemy"), QueryTriggerInteraction.Collide);
        foreach (Collider c in colls)
        {
            Hurt(c.GetComponent<Plane>());
        }

        colls = Physics.OverlapSphere(transform.position,
           r, LayerMask.GetMask("Bullet"), QueryTriggerInteraction.Collide);
        foreach (Collider c in colls)
        {
            Destroy(c.gameObject);
        }
    }


    protected virtual void Hurt(Plane other)
    {
        other.Hurt(plane,att);
    }

}
