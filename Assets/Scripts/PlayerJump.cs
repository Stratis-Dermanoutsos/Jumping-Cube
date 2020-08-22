using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.0f; // The force 
    private float jumpTimeCounter; // Count down the <jumpTime>
    [SerializeField] private float jumpTime; // The time allowed for the player to keep jumping

    private bool isJumping; // Check if the player is holding down Space to keep getting higher

    private bool isGrounded; // Check if the player is grounded to reset jump

    private bool justLanded; // Check when the player landed

    private Rigidbody rb; // The player's <RigidBody>

    [SerializeField] private GameObject landingParticles; // Particles on player's landing

    [Header("SFX")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Set the <RigidBody of our player

        audioSource = GetComponentInChildren<AudioSource>(); // Take the <AudioSource> component from child

        // Give bool variables a start value
        isGrounded = true;
        isJumping = false;
        justLanded = false;
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector3.up * jumpForce;

            audioSource.PlayOneShot(jumpSound); // Play the <jumpSound>

            // Reset the spawn particles
            justLanded = true;
        }

        // Hold to jump higher
        if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimeCounter > 0) {
            rb.velocity = Vector3.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
        } else {
            isJumping = false; // Stop when the <jumpTimeCounter> has reached 0
        }

        // Release to stop jumping
        if (Input.GetKeyUp(KeyCode.Space))
            isJumping = false;

        // Reset <isGrounded>
        isGrounded = (transform.position.y <= 0.5001f);

        // Landing
        if (isGrounded && justLanded && !isJumping) {
            GameObject particles = Instantiate(
                landingParticles,
                transform.position - new Vector3(0, 0.4F, 0),
                Quaternion.identity
            );

            audioSource.PlayOneShot(landSound); // Play the <landSound>
            
            justLanded = false; // Disable

            Destroy(particles, 1F); // Destroy the particles after a while
        }
    }
}
