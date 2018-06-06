using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirectMove : BulletMove
{
    public float moveSpeed = 3f;

    public override void SetDir(Transform _target = null)
    {
        if (_target != null)
            bulletDir.SetDir(_target);
        else
            bulletDir.SetRandomDir();
    }

    void FixedUpdate()
    {
        tr.position += bulletDir.GetDir() * Time.deltaTime * moveSpeed;
    }

}
