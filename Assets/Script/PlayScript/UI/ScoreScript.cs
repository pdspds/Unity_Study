using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text TextCom = null;
    void Start()
    {
        TextCom = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TextCom == null) {
            Debug.LogError("if (TextCom == null)");
            return;
        }

        TextCom.text = LogicValue.Score.ToString();
    }
}
