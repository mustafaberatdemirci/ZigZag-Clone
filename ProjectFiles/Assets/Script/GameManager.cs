using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Degiskenleri")] 
    public int score;
    public Text scoreText;
    public Text bestText;
    public Text highText;
    public Text lastScoreText;
    public Text diamondText;
    public int diamondScore;

    public Text mainGameScore;
    //public int cscore=0;

    [Header("Gameover Degiskenleri")] 
    public bool gameover;
    public GameObject gameoverpanel, ingamepanel;
    //public bool startgame = false;
    MenuManager _menuManager2;
    
    //public int toplam;
    //BallController _clickscore;
    void Start()
    {
        _menuManager2 = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        highText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        _menuManager2.exitbutton.SetActive(false);
        gameoverpanel.SetActive(false);
        ingamepanel.SetActive(true);
        score = 0;
        //_clickscore = GameObject.Find("Ball Controller").GetComponent<BallController>();
    }

    IEnumerator GameOverPanel()
    {
        yield return new WaitForSeconds(0.33f);
        gameoverpanel.SetActive(true);
        _menuManager2.exitbutton.SetActive(true);
        ingamepanel.SetActive(false);
        GameOver();
    }

    void Update()
    {
        if (gameover == true)
        {
            StartCoroutine("GameOverPanel");
        }

        scoreText.text = score.ToString();
        mainGameScore.text = scoreText.text;

        //cscore=_clickscore.clickScore;
        //toplam = diamondScore+cscore;
    }


    public void GameOver()
    {
        lastScoreText.text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        bestText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CollectDiamond()
    {
        diamondScore++;
        diamondText.text = diamondScore.ToString();
    }
}