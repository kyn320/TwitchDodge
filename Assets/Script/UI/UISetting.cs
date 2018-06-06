using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISetting : MonoBehaviour
{

    public InputField oauthField;

    public InputField nickNameField;

    void Start()
    {
        oauthField.text = PlayerPrefs.GetString("oauth", "");
        nickNameField.text = PlayerPrefs.GetString("nickName", "");
    }

    public void OnGameStart()
    {
        PlayerPrefs.SetString("oauth", oauthField.text);
        PlayerPrefs.SetString("nickName", nickNameField.text);

        SceneManager.LoadScene("ingame");
    }

}
