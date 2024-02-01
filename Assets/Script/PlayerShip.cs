using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̋@�̂𐧌䂷��N���X
/// </summary>
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private GameObject explosion; // ���j�G�t�F�N�g
    private GameController gameController; // �Q�[���R���g���[���[
    [SerializeField] private Slider slider; // �v���C���[�̗̑͂�\������X���C�_�[

    private const float InitialHealth = 10f; // �����̗�
    private const float Damage = 1f; // �_���[�W��

    /// <summary>
    /// ����������
    /// </summary>
    void Start()
    {
        slider.value = InitialHealth;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    /// <summary>
    /// �Փˎ��̏���
    /// </summary>
    /// <param name="collision">�Փ˂����R���C�_�[</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            // �_���[�W���󂯂�
            TakeDamage();
        }
    }

    /// <summary>
    /// �_���[�W���󂯂鏈��
    /// </summary>
    private void TakeDamage()
    {
        slider.value -= Damage;

        // �̗͂�0�ȉ��ɂȂ����猂�j���������s
        if (slider.value <= 0)
        {
            slider.value = 0;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.GameOver();
        }
    }
}