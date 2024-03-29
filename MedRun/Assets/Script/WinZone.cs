using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    //create a variable to keep track of
    //whether th trigger zone is active
    private AudioSource finishSound;
    bool active = true;


    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        // if the trigger zone is active...
        if (active && collision.gameObject.tag == "Player")
        {
            //deactivate the trigger zone
            active = true;



            //Add 1 sto the core
            // when the player enters the trigger zone
            ScoreManager.score++;
            gameObject.SetActive(true);

            finishSound.Play();

        }
    }

}