using System.Collections;
using UnityEngine;

/// <summary>
/// オブジェクトを発射するクラス
/// </summary>
public class Launcher : MonoBehaviour
{
    [SerializeField, Header("弾のオブジェクトプールコントローラー")]
    private ObjectPoolController objectPool;

    [SerializeField, Header("弾の生成位置オフセット")]
    private Vector3 launchOffset;

    [SerializeField, Header("発射の間隔")]
    private float interval;
    void Start()
    {
        // 初期化などがあればここで行う
    }

    /// <summary>
    /// 弾を発射するコルーチン
    /// </summary>
    IEnumerator Shot()
    {
        // 発射ループ
        while (true)
        {
            // オブジェクトプールのLaunch関数呼び出し
            objectPool.Launch(transform.position + launchOffset);
            yield return new WaitForSeconds(interval);
        }
    }

    void Update()
    {
        // マウスの左ボタンが押されたら発射ループを開始
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Shot");
        }
        // マウスの左ボタンが離されたらループ停止
        else if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
        }
    }
}