using System.Collections;
using UnityEngine;

/// <summary>
/// ボスの機体を制御するクラス。
/// </summary>
public class BossShip : MonoBehaviour
{
    // 爆破エフェクト
    public GameObject explosion;

    // GameControllerのAddScoreメソッドを使用するための入れ物
    GameController gameController;

    // ボスの体力
    [SerializeField, Tooltip("ボスの体力")] private int maxHp = 20;
    private int currentHp;

    // 特定の位置より上の目標位置
    [SerializeField, Tooltip("ボスが移動する目標のY座標")] private float targetYPosition = 3.5f;

    void Start()
    {
        // GameControllerを検索して取得
        gameController = GameObject.FindObjectOfType<GameController>();

        // 初期化
        currentHp = maxHp;

        // CPUコルーチンを開始
        StartCoroutine("CPU");
    }

    /// <summary>
    /// ボスの移動を制御するコルーチン。
    /// </summary>
    IEnumerator CPU()
    {
        // 特定の位置より上だったら
        while (transform.position.y > targetYPosition)
        {
            // 上に移動
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null; // 1フレーム(0.02秒)待つ 
        }
    }

    /// <summary>
    /// Bossの当たり判定を処理するメソッド。
    /// </summary>
    /// <param name="collision">衝突したコライダー</param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // PlayerとBossが接触した時
        if (collision.CompareTag("Player"))
        {
            // 破壊する時に爆破エフェクト生成
            Instantiate(explosion, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);
            gameController.GameOver();
        }
        // BulletとBossが接触した時
        else if (collision.CompareTag("Bullet"))
        {
            // BossのHpを減少
            currentHp--;

            // Hpが0以下になったら
            if (currentHp <= 0)
            {
                // スコアを追加
                gameController.AddScore();

                // Enemyの機体を破壊
                Destroy(gameObject);

                // 破壊する時に爆破エフェクト生成
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
    }
}
