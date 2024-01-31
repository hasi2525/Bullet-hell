using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスの弾を管理するオブジェクトプールのクラス。
/// </summary>
public class BossObjectPoolController : MonoBehaviour
{
    // 弾のプレファブ
    [SerializeField, Header("弾のプレハブ")] private BossBulletController bulletPrefab;

    // 生成する弾の最大数
    [SerializeField, Header("オブジェクトの最大数")] private int maxBulletCount;

    // 生成した弾を格納するQueue
    private Queue<BossBulletController> bulletQueue;

    // 初回生成時のポジション
    private Vector2 spawnPosition = new Vector2(0, 100f);

    private void Awake()
    {
        // Queueの初期化
        bulletQueue = new Queue<BossBulletController>();

        // 弾を生成
        for (int i = 0; i < maxBulletCount; i++)
        {
            // 弾のオブジェクト生成
            BossBulletController tmpBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity, transform);

            // Queueに追加
            bulletQueue.Enqueue(tmpBullet);
        }
    }

    /// <summary>
    /// 弾を発射するメソッド。
    /// </summary>
    /// <param name="_pos">発射する位置</param>
    /// <returns>発射された弾</returns>
    public BossBulletController Launch(Vector2 _pos)
    {
        // Queueが空ならnull
        if (bulletQueue.Count <= 0) return null;

        // Queueから弾を一つ取り出す
        BossBulletController tmpBullet = bulletQueue.Dequeue();

        // オブジェクトがアクティブでない場合は再利用する
        if (!tmpBullet.gameObject.activeSelf)
        {
            tmpBullet.gameObject.SetActive(true);
        }

        // 弾を表示する
        tmpBullet.ShowInStage(_pos);

        // 呼び出し元に渡す
        return tmpBullet;
    }

    /// <summary>
    /// 弾の回収処理を行うメソッド。
    /// </summary>
    /// <param name="_bullet">回収する弾</param>
    public void Collect(BossBulletController _bullet)
    {
        // 弾のゲームオブジェクトを非表示
        _bullet.gameObject.SetActive(false);

        // Queueに格納
        bulletQueue.Enqueue(_bullet);
    }
}