﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject bulletprefab;
    public gamemanager Gamemanager;

    //berekening voor het maken van een hoekgraad tussen 2 punten door punt A de X en Y waardes af te trekken van de X en Y waardes van punt B
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Gamemanager = GameObject.Find("gamemanager").GetComponent<gamemanager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.Gameisrunning == true)
        {
            Vector3 mouselocation = Input.mousePosition;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouselocation);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(transform.position, hit.point, Color.green);
                transform.LookAt(hit.point);
            }
            // creeert een kogel 
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 rot = transform.rotation.eulerAngles;
                rot = new Vector3(rot.x, rot.y, rot.z + 270);
                Instantiate(bulletprefab, transform.position, Quaternion.Euler(rot));
            }
        }
        
       
    }
   
}