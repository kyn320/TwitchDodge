using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletDirection))]
public class BulletMove : MonoBehaviour
{

    protected Transform tr;
    protected BulletDirection bulletDir;

    void Awake()
    {
        tr = GetComponent<Transform>();
        bulletDir = GetComponent<BulletDirection>();
    }

    public virtual void SetTarget(Transform _target)
    {

    }

    public virtual void SetDir(Transform _target = null)
    {

    }
}
