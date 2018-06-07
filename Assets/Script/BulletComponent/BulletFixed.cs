using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFixed : BulletMove
{
    void Awake()
    {
        tr = GetComponent<Transform>();
        SetPosition();
    }

    void OnEnable()
    {
        SetPosition();
    }

    public override void SetTarget(Transform _target = null)
    {
        SetPosition();
    }

    void SetPosition()
    {
        print("set position");

        if (!GameManager.Instance.isPlay)
            return;

        print("set position is work");
        tr.localPosition = ObjectGenerator.Instance.GetRandomPosition(tr.localScale * 2);
    }

}
