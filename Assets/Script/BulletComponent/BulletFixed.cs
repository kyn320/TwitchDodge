using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFixed : MonoBehaviour
{
    Transform tr;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    void OnEnable()
    {
        SetPosition();
    }

    void SetPosition()
    {
        if (!GameManager.Instance.isPlay)
            return;

        tr.position = ObjectGenerator.Instance.GetRandomPosition(tr.localScale * 2);
    }

}
