using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowDirection : BulletDirection
{
    public Transform targetRoot;

    void Start()
    {
        SetTarget(target);
    }

    public override void SetTarget(Transform _target)
    {
        targetRoot = GameManager.Instance.player.transform;

        if (_target == null)
            _target = targetRoot;

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
            if (!target.gameObject.activeSelf)
                target = targetRoot;

            distance = (target.position - tr.position).sqrMagnitude;
            dir = (target.position - tr.position).normalized;
            yield return null;
        }
    }

}
