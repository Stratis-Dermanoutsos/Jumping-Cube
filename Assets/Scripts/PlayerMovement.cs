using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // Initial position of the player
    [SerializeField] private Vector3 movement = new Vector3(0, 0, 1); // Only move in the z axis

    [Header("Speed")]
    [SerializeField] [Range(1f, 20f)] private float startingSpeed; // Initial speed
    [SerializeField] [Range(0f, 1f)] private float timeMultiplier;
    [SerializeField] [Range(10f, 40f)] private float maxSpeed; // Max speed
    [SerializeField] private float speed; // Player's speed - [SerializeField] used for debugging

    private float loadTime;

    void Awake()
    {
        transform.position = spawnPoint.transform.position; // Spawn at the <spawnPoint>

        speed = startingSpeed; // Set the <speed> to <startingSpeed>

        loadTime = Time.timeSinceLevelLoad; // Take the time the level was loaded
    }

    void Update()
    {
        if (speed < maxSpeed) { // If the maximum speed has not been reached yet
            // Add the current time that this level has been loaded and devide by 
            timeMultiplier += (Time.deltaTime - loadTime) / 100000000;

            speed += timeMultiplier; // Increase <speed> by <timeMultiplier> every <Update>
        }

        transform.position += movement * speed * Time.deltaTime; // Move non-stop only forward by <speed>
    }
}
