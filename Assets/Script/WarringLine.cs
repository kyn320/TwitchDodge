using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarringLine : MonoBehaviour
{

    public Vector3 center;
    public Vector3 size;
    public Vector3 dir;

    Transform tr;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }
    
    public void SetWarring(Vector3 _center, Vector3 _size, Vector3 _dir)
    {
        center = _center;
        size = _size;
        dir = _dir;

        tr.position = center;
        tr.localRotation = Quaternion.Euler(0,0,Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg);
        tr.localScale = size;
    }

}
