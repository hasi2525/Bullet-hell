using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの機体を制御するクラス
/// </summary>
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private GameObject explosion; // 撃破エフェクト
    private GameController gameController; // ゲームコントローラー
    [SerializeField] private Slider slider; // プレイヤーの体力を表示するスライダー

    private const float InitialHealth = 10f; // 初期体力
    private const float Damage = 1f; // ダメージ量

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        slider.value = InitialHealth;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    /// <summary>
    /// 衝突時の処理
    /// </summary>
    /// <param name="collision">衝突したコライダー</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            // ダメージを受ける
            TakeDamage();
        }
    }

    /// <summary>
    /// ダメージを受ける処理
    /// </summary>
    private void TakeDamage()
    {
        slider.value -= Damage;

        // 体力が0以下になったら撃破処理を実行
        if (slider.value <= 0)
        {
            slider.value = 0;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.GameOver();
        }
    }
}