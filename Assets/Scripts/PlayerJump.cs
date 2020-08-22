using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.0f; // The force 
    private float jumpTimeCounter; // Count down the <jumpTime>
    [SerializeField] private float jumpTime; // The time allowed for the player to keep jumping

    private bool isJumping; // Check if the player is holding down Space to keep getting higher

    private bool isGrounded; // Check if the player is grounded to reset jump

    private Rigidbody rb; // The player's <RigidBody>

    [SerializeField] private GameObject landingParticles; // Particles on player's landing
    private bool shouldSpawnParticles;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Set the <RigidBody of our player

        // Give bool variable a start value
        isGrounded = true;
        isJumping = false;
        shouldSpawnParticles = false;
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector3.up * jumpForce;

            // Reset the spawn particles
            shouldSpawnParticles = true;
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
        isGrounded = (transform.position.y <= 0.5f);

        // Spawn our <landingParticles>
        if (isGrounded && shouldSpawnParticles && !isJumping) {
            GameObject particles = Instantiate(
                landingParticles,
                transform.position - new Vector3(0, 0.4F, 0),
                Quaternion.identity
                );
            
            shouldSpawnParticles = false; // Disable

            Destroy(particles, 1F); // Destroy the particles after a while
        }
    }
}
