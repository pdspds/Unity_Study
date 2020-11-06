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

        set
        {
            Inst.m_CameraAndPlayerData.m_MoveSpeed = value;
        }

    }


    public static float JumpPower {
        get {
            return Inst.m_CameraAndPlayerData.m_JumpPower;
        }
        set
        {
            Inst.m_CameraAndPlayerData.m_JumpPower = value;
        }
    }

    public static int JumpCount {
        get {
            return Inst.m_CameraAndPlayerData.m_JumpCount;
        }
        set
        {
            Inst.m_CameraAndPlayerData.m_JumpCount = value;
        }
    }



    [SerializeField] 
    private GameObject m_CoinPrefab;
    public static GameObject CoinPrefab {
        get {
            return Inst.m_CoinPrefab;
        }
    }    

    [SerializeField] 
    private GameObject m_BSPrefab;
    public static GameObject BSPrefab {
        get {
            return Inst.m_BSPrefab;
        }
    }    

    [SerializeField] 
    private GameObject m_BMPrefab;
    public static GameObject BMPrefab {
        get {
            return Inst.m_BMPrefab;
        }
    }    


    [SerializeField] 
    private Sprite m_MainFloor;
    [SerializeField] 
    private Sprite m_LeftFloor;
    [SerializeField] 
    private Sprite m_RightFloor;

    public static Sprite MainFloor {
        get {
            return Inst.m_MainFloor;
        }
    }    
    public static Sprite LeftFloor {
        get {
            return Inst.m_LeftFloor;
        }
    }    
    public static Sprite RightFloor {
        get {
            return Inst.m_RightFloor;
        }
    }    

    [SerializeField] 
    private static int m_Score;

    public static int Score {
        get {
            return m_Score;
        }
    }


    public class ScoreData {
        public string Name;
        public int Score;
        public ScoreData(string _Name, int _Score) {
            Name = _Name;
            Score = _Score;
        }
    }

    // [SerializeField] 
    // private static bool m_Load = false;

    [SerializeField] 
    private static List<ScoreData> m_ScoreArr;

    public static List<ScoreData> ScoreArr {
        get {
            return m_ScoreArr;
        }
    }
    
    public static void ScoreLoad() {
        if( PlayerPrefs.HasKey("Name0") == true) {
            // 키가 존재한다면 기존데이터가 있다.

            m_ScoreArr = new List<ScoreData>();

            for (int i = 0; i < 5; i++) {
                ScoreData NewScore = new ScoreData(PlayerPrefs.GetString("Name" + i), PlayerPrefs.GetInt("Score" + i));
                m_ScoreArr.Add(NewScore);
            }
            return;
        }

        // PlayerPrefs.SetString(string key, string value);
        // m_Score.Clear();
        // PlayerPrefs.HasKey("Name0");

        m_ScoreArr = new List<ScoreData>();
        
        for (int i = 0; i < 5; i++) {

            // save
            PlayerPrefs.SetString("Name" + i, "");
            PlayerPrefs.SetInt("Score" + i, 0);

            ScoreData NewScore = new ScoreData("", 0);
            m_ScoreArr.Add(NewScore);
        }
        // m_Load = true;
    }

    public static void ScoreInput(string _Name) {

        ScoreData CheckData = new ScoreData(_Name, m_Score);
        m_Score = 0;
        for (int i = 0; i < ScoreArr.Count; i++) {
            if(CheckData.Score > ScoreArr[i].Score) {
                ScoreData TempScore = ScoreArr[i];
                ScoreArr[i] = CheckData;
                CheckData = TempScore;
            }
        }

        for (int i = 0; i < 5; i++) {
            
            PlayerPrefs.SetString("Name" + i, m_ScoreArr[i].Name);
            PlayerPrefs.SetInt("Score" + i, m_ScoreArr[i].Score);
        }
    }

    public static bool ScoreCheck() {
        // 기록에 들어간다면 T
        for (int i = 0; i < ScoreArr.Count; i++) {

            if(m_Score > ScoreArr[i].Score) {
                // 새로운 기록T

                return true;
            }
        }
        return false;
    }

    public static void PlusScore(int _Score) {
        m_Score += _Score;
    }

    public static void ScoreReset() {
        m_Score = 0;
    }

 
    private void Awake() {
        // Debug.Log("LogicValue Awake");
        // 이 코드는 1순위로 실행
        Inst = this;
        
    }
// PlayerPrefs.DeleteAll
    void Update()
    {
        
    }
    public static GameObject NameInst(GameObject _NewObject) {
        GameObject NewObj = GameObject.Instantiate(_NewObject);
        NewObj.name = _NewObject.name;
        return NewObj;

    }
}
