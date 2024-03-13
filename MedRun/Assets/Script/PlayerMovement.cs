using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;

    private Rigidbody2D rb;
    private float horizontalInput;

    // An audio clip to hold jump sound
    public AudioClip jumpSound;

    // An audio source to play our sounds
    private AudioSource playerAudio;

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input values for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded && !ScoreManager.gameOver)
        {
            // Apply an upward force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void FixedUpdate()
    {
        // Move the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionTag")
        {
            audioPlayer.Play();
        }
    }
}

