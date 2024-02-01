using UnityEngine;

/// <summary>
/// �{�X�����˂��闆���e�𐧌䂷��N���X
/// </summary>
public class BossBulletController : MonoBehaviour
{
    private BossObjectPoolController objectPool;

    [SerializeField, Header("�����e�̈ړ����x")] private float bulletSpeed = 8f;
    [SerializeField, Header("�����e�̊p���x")] private float angularSpeed = 2f;

    private float rotationAngle = 0f;

    void Start()
    {
        // �I�u�W�F�N�g�v�[���R���g���[���[���擾
        objectPool = transform.parent.GetComponent<BossObjectPoolController>();
        // �Q�[���I�u�W�F�N�g���A�N�e�B�u�ɂ���
        gameObject.SetActive(false);
    }

    void Update()
    {
        MoveBullet();
    }

    /// <summary>
    /// �����e���ړ������郁�\�b�h
    /// </summary>
    void MoveBullet()
    {
        // �����e�̈ړ��������v�Z
        Vector2 movement = CalculateSpiralDirection();

        // World���W�n�ňړ�
        transform.Translate(movement * bulletSpeed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// �����e�̈ړ��������v�Z���郁�\�b�h
    /// </summary>
    /// <returns>�����e�̈ړ�����</returns>
    Vector2 CalculateSpiralDirection()
    {
        // �����e�̊p�x���X�V
        rotationAngle += angularSpeed * Time.deltaTime;

        // �����e�̕������v�Z
        Vector2 spiralDirection = new Vector2(Mathf.Cos(rotationAngle), Mathf.Sin(rotationAngle));

        return spiralDirection;
    }

    /// <summary>
    /// Collider2D�Ƃ̏Փ˔�����������郁�\�b�h
    /// </summary>
    /// <param name="collision">�Փ˂���Collider2D</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �w���Tag�ɓ���������e�����
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            HideFromStage();
        }
    }

    /// <summary>
    /// �w��ʒu�ɗ����e��\�����郁�\�b�h
    /// </summary>
    /// <param name="_pos">�\������ʒu</param>
    public void ShowInStage(Vector2 _pos)
    {
        // �ʒu��ݒ�
        transform.position = _pos;
        // �����e�̊p�x�������_���ɐݒ�
        rotationAngle = Random.Range(0f, 2f * Mathf.PI);
    }

    /// <summary>
    /// �����e����ʊO�ɉB�����\�b�h
    /// </summary>
    private void HideFromStage()
    {
        // �I�u�W�F�N�g�v�[����Collect�֐����Ăяo���A���g�����
        objectPool.Collect(this);
    }
}
