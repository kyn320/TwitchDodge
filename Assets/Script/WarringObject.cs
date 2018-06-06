using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarringObject : MonoBehaviour
{
    public string message;
    public WarringLine line;
    public TextMesh textMesh;
    public Vector3 center;
    public Vector3 size;
    public Vector3 dir;


    public void Start()
    {
        textMesh.text = message;
        center.y = transform.position.y;
        line.SetWarring(center, size, dir);
    }



}
