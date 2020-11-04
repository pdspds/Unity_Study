using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour 상속
// 파일명과 동일한 클래스가 하나라도 있고
// : MonoBehaviour을 상속받아야 스크립트로서
// Object에 넣어주는 것이 가능하다.
public class PlayerScript_bk : MonoBehaviour
{

    // 생성자 혹은 Awake()
    /* 1 */
    PlayerScript_bk() {
        Debug.Log("생성자 함수");
    }
    // 시점 함수
    /* 2 */
    void Awake() {
        Debug.Log("Awake : 생성 함수");
    }

    /* 3 */
    void Start()
    {
        // 3
        // printf / system.out.print / console.log
        // System.Console.WriteLine("TESTWriteLing");
        // Log 정적 함수 static 함수
        // UnityEngine.Debug.Log
        Debug.Log("Start : 시작 함수");

        // <> 제네릭 함수
        //  Transform MyTrans = GetComponent<Transform>();
        //  if( MyTrans == null ) {
        //      Debug.Log("MyTrans null");
        //      return;
        //  }
        //  MyTrans.position = new Vector3(2, 1, 0);

         SpriteRenderer SR = GetComponent<SpriteRenderer>();
         if ( SR == null ) {
            Debug.Log("SR null");
            return;
         }
         // SpriteRenderer 색상 rgba 0 ~ 0.1
            //  SR.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
         // SpriteRenderer X 좌표(좌우)
            //  SR.flipX = true;

        Status STATUS = GetComponent<Status>();
            if( STATUS == null ) {
                Debug.Log("STATUS null");
                return;
            }
            Debug.Log(" 현재 공격력 STATUS : " + STATUS.AT);
            STATUS.AT = 5000;
            Debug.Log(" 변경된 공격력 STATUS : " + STATUS.AT);
        
    }

    void Update()
    {
        // 실행 해줄 수 있는 프레임을 최대 한도로
        // GetComponent<Transform>()를 자동으로
        // Input.GetKey();

        // transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime;
        this.transform.position += Vector3.right * Time.deltaTime;
        Debug.Log("update");
        // Debug.Log("update : " + Time.deltaTime);
        
    }
}

// class isNullCheck () {
//     if( gc == null ) {
//         Debug.Log()
//     }
// }
