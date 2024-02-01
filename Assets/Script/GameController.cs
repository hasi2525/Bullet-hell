using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームの進行やプレイヤーのスコアを管理するクラス
/// </summary>
public class GameController : MonoBehaviour
{
    //ゲームオーバーテキスト
    [SerializeField]
    GameObject gameOverText;

    //ゲームクリアテキスト
    [SerializeField]
    GameObject gameClearText;

    //スコアテキスト
    [SerializeField]
    Text scoreText;

    //スコア
    private int score = 0;
    //敵一機あたりのスコア
    private const int PointsPerEnemy = 100;
    //ゲームクリア目標ポイント
    private const int TargetScore = 3000;

    void Start()
    {
        // ゲームオーバーとゲームクリアの表示を初期化
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);
    }

    void Update()
    {
        // ゲームオーバーまたはゲームクリア時の入力処理
        if (gameOverText.activeSelf || gameClearText.activeSelf)
        {
            HandleInputForReloadScene();
        }
        // スコアが目標に達したらゲームクリア処理を呼ぶ
        else if (score >= TargetScore)
        {
            GameClear();
        }
    }

    /// <summary>
    /// 入力を処理してシーンをリロード
    /// </summary>
    private void HandleInputForReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetTimeScale(); // 時間をもとに戻す
            ReloadMainScene();
        }
    }

    /// <summary>
    /// メインシーンをリロード
    /// </summary>
    private void ReloadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// スコアを加算し、表示を更新
    /// </summary>
    public void AddScore()
    {
        score += PointsPerEnemy;
        UpdateScoreText();
    }

    /// <summary>
    /// ゲームオーバーの表示を行い、時間を停止
    /// </summary>
    public void GameOver()
    {
        gameOverText.SetActive(true);
        StopTime();
    }

    /// <summary>
    /// ゲームクリアの表示を行い、時間を停止
    /// </summary>
    public void GameClear()
    {
        gameClearText.SetActive(true);
        StopTime();
    }

    /// <summary>
    /// 時間を停止
    /// </summary>
    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// 時間をもとに戻す
    /// </summary>
    private void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// スコア表示を更新
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}