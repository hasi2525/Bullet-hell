using System.Collections.Generic;
using UnityEngine;
public class ObjectPoolController : MonoBehaviour
{
    //弾のプレファブ
    [SerializeField,Header("弾のプレハブ")] BulletController Bullet;
    //生成する数
    [SerializeField,Header("オブジェクトの最大数")] int maxCount;
    //生成した弾を格納するQueue
    Queue<BulletController> bulletQueue;
    //初回生成時のポジション
    Vector2 setPos = new Vector2(0, 100f);

    private void Awake()
    {
        //Queueの初期化
        bulletQueue = new Queue<BulletController>();

        //弾を生成
        for (int i = 0;i < maxCount; i++)
        {
            //弾のオブジェクト生成
            BulletController tmpBullet = Instantiate(Bullet, setPos, Quaternion.identity, transform);
            //Queueに追加
            bulletQueue.Enqueue(tmpBullet);
        }
    }
    //弾を貸し出す処理
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
    //弾の回収処理
    public void Collect(BulletController _bullet)
    {
        //弾のゲームオブジェクトを非表示
        _bullet.gameObject.SetActive(false);
        //Queueに格納
        bulletQueue.Enqueue(_bullet);
    }
}