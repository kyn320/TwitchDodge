using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolCollider : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D _col)
    {
        ObjectPoolManager.Instance.Free(gameObject);
    }

}
