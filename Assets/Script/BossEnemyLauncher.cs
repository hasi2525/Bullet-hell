using System.Collections;
using UnityEngine;

/// <summary>
/// �{�X�G�̒e���˂𐧌䂷��N���X
/// </summary>
public class BossEnemyLauncher : MonoBehaviour
{
    // �I�u�W�F�N�g�v�[��
    [SerializeField] private BossObjectPoolController objectPool;

    // ���˂̊Ԋu
    [SerializeField] private float shotInterval;

    // ��x�ɔ��˂���e�̐�
    [SerializeField] private int bulletsPerShot;

    void Start()
    {
        // EnemyShot���J�n���邽�߂́@StartCoroutine
        StartCoroutine(EnemyShot());
    }

    /// <summary>
    /// �e�̔��˂𐧌䂷��R���[�`��
    /// </summary>
    IEnumerator EnemyShot()
    {
        while (true)
        {
            // bulletsPerShot �񂾂��e�𔭎�
            for (int i = 0; i < bulletsPerShot; i++)
            {
                // �I�u�W�F�N�g�v�[���� Launch �֐��Ăяo��
                objectPool.Launch(transform.position);
            }

            // ���̔��˂܂őҋ@
            yield return new WaitForSeconds(shotInterval);
        }
    }
}