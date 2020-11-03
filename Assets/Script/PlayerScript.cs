using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    // 플레이어는 단일
    private static Vector3 m_PlayerPos;
    public static Vector3 PlayerPos {
        get {
            return m_PlayerPos;
        }
    }




    // 떨어진 순간
    private void OnCollisionExit(Collision collision) {

    }

    // 지속적으로 충돌하는 순간
    private void OnCollisionStay(Collision collision) {
        
    }

    // 최초 충돌하는 순간
    private void OnCollisionEnter(Collision collision) {
        // Debug.Log("asdasd @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        m_JumpCount = LogicValue.JumpCount; 
        // m_IsJump = false; 
        // 리지드바디를 가진 오브젝트만 호출
        // 리지드바디와 컬라이더를 가진 어떤 오브젝트가
        // 다른 컬라이더를 가진 오브젝트와 최초 충돌하는 순간
    }

    // n단 점프
    private int m_JumpCount = 3;

    private bool m_IsJump = false;
    private Rigidbody m_Rigi = null;

    private void Awake() {
        m_Rigi = GetComponent<Rigidbody>();

        m_JumpCount = LogicValue.JumpCount;


        if (m_Rigi == null) {
            Debug.LogError(" if (m_Rigi == null) ");
        }
    }

    void Update() {

        if( transform.position.y <= -MoveCamera.CamCom.orthographicSize ) {
            
            // RESET
            // Destroy(gameObject);
            //Player RESET
            transform.position = Vector3.zero;
            MoveCamera.CameraReset();
            Map.PanjaReset();
        }


        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;

        // Debug.Log("m_JumpCount : " + m_JumpCount);
        // Debug.Log("LogicValue.JumpPower : " + LogicValue.JumpPower);
        // if ( (true == Input.GetKey(KeyCode.Space) ) && m_JumpCount > 0) {
        if (true == Input.GetKeyDown(KeyCode.Space) ) {
            if( m_JumpCount > 0 ) {


            // 리지드바디를 받아옴
            // 중력값과 함께
            // Debug.Log("@@@@@@@@@@@@@@ : " + Vector3.up);
            // Debug.Log("@@@@@@@@@@@@@@ : " + LogicValue.JumpPower);
            

            m_Rigi.AddForce(Vector3.up * LogicValue.JumpPower);
            m_Rigi.velocity = Vector3.zero;
            Debug.Log("m_Rigi.velocity : " + m_Rigi.velocity);
            // m_IsJump = true;
            
            --m_JumpCount;
            // Debug.Log("m_JumpCount : " + m_JumpCount);
            }

        } 
    }


}
