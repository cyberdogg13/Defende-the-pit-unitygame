﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;
    public bool Gameisrunning;
    public GameObject Titlescreen;
    public TextMeshProUGUI enemiesleftText;
    public int enemiesLeft;
    public TextMeshProUGUI wingameText;
    public int winscore;


    // Start is called before the first frame update
    void Start()
    {
        wingameText.gameObject.SetActive(false);
        Titlescreen.gameObject.SetActive(true);
        Gameisrunning = false; 
        gameoverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("enemy").Length;
        enemiesleftText.text = "Enemiesleft: " + enemiesLeft;
        if (score == winscore)
        {
            Gameisrunning = false;
            restartButton.gameObject.SetActive(true);
            wingameText.gameObject.SetActive(true);
        }
    }
    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void gameover()
    {
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Gameisrunning = false;

    }
    public void startgame(int difficulty)
    {
        winscore = 75 * difficulty;
        score = 0;
        scoreText.text = "score: " + score;
        Gameisrunning = true;
        Titlescreen.gameObject.SetActive(false);


    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
