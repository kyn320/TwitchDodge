using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : Singleton<ObjectGenerator>
{
    public Vector3 center;
    public Vector3 size;

    public Vector2 GetRandomPosition(Vector2 _size)
    {
        float x = Random.Range((center.x - size.x * 0.5f) + _size.x, (center.x + size.x * 0.5f) - _size.x);
        float y = Random.Range((center.y - size.y * 0.5f) + _size.y, (center.y + size.y * 0.5f) - _size.y);

        return new Vector2(x, y);
    }

    public Vector2 GetRandomEdgePosition()
    {

        int randEdge = Random.Range(0, 4);

        switch (randEdge)
        {
            case 0:
                return new Vector2(center.x - size.x * 0.5f, Random.Range(center.y - size.y * 0.5f, center.y + size.y * 0.5f));
            case 1:
                return new Vector2(center.x + size.x * 0.5f, Random.Range(center.y - size.y * 0.5f, center.y + size.y * 0.5f));
            case 2:
                return new Vector2(Random.Range(center.x - size.x * 0.5f, center.x + size.x * 0.5f), center.y - size.y * 0.5f);
            case 3:
                return new Vector2(Random.Range(center.x - size.x * 0.5f, center.x + size.x * 0.5f), center.y + size.y * 0.5f);
        }

        return Vector2.zero;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(center, size);
    }

}
