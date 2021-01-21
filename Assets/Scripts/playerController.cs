using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject bulletprefab;
    public gamemanager Gamemanager;
    public float firerate = 0.45f;
    public AudioSource playerAudio;
    public AudioClip fireSound;
 


    //berekening voor het maken van een hoekgraad tussen 2 punten door punt A de X en Y waardes af te trekken van de X en Y waardes van punt B
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // de compenten vaststellen
        playerAudio = GetComponent<AudioSource>();
        Gamemanager = GameObject.Find("gamemanager").GetComponent<gamemanager>();

    }

    // Update is called once per frame
    void Update()
    {
       // een coldown timer voor het schieten zodat je niet oneindig vaak kan schietten achter eklaar
        firerate -= Time.deltaTime;

        // als de game is gestart beweeg de turret naar de muis locatie
        if (Gamemanager.Gameisrunning == true)
        {
            Vector3 mouselocation = Input.mousePosition;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouselocation);
            if (Physics.Raycast(ray, out hit) && Gamemanager.Gameisrunning)
            {
                Debug.DrawRay(transform.position, hit.point, Color.green);
                transform.LookAt(hit.point);
            }
            // creeert een kogel 
            if (Input.GetMouseButtonDown(0) && firerate <= 0 && Gamemanager.Gameisrunning)
            {
                playerAudio.PlayOneShot(fireSound, 1.0f);
                firerate = 0.45f;
                Vector3 rot = transform.rotation.eulerAngles;
                rot = new Vector3(rot.x, rot.y, rot.z + 270);
                Instantiate(bulletprefab, transform.position, Quaternion.Euler(rot));
            }
        }
        
       
    }
   
}
