using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour
{
    [SerializeField]
    protected Vector3 dir;

    [SerializeField]
    protected float distance;

    protected Transform tr;
    [SerializeField]
    protected Transform target;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    public void SetDir(Vector3 _dir)
    {
        dir = _dir;
    }

    public void SetDir(Transform _target)
    {
        if (_target == null)
            _target = GameManager.Instance.player.transform;

        dir = (_target.position - tr.position).normalized;
    }

    public void SetRandomDir()
    {

    }

    public virtual void SetTarget(Transform _target)
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
            yield return null;
        }
    }

    public Vector3 GetDir()
    {
        return dir;
    }


    public Vector3 GetReversDir()
    {
        return new Vector3(dir.y, dir.x);
    }

    public Vector3 GetSinAxis()
    {
        int x = 0, y = 0;

        if (Mathf.Abs(dir.x) > 0.5f)
            x = dir.x > 0 ? 1 : -1;
        if (Mathf.Abs(dir.y) > 0.5f)
            y = dir.y > 0 ? 1 : -1;

        return new Vector3(y, -x);
    }

    public float GetDistance()
    {
        return distance;
    }
    
}
