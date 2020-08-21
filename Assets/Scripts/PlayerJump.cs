using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.0f; // The force 
    private float jumpTimeCounter; // Count down the <jumpTime>
    [SerializeField] private float jumpTime; // The time allowed for the player to keep jumping

    private bool isJumping; // Check if the player is holding down Space to keep getting higher

    private bool isGrounded; // Check if the player is grounded to reset jump

    private Rigidbody rb; // The player's <RigidBody>

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Set the <RigidBody of our player
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector3.up * jumpForce;
        }

        // Hold to jump higher
        if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimeCounter > 0) {
            rb.velocity = Vector3.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
        } else {
            isJumping = false;
        }

        // Release to stop jumping
        if (Input.GetKeyUp(KeyCode.Space))
            isJumping = false;

        isGrounded = (transform.position.y <= 0.5001f); // Set the isGrounded based on the height
    }
}
