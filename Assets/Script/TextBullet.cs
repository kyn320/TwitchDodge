using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBullet : MonoBehaviour
{
    Transform tr;
    TextMesh textMesh;

    public Vector3 moveDir;

    void Awake()
    {
        tr = GetComponent<Transform>();
        textMesh = GetComponent<TextMesh>();
    }

    public void SetText(char _data, int _dirCategory, int _moveCategory)
    {
        textMesh.text = _data.ToString();
        SetRandomDirection(_dirCategory);
        SetRandomMove(_moveCategory);
    }

    public void SetText(char _data, Transform _target, int _dirCategory, int _moveCategory)
    {
        textMesh.text = _data.ToString();
        SetRandomDirection(_dirCategory, _target);
        SetRandomMove(_moveCategory, _target);
    }

    public void SetRandomMove(int _category, Transform _target = null)
    {
        if (_target != null)
        {
            gameObject.AddComponent<BulletFollowMove>().SetTarget(_target);
            return;
        }

        switch (_category)
        {
            case 0:
                gameObject.AddComponent<BulletDirectMove>().SetTarget(_target);
                break;
            case 1:
                gameObject.AddComponent<BulletFollowMove>().SetTarget(_target);
                break;
            case 2:
                gameObject.AddComponent<BulletCurveMove>().SetTarget(_target);
                break;
        }
    }

    public void SetRandomDirection(int _category, Transform _target = null)
    {
        if (_target != null)
        {
            gameObject.AddComponent<BulletFollowDirection>().SetTarget(_target);
            return;
        }

        switch (_category)
        {
            case 0:
                gameObject.AddComponent<BulletDirection>().SetTarget(_target);
                break;
            case 1:
                gameObject.AddComponent<BulletFollowDirection>().SetTarget(_target);
                break;
        }
    }


}
