using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移を制御するクラス
/// </summary>
public class SceneChange : MonoBehaviour
{
    [SerializeField] private GameObject titleText; // タイトルテキスト

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        // 何か初期化が必要ならここに記述
    }

    /// <summary>
    /// フレームごとの更新処理
    /// </summary>
    void Update()
    {
        // キー入力を監視してメインシーンをリロード
        HandleInputForReloadScene();
    }

    /// <summary>
    /// キー入力でメインシーンをリロード
    /// </summary>
    void HandleInputForReloadScene()
    {
        if (Input.anyKey)
        {
            ReloadMainScene();
        }
    }

    /// <summary>
    /// メインシーンをリロード
    /// </summary>
    void ReloadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
