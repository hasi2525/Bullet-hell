using UnityEngine;


/// <summary>
/// 敵の生成を制御するクラス
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Header("通常の敵のプレファブ")]
    private GameObject enemyPrefab;

    [SerializeField, Header("ボスの敵のプレファブ")]
    private GameObject bossEnemyPrefab;

    float minX = -8f;
    float maxX = 8f;
    void Start()
    {
        // 通常の敵を定期的に生成
        InvokeRepeating("SpawnEnemy", 1f,2f);
        // ボスの敵を生成
        InvokeRepeating("SpawnBoss", 10f, 20f);
    }
    /// <summary>
    /// 通常の敵を生成するメソッド
    /// </summary>
    void SpawnEnemy()
    {
        //生成する位置をランダムにする
        Vector3 spqwnPosition = new Vector3(
            Random.Range(minX,maxX),
            transform.position.y,
            transform.position.z);

        // 敵を生成
        Instantiate(
            enemyPrefab,　//生成するオブジェクト
            spqwnPosition,　　　　 //生成する位置
            transform.rotation);   //生成する向き
    }

    /// <summary>
    /// ボスの敵を生成するメソッド。
    /// </summary>

    void SpawnBoss()
    {
        Instantiate(bossEnemyPrefab, transform.position, transform.rotation);
    }
}
