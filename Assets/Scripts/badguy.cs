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
        badguyAudio = GetComponent<AudioSource>();
        Gamemanager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        player = GameObject.Find("Player");
        badguyRb = GetComponent<Rigidbody>();
        transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.Gameisrunning == true)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            badguyRb.AddForce(lookDirection * speed);
        }

        if (transform.position.y <= -5f)
        {
            Debug.Log("game Over!");
            Gamemanager.gameover();        
            Destroy(gameObject, deathSound.length);
            if(!badguyAudio.isPlaying)
            {
                badguyAudio.PlayOneShot(deathSound, 1f);
            }
            


        }

        
    }
}
