using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        Titlescreen.gameObject.SetActive(true);
        Gameisrunning = false; 
        gameoverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
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

    }
    public void startgame()
    {
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
