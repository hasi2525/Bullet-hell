using System.Collections;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    //オブジェクトプール
    [SerializeField] ObjectPoolController objectPool;
    //弾生成位置
    [SerializeField] Vector3 launchOffset;

    //発射の間隔
    [SerializeField] float interval;

    // Start is called before the first frame update
    void Start()
    {
        //Coroutineを開始
        StartCoroutine("EnemyShot");
    }

    IEnumerator EnemyShot()
    {
        //発射ループ
        while (true)
        {
            //オブジェクトプールのLaunch関数呼び出し
            objectPool.Launch(transform.position + launchOffset);
            yield return new WaitForSeconds(interval);
        }
    }
}