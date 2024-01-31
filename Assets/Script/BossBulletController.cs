using UnityEngine;

public class BossBulletController : MonoBehaviour
{
    private BossObjectPoolController objectPool;

    [SerializeField] private float bulletSpeed = 8f;
    [SerializeField] private float angularSpeed = 2f;

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

    void MoveBullet()
    {
        // �����e�̈ړ��������v�Z
        Vector2 movement = CalculateSpiralDirection();

        // World���W�n�ňړ�
        transform.Translate(movement * bulletSpeed * Time.deltaTime, Space.World);
    }

    Vector2 CalculateSpiralDirection()
    {
        // �����e�̊p�x���X�V
        rotationAngle += angularSpeed * Time.deltaTime;

        // �����e�̕������v�Z
        Vector2 spiralDirection = new Vector2(Mathf.Cos(rotationAngle), Mathf.Sin(rotationAngle));

        return spiralDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �w���Tag�ɓ���������e�����
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            HideFromStage();
        }
    }

    public void ShowInStage(Vector2 _pos)
    {
        // �ʒu��ݒ�
        transform.position = _pos;
        // �����e�̊p�x�������_���ɐݒ�
        rotationAngle = Random.Range(0f, 2f * Mathf.PI);
    }

    private void HideFromStage()
    {
        // �I�u�W�F�N�g�v�[����Collect�֐����Ăяo���A���g�����
        objectPool.Collect(this);
    }
}
