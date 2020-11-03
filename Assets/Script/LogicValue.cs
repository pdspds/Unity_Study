using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임내에서 명확하게 LogicValue의 Awake

// 데이터 직렬화
// 컴퓨터가 읽고 쓰기를 쉽게 변경해주는 기능
[Serializable]
public class CameraAndPlayerData {

    [SerializeField]
    public float m_MoveSpeed = 10.0f;

    [SerializeField]
    public float m_JumpPower = 15.0f;

    [SerializeField]
    public int m_JumpCount = 3;

}


public class LogicValue : MonoBehaviour
{
    // 변형 싱글톤
    private static LogicValue Inst = null;

    [SerializeField]
    private CameraAndPlayerData m_CameraAndPlayerData = new CameraAndPlayerData();
    
    public static float MoveSpeed {
        get {
            return Inst.m_CameraAndPlayerData.m_MoveSpeed;
        }
    }


    public static float JumpPower {
        get {
            return Inst.m_CameraAndPlayerData.m_JumpPower;
        }
    }

    public static int JumpCount {
        get {
            return Inst.m_CameraAndPlayerData.m_JumpCount;
        }
    }

    private void Awake() {
        // Debug.Log("LogicValue Awake");
        // 이 코드는 1순위로 실행
        Inst = this;
    }

    void Update()
    {
        
    }
}
