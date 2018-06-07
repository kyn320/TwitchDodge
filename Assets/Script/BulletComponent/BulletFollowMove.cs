using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowMove : BulletMove
{
    public float stopDistance = 0.1f;

    void FixedUpdate()
    {
        if (bulletDir.GetDistance() > stopDistance * stopDistance)
        {
            tr.position = Vector2.Lerp(tr.position, bulletDir.target.position, Time.deltaTime * moveSpeed);
        }
    }




}
