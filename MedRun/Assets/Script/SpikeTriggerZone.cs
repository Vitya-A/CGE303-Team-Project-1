using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpikeTriggerZone : MonoBehaviour
{
    public TMP_Text output;
    public string textToDisplay;
    public static bool gameOver;

    private void Start()
    {
        gameOver = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOver = true;
            output.text = textToDisplay;
        }
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            /*CharacterController cc = GetComponent<CharacterController>();
            cc.enabled = false;*/
        }
    }
}
