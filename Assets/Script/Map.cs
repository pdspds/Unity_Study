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
    private float CreateRandomScaleXStart = 0.5f;
    [SerializeField]
    private float CreateRandomScaleXEnd = 1.5f;

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
        // Debug.Log("Map Awake");
        // CheckPanjaCreate();
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
        } else {
            // Debug.Log("MAke MAP@@@@@@");
        }
        GameObject NewPanja = new GameObject("Panja");
        Vector3 CreatePos = new Vector3();

        NewPanja.transform.localScale = new Vector3(UnityEngine.Random.Range(CreateRandomScaleXStart, CreateRandomScaleXEnd), 1.0f, 5.0f);

        // Debug.Log("TEST:::::" + NewPanja.transform.localScale.x * 0.5F);
        // 최소한
        CreatePos.x = LastCreatePosX + LastCreateScaleX + (NewPanja.transform.localScale.x * 0.5F);
        // 추가 
        CreatePos.x += UnityEngine.Random.Range(CreateRandomInterXStart, CreateRandomInterXSEnd);

        // CreatePos.y = -1.77f;
        CreatePos.y = UnityEngine.Random.Range(CreateRandomRangeYStart, CreateRandomRangeYEnd);
        CreatePos.z = 0.0f;

        NewPanja.transform.position = CreatePos;
        // NewPanja.transform.localScale.z = 5f;

        // 이미지 생성
        SpriteRenderer NewSp = NewPanja.AddComponent<SpriteRenderer>();

        // 스프라이트에 입력
        NewSp.sprite = PanjaSprite;

        // 갱신
        LastCreatePosX = CreatePos.x;
        LastCreateScaleX = (NewPanja.transform.localScale.x * 0.5f);
        
        NewPanja.AddComponent<BoxCollider>();
        NewPanja.AddComponent<PanjaScript>();

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
        // CheckPanjaCreate();


        // CreateRange = this.transform.position.x;
        // Debug.Log("this.transform.position.x : " + this.transform.position.x);
        // 이전 프레임에서 0.1초가 지났다.
        CreateTime -= Time.deltaTime;

        if( CreateTime <= 0.0f ) {
            //랜덤 함수
            RandomInt = UnityEngine.Random.Range(-2.0f, 2.1f);
                if(RandomInt > 0.5f) {
                    GameObject NewWater = new GameObject("Water");
                    Vector3 CreatePos2 = this.transform.position;
                    CreatePos2.z = 0.0f;
                    CreatePos2.y = -3f;
                    NewWater.transform.position = CreatePos2;
                    SpriteRenderer NewSp2 = NewWater.AddComponent<SpriteRenderer>();
                    NewSp2.sprite = WaterSprite;
                } 
        CreateTime = CreateTimeInter;

        }
    }
}
