using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���̐i�s��v���C���[�̃X�R�A���Ǘ�����N���X
/// </summary>
public class GameController : MonoBehaviour
{
    //�Q�[���I�[�o�[�e�L�X�g
    [SerializeField]
    GameObject gameOverText;

    //�Q�[���N���A�e�L�X�g
    [SerializeField]
    GameObject gameClearText;

    //�X�R�A�e�L�X�g
    [SerializeField]
    Text scoreText;

    //�X�R�A
    private int score = 0;
    //�G��@������̃X�R�A
    private const int PointsPerEnemy = 100;
    //�Q�[���N���A�ڕW�|�C���g
    private const int TargetScore = 3000;

    void Start()
    {
        // �Q�[���I�[�o�[�ƃQ�[���N���A�̕\����������
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);
    }

    void Update()
    {
        // �Q�[���I�[�o�[�܂��̓Q�[���N���A���̓��͏���
        if (gameOverText.activeSelf || gameClearText.activeSelf)
        {
            HandleInputForReloadScene();
        }
        // �X�R�A���ڕW�ɒB������Q�[���N���A�������Ă�
        else if (score >= TargetScore)
        {
            GameClear();
        }
    }

    /// <summary>
    /// ���͂��������ăV�[���������[�h
    /// </summary>
    private void HandleInputForReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetTimeScale(); // ���Ԃ����Ƃɖ߂�
            ReloadMainScene();
        }
    }

    /// <summary>
    /// ���C���V�[���������[�h
    /// </summary>
    private void ReloadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// �X�R�A�����Z���A�\�����X�V
    /// </summary>
    public void AddScore()
    {
        score += PointsPerEnemy;
        UpdateScoreText();
    }

    /// <summary>
    /// �Q�[���I�[�o�[�̕\�����s���A���Ԃ��~
    /// </summary>
    public void GameOver()
    {
        gameOverText.SetActive(true);
        StopTime();
    }

    /// <summary>
    /// �Q�[���N���A�̕\�����s���A���Ԃ��~
    /// </summary>
    public void GameClear()
    {
        gameClearText.SetActive(true);
        StopTime();
    }

    /// <summary>
    /// ���Ԃ��~
    /// </summary>
    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// ���Ԃ����Ƃɖ߂�
    /// </summary>
    private void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// �X�R�A�\�����X�V
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}