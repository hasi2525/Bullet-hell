using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //�����L�[�œ��͂��ꂽ�����̒l���擾
        float x = Input.GetAxisRaw("Horizontal");

        //�����L�[�œ��͂��ꂽ�c���̒l���擾
        float y = Input.GetAxisRaw("Vertical");

        Move();
    }

    void Move()
    {
        //�����̒l��Ԃ�
        float x = Input.GetAxisRaw("Horizontal");

        //�c���̒l��Ԃ�
        float y = Input.GetAxisRaw("Vertical");

        //�ړ�����
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 7f;
        //�ړ��ł���͈͂�Mathf.Clamp�Ŕ͈͎w�肵�Đ���
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -8.31f, 8.31f),
            Mathf.Clamp(nextPosition.y, -4.19f, 4.19f),
            nextPosition.z
            );
        //���݈ʒu��nextPosition���{
        transform.position = nextPosition;
    }
}
