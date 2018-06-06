using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSummon : MonoBehaviour
{

    Transform tr;

    public GameObject summonObject;

    public float summonWaitInterval = 0f;
    public float summonInterval = 0.5f;

    int count = 0;
    public int summonCount = 0;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }
    
    void OnEnable()
    {
        StartCoroutine(Summon());
    }

    IEnumerator Summon()
    {
        GameObject g = null;
        while (summonCount == 0 || count < summonCount)
        {
            yield return new WaitForSeconds(summonWaitInterval);
            g = ObjectPoolManager.Instance.Get(summonObject.name);
            g.transform.position = tr.position;
            ++count;
            yield return new WaitForSeconds(summonInterval);
        }
    }

}
