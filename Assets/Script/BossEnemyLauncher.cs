using System.Collections;
using UnityEngine;

/// <summary>
/// ボス敵の弾発射を制御するクラス
/// </summary>
public class BossEnemyLauncher : MonoBehaviour
{
    // オブジェクトプール
    [SerializeField] private BossObjectPoolController objectPool;

    // 発射の間隔
    [SerializeField] private float shotInterval;

    // 一度に発射する弾の数
    [SerializeField] private int bulletsPerShot;

    void Start()
    {
        // EnemyShotを開始するための　StartCoroutine
        StartCoroutine(EnemyShot());
    }

    /// <summary>
    /// 弾の発射を制御するコルーチン
    /// </summary>
    IEnumerator EnemyShot()
    {
        while (true)
        {
            // bulletsPerShot 回だけ弾を発射
            for (int i = 0; i < bulletsPerShot; i++)
            {
                // オブジェクトプールの Launch 関数呼び出し
                objectPool.Launch(transform.position);
            }

            // 次の発射まで待機
            yield return new WaitForSeconds(shotInterval);
        }
    }
}