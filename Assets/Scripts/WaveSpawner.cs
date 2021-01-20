using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject positionSpawnN;
    public GameObject positionSpawnO;
    public GameObject positionSpawnS;
    public GameObject positionSpawnW;
    public float xoffset;
    public float yoffset;
    public gamemanager Gamemanager;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int wavenumber = 0;
    private int enemiestospawn = 10;

    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    if (Gamemanager.Gameisrunning == true && countdown <= 0 && Gamemanager.enemiesLeft == 0)
        {
            StartCoroutine(spawnwave()); 
            countdown = timeBetweenWaves;
        }
    if (Gamemanager.Gameisrunning)
        {
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
        }
       
    }

    IEnumerator spawnwave()
    {
        wavenumber += 1;

        for (int i = 0; i < enemiestospawn * wavenumber; i++)
        {
            spawnbadguy();
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    void spawnbadguy()
    {
        float tempx = Random.Range(-xoffset, xoffset);
        float tempy = Random.Range(-yoffset, yoffset);
        Instantiate(enemy, new Vector3(positionSpawnN.transform.position.x + tempx,
            1f, positionSpawnN.transform.position.z + tempy), Quaternion.identity);
    }
}
