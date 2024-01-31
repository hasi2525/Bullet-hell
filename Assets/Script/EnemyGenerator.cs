using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject enemeyPrefab;
    [SerializeField]
    GameObject BossEnemyPrefab;

    float minX = -8f;
    float maxX = 8f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",1f,2f);
        Invoke("BossSpawn", 1f);
    }
    　//生成する
    void Spawn()
    {
        //生成する位置をランダムにする
        Vector3 spqwnPosition = new Vector3(
            Random.Range(minX,maxX),
            transform.position.y,
            transform.position.z);

            Instantiate(
            enemeyPrefab,　//生成するオブジェクト
            spqwnPosition,　　　　 //生成する位置
            transform.rotation);   //生成する向き
    }
    void BossSpawn()
    {
        Instantiate(BossEnemyPrefab, transform.position, transform.rotation);
        //CancelInvoke();
    }
    void Update()
    {
        
    }
}
