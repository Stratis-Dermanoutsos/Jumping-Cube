using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void Update()
    {
        // If the player falls off the map, die
        if (gameObject.transform.position.y <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
