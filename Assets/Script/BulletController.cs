using UnityEngine;

public class BulletController : MonoBehaviour
{
    // オブジェクトプール用コントローラー格納用変数宣言
    private ObjectPoolController objectPool;

    // 弾のスピード
    [SerializeField]
    private float bulletSpeed = 8f;

    // 弾がプレイヤーのだったら
    [SerializeField]
    private bool isPlayerBullet = true;

    void Start()
    {
        // オブジェクトプール取得
        objectPool = transform.parent.GetComponent<ObjectPoolController>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        // プレイヤーの弾は上向き
        Vector2 movement = Vector2.up;

        if (!isPlayerBullet)
        {
            // 敵の弾は下向き
            movement = Vector2.down;
        }
            transform.Translate(movement * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 指定Tagにあたったら弾回収
        if (collision.CompareTag("Player") == true || collision.CompareTag("Enemy") == true || (collision.CompareTag("Wall") == true))
        {
            HideFromStage();
        }
    }
    public void ShowInStage(Vector2 _pos)
    {
        // positionを渡された座標に設定
        transform.position = _pos;
    }

    private void HideFromStage()
    {
        // オブジェクトプールのCollect関数を呼び出し自身を回収
        objectPool.Collect(this);
    }
}