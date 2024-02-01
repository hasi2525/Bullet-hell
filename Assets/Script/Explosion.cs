using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        //爆破エフェクトを0.5秒後に消す
        GetComponent<Renderer>().enabled = false;
    }
}