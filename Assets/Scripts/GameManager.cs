using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonObject<GameManager>
{
    [SerializeField] private float gameSpeed;
    [SerializeField] private float maxGameSpeed;
    [SerializeField] private Transform playerCenterTransform;

    [SerializeField] private Player player;
    public float PlayerScore => player.TotalPoint;

    [SerializeField] private TextMeshProUGUI endgameScoreUI;

    public float GameSpeed => Mathf.Min(gameSpeed + player.TotalPoint / 300, maxGameSpeed);
    public Vector3 PlayerCenterPosition => playerCenterTransform.position;

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(ConstValue.PLAY_SCENE);
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        endgameScoreUI.text = $"Your score: {player.TotalPoint}";
        PlayerPrefs.SetFloat(ConstValue.PLAY_SCORE, player.TotalPoint);

        if (PlayerPrefs.HasKey(ConstValue.HIGH_SCORE))
        {
            if (player.TotalPoint > PlayerPrefs.GetFloat(ConstValue.HIGH_SCORE))
            {
                PlayerPrefs.SetFloat(ConstValue.HIGH_SCORE, player.TotalPoint);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(ConstValue.HIGH_SCORE, player.TotalPoint);
        }
    }
}
