using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text record, highRecord;
    public Button retry;
    float highScore, score;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore")|| (PlayerPrefs.GetFloat("HighScore") < PlayerPrefs.GetFloat("Score"))) { 
            PlayerPrefs.SetFloat("HighScore", PlayerPrefs.GetFloat("Score"));
            highScore = PlayerPrefs.GetFloat("Score");
            score = PlayerPrefs.GetFloat("Score");
        }
        else {
            highScore = PlayerPrefs.GetFloat("HighScore");
            score = PlayerPrefs.GetFloat("Score");
        }
        record.text = "점수 : " + score;
        highRecord.text = "최고점수 : " + highScore;
        retry.onClick.AddListener(Retry);
    }
    void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
