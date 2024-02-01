using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���J�ڂ𐧌䂷��N���X
/// </summary>
public class SceneChange : MonoBehaviour
{
    [SerializeField] private GameObject titleText; // �^�C�g���e�L�X�g

    /// <summary>
    /// ����������
    /// </summary>
    void Start()
    {
        // �������������K�v�Ȃ炱���ɋL�q
    }

    /// <summary>
    /// �t���[�����Ƃ̍X�V����
    /// </summary>
    void Update()
    {
        // �L�[���͂��Ď����ă��C���V�[���������[�h
        HandleInputForReloadScene();
    }

    /// <summary>
    /// �L�[���͂Ń��C���V�[���������[�h
    /// </summary>
    void HandleInputForReloadScene()
    {
        if (Input.anyKey)
        {
            ReloadMainScene();
        }
    }

    /// <summary>
    /// ���C���V�[���������[�h
    /// </summary>
    void ReloadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
