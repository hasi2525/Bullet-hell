using UnityEngine;

/// <summary>
/// ボスが発射する螺旋弾を制御するクラス
/// </summary>
public class BossBulletController : MonoBehaviour
{
    private BossObjectPoolController objectPool;

    [SerializeField, Header("螺旋弾の移動速度")] private float bulletSpeed = 8f;
    [SerializeField, Header("螺旋弾の角速度")] private float angularSpeed = 2f;

    private float rotationAngle = 0f;

    void Start()
    {
        // オブジェクトプールコントローラーを取得
        objectPool = transform.parent.GetComponent<BossObjectPoolController>();
        // ゲームオブジェクトを非アクティブにする
        gameObject.SetActive(false);
    }

    void Update()
    {
        MoveBullet();
    }

    /// <summary>
    /// 螺旋弾を移動させるメソッド
    /// </summary>
    void MoveBullet()
    {
        // 螺旋弾の移動方向を計算
        Vector2 movement = CalculateSpiralDirection();

        // World座標系で移動
        transform.Translate(movement * bulletSpeed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// 螺旋弾の移動方向を計算するメソッド
    /// </summary>
    /// <returns>螺旋弾の移動方向</returns>
    Vector2 CalculateSpiralDirection()
    {
        // 螺旋弾の角度を更新
        rotationAngle += angularSpeed * Time.deltaTime;

        // 螺旋弾の方向を計算
        Vector2 spiralDirection = new Vector2(Mathf.Cos(rotationAngle), Mathf.Sin(rotationAngle));

        return spiralDirection;
    }

    /// <summary>
    /// Collider2Dとの衝突判定を処理するメソッド
    /// </summary>
    /// <param name="collision">衝突したCollider2D</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 指定のTagに当たったら弾を回収
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            HideFromStage();
        }
    }

    /// <summary>
    /// 指定位置に螺旋弾を表示するメソッド
    /// </summary>
    /// <param name="_pos">表示する位置</param>
    public void ShowInStage(Vector2 _pos)
    {
        // 位置を設定
        transform.position = _pos;
        // 螺旋弾の角度をランダムに設定
        rotationAngle = Random.Range(0f, 2f * Mathf.PI);
    }

    /// <summary>
    /// 螺旋弾を画面外に隠すメソッド
    /// </summary>
    private void HideFromStage()
    {
        // オブジェクトプールのCollect関数を呼び出し、自身を回収
        objectPool.Collect(this);
    }
}
