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
    public TextMeshProUGUI enemiesleftText;
    public int enemiesLeft;
    public TextMeshProUGUI wingameText;
    public int winscore;


    // Start is called before the first frame update
    void Start()
    {
        // de compenten vaststellen
        wingameText.gameObject.SetActive(false);
        Titlescreen.gameObject.SetActive(true);
        Gameisrunning = false; 
        gameoverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //teller voor hoeveel badguys er nog leven in de huidige wave
        enemiesLeft = GameObject.FindGameObjectsWithTag("enemy").Length;
        enemiesleftText.text = "Enemiesleft: " + enemiesLeft;

        //beindig de game zodra de benodigte punten zijn behaald
        if (score == winscore)
        {
            Gameisrunning = false;
            restartButton.gameObject.SetActive(true);
            wingameText.gameObject.SetActive(true);
        }
    }

    //functie voor het toevoegen van een score
    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // functie voor het beijndigen van de game
    public void gameover()
    {
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Gameisrunning = false;

    }

    // functie voor het starten van de gam e en het vast stellen van de winscore
    public void startgame(int difficulty)
    {
        winscore = 75 * difficulty;
        score = 0;
        scoreText.text = "score: " + score;
        Gameisrunning = true;
        Titlescreen.gameObject.SetActive(false);


    }

    // functie voor het herstarten van de game
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
