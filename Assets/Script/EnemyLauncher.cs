using System.Collections;
using UnityEngine;


/// <summary>
/// 敵の弾を生成するクラス
/// </summary>
public class EnemyLauncher : MonoBehaviour
{
    [SerializeField, Header("弾のオブジェクトプールコントローラー")]
    private ObjectPoolController objectPool;

    [SerializeField, Header("弾の生成位置オフセット")]
    private Vector3 launchOffset;

    [SerializeField, Header("発射の間隔")]
    private float interval;

    void Start()
    {
        //EnemyShot Coroutineを開始
        StartCoroutine("EnemyShot");
    }

    /// <summary>
    /// 敵の弾を発射するコルーチン
    /// </summary>
    IEnumerator EnemyShot()
    {
        //発射ループ
        while (true)
        {
            //オブジェクトプールのLaunch関数呼び出し
            objectPool.Launch(transform.position + launchOffset);
            // 次の発射まで待機
            yield return new WaitForSeconds(interval);
        }
    }
}