using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    Vector3 startPos = new Vector3(0, 20, 0);
    Vector3 targetPos = new Vector3(0, -20, 0);
    float speed = -1;
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y<targetPos.y)
        {
            transform.position = startPos;
        }
    }
}
