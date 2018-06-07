using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBullet : MonoBehaviour
{
    Transform tr;
    TextMesh textMesh;

    void Awake()
    {
        tr = GetComponent<Transform>();
        textMesh = GetComponent<TextMesh>();
    }

    public void SetText() {
        GetComponent<BulletMove>().SetTarget();
    }

    public void SetText(char _data, float _speed)
    {
        textMesh.text = _data.ToString();
        GetComponent<BulletMove>().SetTarget();
        GetComponent<BulletMove>().SetSpeed(_speed);
    }

    public void SetText(char _data, Transform _target, float _speed)
    {
        textMesh.text = _data.ToString();
        GetComponent<BulletMove>().SetTarget(_target);
        GetComponent<BulletMove>().SetSpeed(_speed);
    }




}
