using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // Our player
    [SerializeField] private Vector3 offset = new Vector3( -7.2f, 0, -3 ); // Offset from our player

    // Update is called once per frame
    void LateUpdate()
    {
        // Take the <player>'s position without changing the y axis
        Vector3 playerPosition = new Vector3(
            player.transform.position.x, 
            3.5f, 
            player.transform.position.z
        );

        transform.position = playerPosition + offset; // Set the position Offset away from the <player>'s
    }
}
