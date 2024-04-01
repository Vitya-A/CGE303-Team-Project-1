using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add this to work with TextMeshPro
using TMPro;
// Add this to work with SceneManager to load or reload scenes
using UnityEngine.SceneManagement;

public class TutorialText : MonoBehaviour
{
    // notice public static variables can be accessed from any script but cannot be seen in the inspector
    public static bool gameOver;
    public static bool won;
    public static int score;

    // set this in the inspector
    public TMP_Text textbox;

    // Start is called before the first frame update
    private void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Reach the end!";
        }

        if (score >= 1)
        {
            won = true;
            gameOver = true;
        }

        // Check for lose condition here
        if (GameObject.FindGameObjectWithTag("LoseZone") != null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GameObject.FindGameObjectWithTag("LoseZone").GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
            {
                gameOver = true;
                won = false;
            }
        }

        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You win! Press R to try again!";
            }
            else
            {
                textbox.text = "You lose! Press R to try again!";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
