using System.Collections;
using UnityEngine;

/// <summary>
/// �{�X�̋@�̂𐧌䂷��N���X�B
/// </summary>
public class BossShip : MonoBehaviour
{
    // ���j�G�t�F�N�g
    public GameObject explosion;

    // GameController��AddScore���\�b�h���g�p���邽�߂̓��ꕨ
    GameController gameController;

    // �{�X�̗̑�
    [SerializeField, Tooltip("�{�X�̗̑�")] private int maxHp = 20;
    private int currentHp;

    // ����̈ʒu����̖ڕW�ʒu
    [SerializeField, Tooltip("�{�X���ړ�����ڕW��Y���W")] private float targetYPosition = 3.5f;

    void Start()
    {
        // GameController���������Ď擾
        gameController = GameObject.FindObjectOfType<GameController>();

        // ������
        currentHp = maxHp;

        // CPU�R���[�`�����J�n
        StartCoroutine("CPU");
    }

    /// <summary>
    /// �{�X�̈ړ��𐧌䂷��R���[�`���B
    /// </summary>
    IEnumerator CPU()
    {
        // ����̈ʒu���ゾ������
        while (transform.position.y > targetYPosition)
        {
            // ��Ɉړ�
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null; // 1�t���[��(0.02�b)�҂� 
        }
    }

    /// <summary>
    /// Boss�̓����蔻����������郁�\�b�h�B
    /// </summary>
    /// <param name="collision">�Փ˂����R���C�_�[</param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Player��Boss���ڐG������
        if (collision.CompareTag("Player"))
        {
            // �j�󂷂鎞�ɔ��j�G�t�F�N�g����
            Instantiate(explosion, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);
            gameController.GameOver();
        }
        // Bullet��Boss���ڐG������
        else if (collision.CompareTag("Bullet"))
        {
            // Boss��Hp������
            currentHp--;

            // Hp��0�ȉ��ɂȂ�����
            if (currentHp <= 0)
            {
                // �X�R�A��ǉ�
                gameController.AddScore();

                // Enemy�̋@�̂�j��
                Destroy(gameObject);

                // �j�󂷂鎞�ɔ��j�G�t�F�N�g����
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
    }
}
