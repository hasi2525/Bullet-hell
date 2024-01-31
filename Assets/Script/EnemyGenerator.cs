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
    �@//��������
    void Spawn()
    {
        //��������ʒu�������_���ɂ���
        Vector3 spqwnPosition = new Vector3(
            Random.Range(minX,maxX),
            transform.position.y,
            transform.position.z);

            Instantiate(
            enemeyPrefab,�@//��������I�u�W�F�N�g
            spqwnPosition,�@�@�@�@ //��������ʒu
            transform.rotation);   //�����������
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
