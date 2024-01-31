using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //オブジェクトプール
    [SerializeField] 
    ObjectPoolController objectPool;
    //弾生成位置
    [SerializeField] Vector3 launchOffset;
    //発射の間隔
    [SerializeField] 
    float interval;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator _shot()
    {
        //発射ループ
        while (true)
        {
            //オブジェクトプールのLaunch関数呼び出し
            objectPool.Launch(transform.position + launchOffset);
            yield return new WaitForSeconds(interval);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //マウスを押している間は発射ループ
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(_shot());
        }
        //マウスを離したらループストップ
        else if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
        }
    }

}