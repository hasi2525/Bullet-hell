using System.Collections;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�𔭎˂���N���X
/// </summary>
public class Launcher : MonoBehaviour
{
    [SerializeField, Header("�e�̃I�u�W�F�N�g�v�[���R���g���[���[")]
    private ObjectPoolController objectPool;

    [SerializeField, Header("�e�̐����ʒu�I�t�Z�b�g")]
    private Vector3 launchOffset;

    [SerializeField, Header("���˂̊Ԋu")]
    private float interval;
    void Start()
    {
        // �������Ȃǂ�����΂����ōs��
    }

    /// <summary>
    /// �e�𔭎˂���R���[�`��
    /// </summary>
    IEnumerator Shot()
    {
        // ���˃��[�v
        while (true)
        {
            // �I�u�W�F�N�g�v�[����Launch�֐��Ăяo��
            objectPool.Launch(transform.position + launchOffset);
            yield return new WaitForSeconds(interval);
        }
    }

    void Update()
    {
        // �}�E�X�̍��{�^���������ꂽ�甭�˃��[�v���J�n
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Shot");
        }
        // �}�E�X�̍��{�^���������ꂽ�烋�[�v��~
        else if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
        }
    }
}