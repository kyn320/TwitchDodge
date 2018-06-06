using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEndPanel : MonoBehaviour
{

    public Text highScoreText;
    public Text scoreText;

    public void View()
    {
        gameObject.SetActive(true);

        int score = (int)GameManager.Instance.playTime;
        int high = PlayerPrefs.GetInt("HighScore", score);

        highScoreText.text = string.Format("{0}", high);
        scoreText.text = string.Format("{0}", score);
    }

    public void OnExit()
    {
        SceneManager.LoadScene("start");
    }

    public void OnReplay()
    {
        SceneManager.LoadScene("ingame");
    }

}
