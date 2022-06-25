using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int playerLife = 3, phase=1;
    float survivedTime;
    public Text phaseTxt, timeTxt, lifeTxt;
    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        survivedTime = 0;
        lifeTxt.text = "남은 케이크 수 : " + (int)playerLife;
        phaseTxt.text = "페이즈 : " + (int)phase;
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        survivedTime += Time.deltaTime;
        timeTxt.text = "시간 : " + (float)survivedTime;
        if ((float)survivedTime / 30 >= phase)
        {
            phase = spawner.GetComponent<ddatSpawner>().addPhase();
            phaseTxt.text = "페이즈 : " + (int)phase;
        }
    }

    public void getCake()
    {
        playerLife--;
        lifeTxt.text = "남은 케이크 수 : " + (int)playerLife;
        if (playerLife <= 0)
        {
            PlayerPrefs.SetFloat("Score", survivedTime);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
