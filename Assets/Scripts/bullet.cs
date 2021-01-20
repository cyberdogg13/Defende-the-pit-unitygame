using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public gamemanager Gamemanager;

    // Start is called before the first frame update
    void Start()
    {
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


        transform.Translate(Vector3.forward * Time.deltaTime * 40);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("floor"))
        {
            Destroy(gameObject);
            Debug.Log("kogel raakt een muur/vloer");
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("kogel raakt een enemy");
            Gamemanager.UpdateScore(5);
        }
       



    }
}
