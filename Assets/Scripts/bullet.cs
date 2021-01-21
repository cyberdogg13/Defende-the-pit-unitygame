using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public gamemanager Gamemanager;
    public AudioSource bulletAudio;
    public AudioClip killSound;

    // Start is called before the first frame update
    void Start()
    {
        // componenten vastellen
        bulletAudio = GetComponent<AudioSource>();
        Gamemanager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        //verwijderd de kogel zodra deze uit het level is
        if (transform.position.z >= 45 || transform.position.z <= -45 || transform.position.x >= 45 || transform.position.x <= -45)
        {
            Destroy(gameObject);
        }

        // beweegt de kogel naar voren
        transform.Translate(Vector3.forward * Time.deltaTime * 40);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //check of de kogel een muur raakt en verwijder deze als hij nog geen badguy heeft aan geraakt.
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("floor") && !bulletAudio.isPlaying)
        {
            Destroy(gameObject);
            Debug.Log("kogel raakt een muur/vloer");
        }

        // als de kogel een badguy raakt maak de kogel ontzichtbaar en speel een killsound
        if (collision.gameObject.CompareTag("enemy"))
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;
            gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            Destroy(collision.gameObject);
            Destroy(gameObject, killSound.length);
            Debug.Log("kogel raakt een enemy");
            Gamemanager.UpdateScore(5);
            bulletAudio.PlayOneShot(killSound, 1f);


        }
        
       



    }
}
