using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript Logic;
    public bool birdIsAlive = true;
    public AudioSource deathAudio; // Add this line to declare the AudioSource

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        deathAudio = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            Logic.gameOver();
            birdIsAlive = false;
            deathAudio.Play(); // Play the death audio clip
        }
    }

    public void OnColliderEnter2D(BoxCollider2D collider)
    {
        if (collider is null)
        {
            throw new ArgumentNullException(nameof(collider));
        }

        if (birdIsAlive)
        {
            Logic.gameOver();
            birdIsAlive = false;
            deathAudio.Play(); // Play the death audio clip
        }
    }
}
