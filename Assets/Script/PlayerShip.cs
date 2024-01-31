using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
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

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.GameOver();
        }
    }
}