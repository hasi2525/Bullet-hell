using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    //撃破エフェクト
    [SerializeField]
    GameObject explosion;

    GameController gameController;
    [SerializeField]
    Slider slider;

    void Start()
    {
        slider.value = 10;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            slider.value -= 1;
            if (slider.value == 0)
            {
                Instantiate(explosion, collision.transform.position, transform.rotation);
                Destroy(gameObject);
                gameController.GameOver();
            }
        }
    }
}