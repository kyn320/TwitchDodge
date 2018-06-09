using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChatCommand {

    public string command;
    public GameObject[] source;
    public bool isText = true;
    public bool isFixed = false;
}
