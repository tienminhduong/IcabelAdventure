using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] private Player player;

    private float highScore;

    private void Start()
    {
        if (PlayerPrefs.HasKey(ConstValue.HIGH_SCORE))
        {
            highScore = PlayerPrefs.GetFloat(ConstValue.HIGH_SCORE);
        }
        else
        {
            highScore = 0f;
        }
    }

    private void Update()
    {
        scoreText.text = player.TotalPoint.ToString();
        highScoreText.text = $"High score: {highScore}";
    }
}
