using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�X�̒e���Ǘ�����I�u�W�F�N�g�v�[���̃N���X�B
/// </summary>
public class BossObjectPoolController : MonoBehaviour
{
    // �e�̃v���t�@�u
    [SerializeField, Header("�e�̃v���n�u")] private BossBulletController bulletPrefab;

    // ��������e�̍ő吔
    [SerializeField, Header("�I�u�W�F�N�g�̍ő吔")] private int maxBulletCount;

    // ���������e���i�[����Queue
    private Queue<BossBulletController> bulletQueue;

    // ���񐶐����̃|�W�V����
    private Vector2 spawnPosition = new Vector2(0, 100f);

    private void Awake()
    {
        // Queue�̏�����
        bulletQueue = new Queue<BossBulletController>();

        // �e�𐶐�
        for (int i = 0; i < maxBulletCount; i++)
        {
            // �e�̃I�u�W�F�N�g����
            BossBulletController tmpBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity, transform);

            // Queue�ɒǉ�
            bulletQueue.Enqueue(tmpBullet);
        }
    }

    /// <summary>
    /// �e�𔭎˂��郁�\�b�h�B
    /// </summary>
    /// <param name="_pos">���˂���ʒu</param>
    /// <returns>���˂��ꂽ�e</returns>
    public BossBulletController Launch(Vector2 _pos)
    {
        // Queue����Ȃ�null
        if (bulletQueue.Count <= 0) return null;

        // Queue����e������o��
        BossBulletController tmpBullet = bulletQueue.Dequeue();

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
    /// �e�̉���������s�����\�b�h�B
    /// </summary>
    /// <param name="_bullet">�������e</param>
    public void Collect(BossBulletController _bullet)
    {
        // �e�̃Q�[���I�u�W�F�N�g���\��
        _bullet.gameObject.SetActive(false);

        // Queue�Ɋi�[
        bulletQueue.Enqueue(_bullet);
    }
}