using UnityEngine;

/// <summary>
/// プレイヤーの移動を制御するクラス
/// </summary>
public class PlayerController : MonoBehaviour
{
    private const float MinX = -8.31f;
    private const float MaxX = 8.31f;
    private const float MinY = -4.19f;
    private const float MaxY = 4.19f;
    private const float MoveSpeed = 7f;

    /// <summary>
    /// プレイヤーの移動処理を行います。
    /// </summary>
    void Update()
    {
        Move();
    }

    /// <summary>
    /// プレイヤーの移動を制御します。
    /// </summary>
    void Move()
    {
        // 方向キーで入力された横軸の値を取得
        float x = Input.GetAxisRaw("Horizontal");

        // 方向キーで入力された縦軸の値を取得
        float y = Input.GetAxisRaw("Vertical");

        // 移動制御
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * MoveSpeed;

        // 移動できる範囲をMathf.Clampで範囲指定して制御
        float clampedX = Mathf.Clamp(nextPosition.x, MinX, MaxX);
        float clampedY = Mathf.Clamp(nextPosition.y, MinY, MaxY);
        nextPosition = new Vector3(clampedX, clampedY, nextPosition.z);

        // 現在位置にnextPositionを設定
        transform.position = nextPosition;
    }
}