using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        //���j�G�t�F�N�g��0.5�b��ɏ���
        GetComponent<Renderer>().enabled = false;
    }
}