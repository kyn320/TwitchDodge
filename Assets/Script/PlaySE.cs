using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour {

    public string seName;

    void OnEnable() {
        if (!GameManager.Instance.isPlay)
            return;

        SoundManager.Instance.PlaySE(seName);
    }

}
