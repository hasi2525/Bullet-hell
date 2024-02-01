using UnityEngine;

/// <summary>
/// �v���C���[�̈ړ��𐧌䂷��N���X
/// </summary>
public class PlayerController : MonoBehaviour
{
    private const float MinX = -8.31f;
    private const float MaxX = 8.31f;
    private const float MinY = -4.19f;
    private const float MaxY = 4.19f;
    private const float MoveSpeed = 7f;

    /// <summary>
    /// �v���C���[�̈ړ��������s���܂��B
    /// </summary>
    void Update()
    {
        Move();
    }

    /// <summary>
    /// �v���C���[�̈ړ��𐧌䂵�܂��B
    /// </summary>
    void Move()
    {
        // �����L�[�œ��͂��ꂽ�����̒l���擾
        float x = Input.GetAxisRaw("Horizontal");

        // �����L�[�œ��͂��ꂽ�c���̒l���擾
        float y = Input.GetAxisRaw("Vertical");

        // �ړ�����
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * MoveSpeed;

        // �ړ��ł���͈͂�Mathf.Clamp�Ŕ͈͎w�肵�Đ���
        float clampedX = Mathf.Clamp(nextPosition.x, MinX, MaxX);
        float clampedY = Mathf.Clamp(nextPosition.y, MinY, MaxY);
        nextPosition = new Vector3(clampedX, clampedY, nextPosition.z);

        // ���݈ʒu��nextPosition��ݒ�
        transform.position = nextPosition;
    }
}