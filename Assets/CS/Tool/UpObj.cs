using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpObj : FlyObj
{
    public ToolType type;

    protected void Start()
    {
        base.Start();
        //clip = Resources.Load<AudioClip>("Audio/LevelUp");
    }


    protected override void Effect(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        switch(type)
        {
            case ToolType.Bomb:
                other.GetComponent<Plane>().AddBomb(1);
                break;
            case ToolType.Health:

                other.GetComponent<Plane>().Hurt(null, -30);
                break;
            default:
                GameManager.PlayAudio("LevelUp");
                other.GetComponent<Plane>().WeapnLevelUp(type);
                break;
        }
        Destroy(gameObject);
    }
}
