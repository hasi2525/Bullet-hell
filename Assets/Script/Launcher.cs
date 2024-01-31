using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[��
    [SerializeField] 
    ObjectPoolController objectPool;
    //�e�����ʒu
    [SerializeField] Vector3 launchOffset;
    //���˂̊Ԋu
    [SerializeField] 
    float interval;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator _shot()
    {
        //���˃��[�v
        while (true)
        {
            //�I�u�W�F�N�g�v�[����Launch�֐��Ăяo��
            objectPool.Launch(transform.position + launchOffset);
            yield return new WaitForSeconds(interval);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //�}�E�X�������Ă���Ԃ͔��˃��[�v
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(_shot());
        }
        //�}�E�X�𗣂����烋�[�v�X�g�b�v
        else if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
        }
    }

}