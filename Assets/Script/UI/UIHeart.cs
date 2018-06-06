using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeart : MonoBehaviour
{
    public GameObject[] heartIcon;

    public void UpdateHp(int _hp)
    {
        for (int i = 0; i < heartIcon.Length; ++i)
        {
            if (i < _hp)
                heartIcon[i].SetActive(true);
            else
                heartIcon[i].SetActive(false);
        }
    }

}
