using UnityEngine;


/// <summary>
/// �G�̐����𐧌䂷��N���X
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Header("�ʏ�̓G�̃v���t�@�u")]
    private GameObject enemyPrefab;

    [SerializeField, Header("�{�X�̓G�̃v���t�@�u")]
    private GameObject bossEnemyPrefab;

    float minX = -8f;
    float maxX = 8f;
    void Start()
    {
        // �ʏ�̓G�����I�ɐ���
        InvokeRepeating("SpawnEnemy", 1f,2f);
        // �{�X�̓G�𐶐�
        InvokeRepeating("SpawnBoss", 10f, 20f);
    }
    /// <summary>
    /// �ʏ�̓G�𐶐����郁�\�b�h
    /// </summary>
    void SpawnEnemy()
    {
        //��������ʒu�������_���ɂ���
        Vector3 spqwnPosition = new Vector3(
            Random.Range(minX,maxX),
            transform.position.y,
            transform.position.z);

        // �G�𐶐�
        Instantiate(
            enemyPrefab,�@//��������I�u�W�F�N�g
            spqwnPosition,�@�@�@�@ //��������ʒu
            transform.rotation);   //�����������
    }

    /// <summary>
    /// �{�X�̓G�𐶐����郁�\�b�h�B
    /// </summary>

    void SpawnBoss()
    {
        Instantiate(bossEnemyPrefab, transform.position, transform.rotation);
    }
}
