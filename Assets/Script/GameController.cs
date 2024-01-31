using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    GameObject gameOverText;

    [SerializeField]
    GameObject gameClearText;

    [SerializeField] 
    Text scoreText;

    private int score = 0;

    private const int points = 100;

    private const int TargetScore = 1000; // ゲームクリアのスコア目標

    void Start()
    {
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);
    }

    void Update()
    {
        if (gameOverText.activeSelf || gameClearText.activeSelf)
        {
            HandleInputForReloadScene();
        }
        else
        {
            if (score >= TargetScore)
            {
                GameClear();
            }
        }
    }

    void HandleInputForReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetTimeScale(); // 時間をもとに戻す
            ReloadMainScene();
        }
    }

    void ReloadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore()
    {
        score += points;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        StopTime();
    }

    public void GameClear()
    {
        gameClearText.SetActive(true);
        StopTime();
    }

    void StopTime()
    {
        Time.timeScale = 0f; // 時間を停止
    }
    void ResetTimeScale()
    {
        Time.timeScale = 1f; // 時間をもとに戻す
    }
}
