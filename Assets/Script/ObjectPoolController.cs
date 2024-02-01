using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾のオブジェクトプールを管理するクラス
/// </summary>
public class ObjectPoolController : MonoBehaviour
{
    // 弾のプレファブ
    [SerializeField, Header("弾のプレハブ")]
    private BulletController bulletPrefab;
    // 生成する弾の最大数
    [SerializeField, Header("オブジェクトの最大数")]
    private int maxCount;
    // 生成した弾を格納するQueue
    private Queue<BulletController> bulletQueue;
    // 弾の初回生成位置
    private Vector2 initialPosition = new Vector2(0, 100f); 

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Awake()
    {
        // Queueの初期化
        bulletQueue = new Queue<BulletController>();

        // 弾を生成
        for (int i = 0; i < maxCount; i++)
        {
            // 弾のオブジェクト生成
            BulletController tmpBullet = Instantiate(bulletPrefab, initialPosition, Quaternion.identity, transform);
            // Queueに追加
            bulletQueue.Enqueue(tmpBullet);
            // オブジェクトを非アクティブにする
            tmpBullet.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 弾をプールから取り出して表示する処理
    /// </summary>
    /// <param name="_pos">表示する位置</param>
    /// <returns>取り出した弾のコントローラー</returns>
    public BulletController Launch(Vector3 _pos)
    {
        // Queueが空ならnull
        if (bulletQueue.Count <= 0) return null;

        // Queueから弾を一つ取り出す
        BulletController tmpBullet = bulletQueue.Dequeue();

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
    /// 弾を回収してプールに戻す処理
    /// </summary>
    /// <param name="_bullet">回収する弾のコントローラー</param>
    public void Collect(BulletController _bullet)
    {
        // 弾のゲームオブジェクトを非表示
        _bullet.gameObject.SetActive(false);
        // Queueに格納
        bulletQueue.Enqueue(_bullet);
    }
}