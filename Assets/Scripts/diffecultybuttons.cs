using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diffecultybuttons : MonoBehaviour
{
    private Button button;
    private gamemanager Gamemanager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetDifficulty()
    {
        Gamemanager.startgame(difficulty);
        Debug.Log(gameObject.name + "was clicket" + difficulty + "winscore= " + Gamemanager.winscore );

    }
}
