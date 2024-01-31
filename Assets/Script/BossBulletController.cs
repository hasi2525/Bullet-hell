using UnityEngine;

public class BossBulletController : MonoBehaviour
{
    private BossObjectPoolController objectPool;

    [SerializeField] private float bulletSpeed = 8f;
    [SerializeField] private float angularSpeed = 2f;

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

    void MoveBullet()
    {
        // 螺旋弾の移動方向を計算
        Vector2 movement = CalculateSpiralDirection();

        // World座標系で移動
        transform.Translate(movement * bulletSpeed * Time.deltaTime, Space.World);
    }

    Vector2 CalculateSpiralDirection()
    {
        // 螺旋弾の角度を更新
        rotationAngle += angularSpeed * Time.deltaTime;

        // 螺旋弾の方向を計算
        Vector2 spiralDirection = new Vector2(Mathf.Cos(rotationAngle), Mathf.Sin(rotationAngle));

        return spiralDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 指定のTagに当たったら弾を回収
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            HideFromStage();
        }
    }

    public void ShowInStage(Vector2 _pos)
    {
        // 位置を設定
        transform.position = _pos;
        // 螺旋弾の角度をランダムに設定
        rotationAngle = Random.Range(0f, 2f * Mathf.PI);
    }

    private void HideFromStage()
    {
        // オブジェクトプールのCollect関数を呼び出し、自身を回収
        objectPool.Collect(this);
    }
}
