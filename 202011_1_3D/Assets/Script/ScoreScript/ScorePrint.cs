using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrint : MonoBehaviour
{
    Text[] ArrText = null; 

    [SerializeField]
    GameObject NameInputObj = null;
    // Start is called before the first frame update
    void Awake()
    {
        LogicValue.ScoreLoad();

        if(NameInputObj == null) {
            Debug.Log("NameInputObj == null");
        }
        if(true == LogicValue.ScoreCheck()) {
            NameInputObj.SetActive(true);
        }
        // LogicValue.ScoreCheck();

    }

    // Update is called once per frame
    void Update()
    {
        ArrText = GetComponentsInChildren<Text>();
        if ( LogicValue.ScoreArr.Count != ArrText.Length) {
            Debug.LogError( "LogicValue.ScoreArr.Count != ArrText.Length" );
            return;
        }
        
        for (int i = 0; i < ArrText.Length; i++) {
            if(LogicValue.ScoreArr[i].Score == 0) {
                ArrText[i].text = "미등록";
                continue;
            }

            string name = LogicValue.ScoreArr[i].Name;
            if( name == "" ) {
                name = "NONAME";
            }
            ArrText[i].text = (i + 1).ToString() + " . " + LogicValue.ScoreArr[i].Name + " " + LogicValue.ScoreArr[i].Score.ToString();
        }   
    }
}
