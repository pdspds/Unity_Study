using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBack : MonoBehaviour
{
    [SerializeField]
    private float DeathLen = 0f;

    [SerializeField]
    private float CreateLen = 0f;

    [SerializeField]
    private float CreateInter = 0f;


    private bool m_IsCreate = false;

    [SerializeField]
    private int Order;

    private float Speed = 10.0f; 
    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        if (SR == null) {
            Debug.LogError("SpriteRenderer Error");
        }

        SR.sortingOrder = Order;
        
    }

    // Update is called once per frame
    void Update()
    {
        // 월드 포지션
        // 부모가 있다면 부모위치 + 자신 위치
        transform.position += Vector3.left * Time.deltaTime * Speed;

        if (m_IsCreate == false && (CreateLen > transform.position.x)) {
            GameObject obj = LogicValue.NameInst(gameObject);
            obj.transform.position += (Vector3.right * CreateInter);
            m_IsCreate = true;
        }

        if (DeathLen > transform.position.x) {
            Destroy(gameObject);
        }
    }
}
