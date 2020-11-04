using System.Net.Sockets;
using System.Xml.Serialization;
using Microsoft.Win32.SafeHandles;
// using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{

    [SerializeField]
    private int Count;
    public int FloorCount {
        set {
            Count = value;

            float MoveSize = Count * -0.5f;
            for (int i = 0; i < Count; i++) {
                GameObject NewObj = new GameObject("Floor");

                NewObj.transform.SetParent(transform);
                NewObj.transform.localPosition = new Vector3(i + MoveSize, 0, 0);
                SpriteRenderer NewSR = NewObj.AddComponent<SpriteRenderer>();
                NewSR.sprite = LogicValue.MainFloor;

            GameObject NewCoin = GameObject.Instantiate(LogicValue.CoinPrefab);
            NewCoin.transform.position = NewObj.transform.position + Vector3.up;
            }

            GameObject Left = new GameObject("LeftFloor");

            Left.transform.SetParent(transform);
            Left.transform.localPosition = new Vector3(-1 + MoveSize, 0, 0);
            SpriteRenderer LeftSR = Left.AddComponent<SpriteRenderer>();
            LeftSR.sprite = LogicValue.LeftFloor;


            GameObject Right = new GameObject("RightFloor");

            Right.transform.SetParent(transform);
            Right.transform.localPosition = new Vector3(Count + MoveSize, 0, 0);
            SpriteRenderer RightSR = Right.AddComponent<SpriteRenderer>();
            RightSR.sprite = LogicValue.RightFloor;
        }

        get {
            return Count;
        }
    }

    private void Awake() {

        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        SR.sortingOrder = -500;

        if(LogicValue.CoinPrefab == null) {
            Debug.LogError("CoinError");
            Destroy(gameObject);
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerScript.IsDeath == true) {
            Destroy(gameObject);
        }

        if( PlayerScript.PlayerPos.x - transform.position.x >= 10.0f) {
            Destroy(gameObject);
        }
    }

    private void LateUpdate() {
        if(PlayerScript.IsDeath == true) {
            Destroy(gameObject);
        }
    }
}
