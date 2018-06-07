using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirectMove : BulletMove
{

    void FixedUpdate()
    {
        tr.position += bulletDir.GetDir() * Time.deltaTime * moveSpeed;
    }

}
