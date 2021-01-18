using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class difficultybuttons : MonoBehaviour
{

    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setdifficulty);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setdifficulty()
    {
        Debug.Log(gameObject.name + "was clicket");
    }
}
