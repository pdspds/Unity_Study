using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRatio : MonoBehaviour
{
    [SerializeField]
    private Vector2 BasicSize;

    [SerializeField]
    private Camera Cam;

    // Start is called before the first frame update
    void Awake()
    {
        if(Cam == null) {
            Debug.LogError("if (null == Cam)");
        }
        //Screen.width // 모바일에 가상키보드를 인식하지 못한다.
        CanvasScaler CS = GetComponent<CanvasScaler>();
        if((BasicSize.x / BasicSize.y) > (Cam.pixelWidth / Cam.pixelHeight)) {
            CS.matchWidthOrHeight = 0.0f;
        } else {
            CS.matchWidthOrHeight = 1.0f;
        }

        // Cam.pixelWidth / Cam.pixelHeight
        // 0 이면 너비, 1이면 높이
        // CS.matchWidthOrHeight
        // CS.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
