using System.Collections;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[��
    [SerializeField] ObjectPoolController objectPool;
    //�e�����ʒu
    [SerializeField] Vector3 launchOffset;

    //���˂̊Ԋu
    [SerializeField] float interval;

    // Start is called before the first frame update
    void Start()
    {
        //Coroutine���J�n
        StartCoroutine("EnemyShot");
    }

    IEnumerator EnemyShot()
    {
        //���˃��[�v
        while (true)
        {
            //�I�u�W�F�N�g�v�[����Launch�֐��Ăяo��
            objectPool.Launch(transform.position + launchOffset);
            yield return new WaitForSeconds(interval);
        }
    }
}