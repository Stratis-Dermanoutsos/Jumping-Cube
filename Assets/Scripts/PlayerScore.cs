using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text scoreText; // The text used to display the <score>
    private int score;

    // Property to handle the <highScore> PlayerPrefs variable
    public int HighScore
    {
        get { return PlayerPrefs.GetInt("highScore"); }
        set { PlayerPrefs.SetInt("highScore", value); }
    }

    void Update()
    {
        score = Mathf.RoundToInt(transform.position.z / 5); // Calculate <score>

        if (score > HighScore) HighScore = score; // Save the <highScore>

        scoreText.text = score.ToString() + " m."; // Display <score>
    }
}
