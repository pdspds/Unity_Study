using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour
{
    // 1. 리터럴 초기화 
    // PanjaSprite = null;

    // 2. 엔진 초기화
    // PanjaSprite = Panja.png

    // 3. 함수 대입
    // PanjaSprite = 내가 대입 해준 것.


    [SerializeField]
    private float CreateTime = 1.0f;


    [SerializeField]
    private float CreateTimeInter = 1.0f;

    

    [SerializeField]
    Sprite PanjaSprite = null;


    [SerializeField]
    Sprite WaterSprite = null;

    float RandomInt = 0.0f;

    [SerializeField]
    private float CreateRange = 5.0f;
    // [SerializeField]
    // private float LastCreateX = 0.0f;

    [SerializeField]
    private float CreateRandomRangeYStart = 1.77f;
    [SerializeField]
    private float CreateRandomRangeYEnd = -2.77f;

    [SerializeField]
    private float CreateRandomInterXStart = 2.0f;
    [SerializeField]
    private float CreateRandomInterXSEnd = 4.0f;


    [SerializeField]
    private int CreateRandomScaleXStart = 5;
    [SerializeField]
    private int CreateRandomScaleXEnd = 10;

    // 마지막으로 만들어진 판자의 X 위치
    // [SerializeField]
    // private float CreateRandomPosX = 0f;

    // 마지막으로 만들어진 판자의 X 크기
    [SerializeField]
    private float CreateRandomScaleX = 1.0f;


    [SerializeField]
    private float LastCreatePosX = 0f;

    [SerializeField]
    private float LastCreateScaleX = 5f;


    private float ResetLastCreatePosX = 0f;
    private float ResetLastCreateScaleX = 5f;

    public static Map MainMap;

    void Awake() {
        ResetLastCreatePosX = LastCreatePosX;
        ResetLastCreateScaleX = LastCreateScaleX;
        MainMap = this;
    }

    public static void PanjaReset() {
        MainMap.ResetData();
    }

    public void ResetData() {
        LastCreatePosX = ResetLastCreatePosX;
        LastCreateScaleX = ResetLastCreateScaleX;
        CheckPanjaCreate();
    }

    bool NewPanjaLogic() {
        if (LastCreatePosX >= PlayerScript.PlayerPos.x+CreateRange) {
            return false;
        }

        int NewFloorCount = UnityEngine.Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd + 1);

        GameObject NewPanja = new GameObject("Panja");
        SpriteRenderer NewPanjaSR = NewPanja.AddComponent<SpriteRenderer>();
        Vector3 CreatePos = new Vector3();


        // 최소한
        CreatePos.x = LastCreatePosX + LastCreateScaleX + (NewFloorCount * 0.5F);
        // 추가 
        CreatePos.x += UnityEngine.Random.Range(CreateRandomInterXStart, CreateRandomInterXSEnd);

        CreatePos.y = UnityEngine.Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);
        CreatePos.z = 0.0f;

        NewPanja.transform.position = CreatePos;



        PanjaScript PS = NewPanja.AddComponent<PanjaScript>();
        //정수는 1 ~ 10이면 1 ~ 9
        PS.FloorCount = NewFloorCount;

        BoxCollider BC = NewPanja.AddComponent<BoxCollider>();
        BC.size = new Vector3(NewFloorCount + 1f, 1, 1);
        BC.center = new Vector3(-0.5f, -0.4f, 0);

        // 갱신
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (PS.FloorCount * 0.5f);
        
        return true;
    }

    void CheckPanjaCreate() {
        while (NewPanjaLogic());
        // NewPanjaLogic();
    }


    // Update is called once per frame
    void Update()
    {
        // 시간에 의존한 로직이 아니다.
        NewPanjaLogic();
    }
}
