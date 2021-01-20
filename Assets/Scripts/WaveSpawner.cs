using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> spawnpoints;
    // public GameObject positionSpawnN;
    // public GameObject positionSpawnO;
    // public GameObject positionSpawnS;
    // public GameObject positionSpawnW;
    public float xoffset;
    public float yoffset;
    public gamemanager Gamemanager;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int wavenumber = 0;
    private int enemiestoSpawn = 5;

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
        }
       
    }

    IEnumerator spawnwave()
    {
        wavenumber += 1;

        for (int i = 0; i < enemiestoSpawn * wavenumber; i++)
        {
            spawnbadguy();
            yield return new WaitForSeconds(0.8f);
        }
        
    }
    void spawnbadguy()
    {
        int index = Random.Range(0, spawnpoints.Count);
        float tempx = Random.Range(-xoffset, xoffset);
        float tempy = Random.Range(-yoffset, yoffset);
        Instantiate(enemy, new Vector3(spawnpoints[index].transform.position.x + tempx,
            1f, spawnpoints[index].transform.position.z + tempy), Quaternion.identity);
    }
}
