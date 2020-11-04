using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private static Vector3 StartPos = Vector3.zero;
    // private void 
    private static MoveCamera GameCamera = null;
    public static Camera CamCom = null;

    public static void CameraReset() {
        GameCamera.transform.position = StartPos;
    }

    private void  Awake() {
        
        StartPos = transform.position;
        GameCamera = this;
        CamCom = GetComponent<Camera>();
        Debug.Log("Camera Awake : " + CamCom);
    }
    void Update()
    {
        // Map map = new Map();
        // map.func();
        this.transform.position += Vector3.right * Time.deltaTime * LogicValue.MoveSpeed;
    }
}
