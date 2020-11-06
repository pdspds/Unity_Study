﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ResetBtn : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{

    public void OnPointerClick(PointerEventData eventData) {
        PlayerPrefs.DeleteAll();
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("ui 범위를 나갔습니다.");
    }

    public void GameScoreReset() {
        Debug.Log("RESET");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
