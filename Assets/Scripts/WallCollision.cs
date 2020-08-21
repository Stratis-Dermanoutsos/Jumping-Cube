using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        // If the player collides with any wall, kill them
        if (other.name.Equals("Cube - Player"))
            GameObject.Find("Cube - Player").GetComponent<PlayerDeath>().Die();
    }
}
