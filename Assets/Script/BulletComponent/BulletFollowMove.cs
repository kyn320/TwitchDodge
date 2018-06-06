using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowMove : BulletMove
{
    public float moveSpeed = 5f;
    public float stopDistance = 0.1f;

    [SerializeField]
    Transform target;

    [SerializeField]
    Transform targetRoot;

    public override void SetTarget(Transform _target)
    {
        target = _target;
        targetRoot = GameManager.Instance.player.transform;
        bulletDir.SetTarget(target);
    }

    void FixedUpdate()
    {
        if (target == null || target.gameObject.activeSelf == false)
        {
            bulletDir.SetTarget(targetRoot);
        }

        if (bulletDir.GetDistance() > stopDistance * stopDistance)
        {
            tr.position = Vector2.Lerp(tr.position, target.position, Time.deltaTime * moveSpeed);
        }
    }




}
