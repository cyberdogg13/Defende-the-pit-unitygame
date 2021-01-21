using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badguy : MonoBehaviour
{

    private Rigidbody badguyRb;
    private GameObject player;
    private float speed = 5.0f;
    public gamemanager Gamemanager;
    public AudioSource badguyAudio;
    public AudioClip deathSound;


    // Start is called before the first frame update
    void Start()
    {
        // de compenten vaststellen
        badguyAudio = GetComponent<AudioSource>();
        Gamemanager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        player = GameObject.Find("Player");
        badguyRb = GetComponent<Rigidbody>();

        // badguy naar de speler laten kijken bij spawn
        transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //als de game is gestart beweeg de badguy naar de speler
        if (Gamemanager.Gameisrunning == true)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            badguyRb.AddForce(lookDirection * speed);
        }

        // als de badguy in het gat valt verwijder deze en voer uit game over
        if (transform.position.y <= -5f)
        {
            Debug.Log("game Over!");
            Gamemanager.gameover();        
            Destroy(gameObject, deathSound.length);

            //alleen als er nig geen audio word afgespeelt speel de death sound.
            if(!badguyAudio.isPlaying)
            {
                badguyAudio.PlayOneShot(deathSound, 1f);
            }
            


        }

        
    }
}
