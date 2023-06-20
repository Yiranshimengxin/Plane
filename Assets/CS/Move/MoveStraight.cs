using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MoveStyle
{


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);
    }
}
