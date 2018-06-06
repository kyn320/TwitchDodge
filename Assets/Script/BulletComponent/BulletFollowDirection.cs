using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowDirection : BulletDirection
{

    void Start() {
        SetTarget(target);
    }

    public override void SetTarget(Transform _target)
    {
        if (_target == null)
            _target = GameManager.Instance.player.transform;

        target = _target;
        SetDir(target);

        if (updateTarget != null)
            StopCoroutine(updateTarget);

        updateTarget = StartCoroutine(UpdateTarget());
    }

    Coroutine updateTarget = null;

    IEnumerator UpdateTarget()
    {
        while (target != null)
        {
            distance = (target.position - tr.position).sqrMagnitude;
            dir = (target.position - tr.position).normalized;
            yield return null;
        }
    }

}
