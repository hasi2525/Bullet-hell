using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    //撃破エフェクト
    [SerializeField]
    GameObject explosion;

    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Move();
        //敵のy軸が-3以下の位置にいったら破壊
        if (transform.position.y < -4.2f)
        {
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        // 敵のが下に移動する
        transform.position -= new Vector3(0, Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //点を加点しない
        if(collision.CompareTag("Player") == true)
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            gameController.GameOver();
        }
        //点を加点する
        else if (collision.CompareTag("Bullet") == true)
        {
            gameController.AddScore();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}