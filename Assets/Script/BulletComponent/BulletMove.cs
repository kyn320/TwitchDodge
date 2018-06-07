using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletDirection))]
public class BulletMove : MonoBehaviour
{

    protected Transform tr;
    protected BulletDirection bulletDir;

    public float moveSpeed = 1f;

    void Awake()
    {
        tr = GetComponent<Transform>();
        bulletDir = GetComponent<BulletDirection>();
    }

    public virtual void SetTarget(Transform _target = null)
    {
        bulletDir.SetTarget(_target);
    }

    public virtual void SetSpeed(float _speed)
    {
        if (_speed > 0)
            moveSpeed = _speed;
    }
}
