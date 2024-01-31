//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ObjectPoolEnemy : MonoBehaviour
//{
//    [SerializeField, Header("敵のPrefab")]
//    EnemyController enemyPrefab;

//    [SerializeField, Header("オブジェクトの最大数")]
//    int maxCount;

//    Queue<EnemyController> enemyQueue;
//    Vector2 setPos = new Vector2(0, 100f);

//    private void Awake()
//    {
//        enemyQueue = new Queue<EnemyController>();

//        for (int i = 0; i < maxCount; i++)
//        {
//            EnemyController enemy = Instantiate(enemyPrefab, setPos, Quaternion.identity, transform);
//            enemy.gameObject.SetActive(false);
//            enemyQueue.Enqueue(enemy);
//        }
//    }

//    public EnemyController Launch(Vector2 _pos)
//    {
//        if (enemyQueue.Count <= 0) return null;

//        EnemyController enemy = enemyQueue.Dequeue();
//        enemy.gameObject.SetActive(true);
//        enemy.ShowInStage(_pos);
//        return enemy;
//    }

//    public void Collect(EnemyController _enemy)
//    {
//        _enemy.gameObject.SetActive(false);
//        enemyQueue.Enqueue(_enemy);
//    }
//}


