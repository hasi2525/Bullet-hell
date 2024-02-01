using UnityEngine;

/// <summary>
/// �e�̐�����s���N���X
/// </summary>
public class BulletController : MonoBehaviour
{
    // �I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    private ObjectPoolController objectPool;

    // �e�̃X�s�[�h
    [SerializeField]
    private float bulletSpeed = 8f;

    // �e���v���C���[�̂�������
    [SerializeField]
    private bool isPlayerBullet = true;

    void Start()
    {
        // �I�u�W�F�N�g�v�[���擾
        objectPool = transform.parent.GetComponent<ObjectPoolController>();
    }

    void Update()
    {
        MoveBullet();
    }

    /// <summary>
    /// �e�̈ړ��𐧌�
    /// </summary>
    void MoveBullet()
    {
        // �v���C���[�̒e�͏����
        Vector2 movement = Vector2.up;

        if (!isPlayerBullet)
        {
            // �G�̒e�͉�����
            movement = Vector2.down;
        }
            transform.Translate(movement * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �w��Tag�ɂ���������e���
        if (collision.CompareTag("Player") == true || collision.CompareTag("Enemy") == true || (collision.CompareTag("Wall") == true))
        {
            HideFromStage();
        }
    }

    /// <summary>
    /// �e���w�肳�ꂽ���W�ɕ\��
    /// </summary>
    /// <param name="_pos">�\��������W</param>
    public void ShowInStage(Vector2 _pos)
    {
        // position��n���ꂽ���W�ɐݒ�
        transform.position = _pos;
    }

    /// <summary>
    /// �e����ʂ����\���ɂ��A�I�u�W�F�N�g�v�[���ɉ��
    /// </summary>
    private void HideFromStage()
    {
        // �I�u�W�F�N�g�v�[����Collect�֐����Ăяo�����g�����
        objectPool.Collect(this);
    }
}