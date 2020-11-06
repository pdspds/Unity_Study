using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NameInPut : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject NameInputWin = null;

    [SerializeField]
    Text NewUserName = null;

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("ASDASD : " + NewUserName.text.ToString());
        LogicValue.ScoreInput(NewUserName.text.ToString());
        NameInputWin.SetActive(false);

    }

}
