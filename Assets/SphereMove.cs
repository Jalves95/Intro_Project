using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEditor;
using System;

public class SphereMove : MonoBehaviour
{ 
    public int score;
    public TMP_Text scoreText;
    public GameObject pauseText;
    private bool countDown;
    private float timer; 

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countDown= false;
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        //float speed = .05f;
        float speed = 20f * Time.deltaTime;

        /*if(Input.GetKey(KeyCode.W))
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        if (Input.GetKey(KeyCode.S))
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        if (Input.GetKey(KeyCode.A))
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.D))
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);*/

        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xMove, 0, zMove) * speed;
        transform.position += movement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                // unpausing
                pauseText.SetActive(false);
                Time.timeScale = 1;
            }
            else
            { 
            // pausing
            pauseText.SetActive(true);
            Time.timeScale = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            countDown = true;
        }


        if(countDown) //if countdown is true
        {
               //timer stuff
               if(timer < 3)
                {
                timer += Time.deltaTime;
                Debug.Log("Game is paused" + timer);
            }
            else
                {
                    //Application.Quit(); will not work
                    UnityEditor.EditorApplication.isPlaying = false;
                }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        float newX = UnityEngine.Random.Range(-10, 10);
        float newZ = UnityEngine.Random.Range(-10, 10);
        
        other.transform.position = new Vector3(newX , 0 + 7, newZ);
        ++score;
        
        scoreText.text = "Score: " + score;
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger currently active");
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger left");
    }

}
