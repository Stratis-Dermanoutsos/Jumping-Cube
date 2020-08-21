using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Text highScoreText;

    // Property to access the <highScore> PlayerPrefs variable
    public int HighScore { get { return PlayerPrefs.GetInt("highScore"); } }

    void Awake() 
    {
        deathPanel.SetActive(false); // Deactivate the <deathPanel> by default
    }

    void Update()
    {
        // If the player falls off the map, die
        if (gameObject.transform.position.y <= 0) Die();
    }

    public void Die()
    {
        deathPanel.SetActive(true); // Activate the <deathPanel>
        highScoreText.text = string.Format("Best: {0} m.", HighScore); // Set the <highScoreText> to <HighScore>

        Destroy(gameObject); // Destroy self
    }
}
