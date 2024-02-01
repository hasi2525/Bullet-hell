using UnityEngine;


/// <summary>
/// �G�̑D�𐧌䂷��N���X
/// </summary>
public class EnemyShip : MonoBehaviour
{
    [SerializeField, Header("���j�G�t�F�N�g�̃v���t�@�u")]
    private GameObject explosion;

    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Move();
        //�G��y����-3�ȉ��̈ʒu�ɂ�������j��
        if (transform.position.y < -4.2f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �G�̈ړ����s���܂�
    /// </summary>
    public void Move()
    {
        // �G�̂����Ɉړ�����
        transform.position -= new Vector3(0, Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �_�����_���Ȃ�
        if(collision.CompareTag("Player") == true)
        {
            Instantiate(explosion, collision.transform.position, transform.rotation);
            gameController.GameOver();
        }
        // �_�����_����
        else if (collision.CompareTag("Bullet") == true)
        {
            gameController.AddScore();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}