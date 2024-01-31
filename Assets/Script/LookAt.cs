using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    public GameObject PlayerTaget;
    void Start()
    {
        PlayerTaget = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(PlayerTaget.transform.position);
        print(PlayerTaget.transform.position);
    }
}
