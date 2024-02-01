using System.Collections;
using UnityEngine;


/// <summary>
/// �G�̒e�𐶐�����N���X
/// </summary>
public class EnemyLauncher : MonoBehaviour
{
    [SerializeField, Header("�e�̃I�u�W�F�N�g�v�[���R���g���[���[")]
    private ObjectPoolController objectPool;

    [SerializeField, Header("�e�̐����ʒu�I�t�Z�b�g")]
    private Vector3 launchOffset;

    [SerializeField, Header("���˂̊Ԋu")]
    private float interval;

    void Start()
    {
        //EnemyShot Coroutine���J�n
        StartCoroutine("EnemyShot");
    }

    /// <summary>
    /// �G�̒e�𔭎˂���R���[�`��
    /// </summary>
    IEnumerator EnemyShot()
    {
        //���˃��[�v
        while (true)
        {
            //�I�u�W�F�N�g�v�[����Launch�֐��Ăяo��
            objectPool.Launch(transform.position + launchOffset);
            // ���̔��˂܂őҋ@
            yield return new WaitForSeconds(interval);
        }
    }
}