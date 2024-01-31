using System.Collections.Generic;
using UnityEngine;
public class ObjectPoolController : MonoBehaviour
{
    //�e�̃v���t�@�u
    [SerializeField,Header("�e�̃v���n�u")] BulletController Bullet;
    //�������鐔
    [SerializeField,Header("�I�u�W�F�N�g�̍ő吔")] int maxCount;
    //���������e���i�[����Queue
    Queue<BulletController> bulletQueue;
    //���񐶐����̃|�W�V����
    Vector2 setPos = new Vector2(0, 100f);

    private void Awake()
    {
        //Queue�̏�����
        bulletQueue = new Queue<BulletController>();

        //�e�𐶐�
        for (int i = 0;i < maxCount; i++)
        {
            //�e�̃I�u�W�F�N�g����
            BulletController tmpBullet = Instantiate(Bullet, setPos, Quaternion.identity, transform);
            //Queue�ɒǉ�
            bulletQueue.Enqueue(tmpBullet);
        }
    }
    //�e��݂��o������
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
    //�e�̉������
    public void Collect(BulletController _bullet)
    {
        //�e�̃Q�[���I�u�W�F�N�g���\��
        _bullet.gameObject.SetActive(false);
        //Queue�Ɋi�[
        bulletQueue.Enqueue(_bullet);
    }
}