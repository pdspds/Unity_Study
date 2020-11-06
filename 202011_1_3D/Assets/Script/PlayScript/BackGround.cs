using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private float Inter;
    bool m_IsNext = false;
    
    [SerializeField]
    int Sort = 0;
    void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        SR.sortingOrder = Sort;
    }

    // Update is called once per frame
    void Update()
    {
        // 생성
        if(m_IsNext == false &&  PlayerScript.PlayerPos.x > transform.position.x) {
            GameObject NextBG = Instantiate<GameObject>(gameObject);
            NextBG.name = gameObject.name;
            Vector3 Pos = transform.position;
            Pos.x += Inter;
            NextBG.transform.position = Pos;
            m_IsNext = true;
        }

        // 삭제
        if(Inter < PlayerScript.PlayerPos.x - transform.position.x) {
            Destroy(gameObject); 
        }
    }

    // private void LateUpdate() {
    //     if(PlayerScript.IsDeath == true) {
    //         Destroy(gameObject);
    //     }
    // }
}
