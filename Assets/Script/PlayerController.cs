using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //方向キーで入力された横軸の値を取得
        float x = Input.GetAxisRaw("Horizontal");

        //方向キーで入力された縦軸の値を取得
        float y = Input.GetAxisRaw("Vertical");

        Move();
    }

    void Move()
    {
        //横軸の値を返す
        float x = Input.GetAxisRaw("Horizontal");

        //縦軸の値を返す
        float y = Input.GetAxisRaw("Vertical");

        //移動制御
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 7f;
        //移動できる範囲をMathf.Clampで範囲指定して制御
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -8.31f, 8.31f),
            Mathf.Clamp(nextPosition.y, -4.19f, 4.19f),
            nextPosition.z
            );
        //現在位置にnextPositionを＋
        transform.position = nextPosition;
    }
}
