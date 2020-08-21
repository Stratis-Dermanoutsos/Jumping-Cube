using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // Initial position of the player
    [SerializeField] [Range(1f, 10f)] private float speed; // Player's speed
    [SerializeField] private Vector3 movement = new Vector3(0, 0, 1); // Only move in the z axis

    void Start()
    {
        transform.position = spawnPoint.transform.position; // Spawn at the <spawnPoint>
    }

    void Update()
    {
        transform.position += movement * speed * Time.deltaTime; // Move non-stop only forward by <speed>
    }
}
