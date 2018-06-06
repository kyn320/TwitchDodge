using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCurveMove : BulletMove
{
    public float lenght = 1f;
    public float height = 1f;

    public float moveSpeed = 3f;

    void Update()
    {
        tr.position += height
            * (Mathf.Sin(2 * Mathf.PI * lenght * Time.time)
            - Mathf.Sin(2 * Mathf.PI * lenght * (Time.time - Time.deltaTime)))
            * bulletDir.GetSinAxis();

       tr.position += bulletDir.GetDir() * moveSpeed * Time.deltaTime;
    }

}
