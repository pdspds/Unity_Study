using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    // 플레이어는 단일
    private static bool m_IsDeath;
    public static bool IsDeath {
        get {
            return m_IsDeath;
        }
    }

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
        m_Ani.SetTrigger("RUN");
        m_JumpCount = LogicValue.JumpCount; 
    }

    // n단 점프
    private int m_JumpCount = 3;

    private Animator m_Ani = null;

    private bool m_IsJump = false;
    private Rigidbody m_Rigi = null;
    

    private void Awake() {
        m_Ani = GetComponent<Animator>();

        m_Rigi = GetComponent<Rigidbody>();

        m_JumpCount = LogicValue.JumpCount;


        if (m_Rigi == null) {
            Debug.LogError(" if (m_Rigi == null) ");
        }
    }

    private void FixedUpdate() {
        if( m_IsDeath == true ) {
            Map.PanjaReset();

            LogicValue.NameInst(LogicValue.BSPrefab);
            LogicValue.NameInst(LogicValue.BMPrefab);
            // GameObject NewBS = Instantiate<GameObject>(LogicValue.BSPrefab);
            // NewBS.name = LogicValue.BSPrefab.name;
            // GameObject NewBM = Instantiate<GameObject>(LogicValue.BMPrefab);
            // NewBM.name = LogicValue.BMPrefab.name;
            m_IsDeath = false;

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

            m_IsDeath = true;

        }


        transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
        m_PlayerPos = transform.position;


        if (true == Input.GetKeyDown(KeyCode.Space) ) {
            if( m_JumpCount > 0 ) {          

            m_Rigi.AddForce(Vector3.up * LogicValue.JumpPower, ForceMode.Impulse);
            m_Rigi.velocity = Vector3.zero;
            m_Ani.SetTrigger("JUMP");
            --m_JumpCount;
            }

        } 
    }


}
