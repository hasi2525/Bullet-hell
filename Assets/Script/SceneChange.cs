using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    GameObject TitleText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputForReloadScene();
    }
    void HandleInputForReloadScene()
    {
        if (Input.anyKey)
        {
            ReloadMainScene();
        }
    }
    void ReloadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
