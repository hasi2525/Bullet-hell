using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�̃I�u�W�F�N�g�v�[�����Ǘ�����N���X
/// </summary>
public class ObjectPoolController : MonoBehaviour
{
    // �e�̃v���t�@�u
    [SerializeField, Header("�e�̃v���n�u")]
    private BulletController bulletPrefab;
    // ��������e�̍ő吔
    [SerializeField, Header("�I�u�W�F�N�g�̍ő吔")]
    private int maxCount;
    // ���������e���i�[����Queue
    private Queue<BulletController> bulletQueue;
    // �e�̏��񐶐��ʒu
    private Vector2 initialPosition = new Vector2(0, 100f); 

    /// <summary>
    /// ����������
    /// </summary>
    private void Awake()
    {
        // Queue�̏�����
        bulletQueue = new Queue<BulletController>();

        // �e�𐶐�
        for (int i = 0; i < maxCount; i++)
        {
            // �e�̃I�u�W�F�N�g����
            BulletController tmpBullet = Instantiate(bulletPrefab, initialPosition, Quaternion.identity, transform);
            // Queue�ɒǉ�
            bulletQueue.Enqueue(tmpBullet);
            // �I�u�W�F�N�g���A�N�e�B�u�ɂ���
            tmpBullet.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// �e���v�[��������o���ĕ\�����鏈��
    /// </summary>
    /// <param name="_pos">�\������ʒu</param>
    /// <returns>���o�����e�̃R���g���[���[</returns>
    public BulletController Launch(Vector3 _pos)
    {
        // Queue����Ȃ�null
        if (bulletQueue.Count <= 0) return null;

        // Queue����e������o��
        BulletController tmpBullet = bulletQueue.Dequeue();

        // �I�u�W�F�N�g���A�N�e�B�u�łȂ��ꍇ�͍ė��p����
        if (!tmpBullet.gameObject.activeSelf)
        {
            tmpBullet.gameObject.SetActive(true);
        }

        // �e��\������
        tmpBullet.ShowInStage(_pos);

        // �Ăяo�����ɓn��
        return tmpBullet;
    }

    /// <summary>
    /// �e��������ăv�[���ɖ߂�����
    /// </summary>
    /// <param name="_bullet">�������e�̃R���g���[���[</param>
    public void Collect(BulletController _bullet)
    {
        // �e�̃Q�[���I�u�W�F�N�g���\��
        _bullet.gameObject.SetActive(false);
        // Queue�Ɋi�[
        bulletQueue.Enqueue(_bullet);
    }
}