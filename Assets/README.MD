# Unity (ver 2019.4.12f1)

  # 2020.11.02 ~ 2020.11.06 (유투브 강의 영상 [https://www.youtube.com/playlist?list=PL4SIC1d_ab-avhu7-dI5-YK3rHlH-lZwB])
  # 1. 1 ~ 4화
   - Tag, Layer
     - Tag, Layer를 사용하여 카메라에서 표시를 따로 가능 (Culling Mask)

   - Scene : 장면 ( 세트장 )
     - 다중 Scene
  
   - Camera : 카메라
     - Transform [X(좌우), Y(상하), Z(앞뒤)]
       - 카메라에 대한 속성[인스펙터] (Position[이동], Rotation[회전], Scale[크기])
     - Clear Flags
       - Solid Color는 Background로 선택 가능, SkyBox 기본 배경
     - Culling Mask
       - 표시하고 싶은 Layer 선택
     - Projection
       - Perspective(입체적)
       - Orthogaphic(평면적)
     - Field of View(시야각)
     - Clipping Planes
       - Near (시야의 시작점)
       - Far (시야의 끝점)
     - Viewport Rect
       - 모니터의 기준으로 X, Y, W, H 설정 가능 (미니맵, 백미러, 다중 카메라 사용 시 가능)
     - Depth (카메라의 순서)
     
   - Object : 물체
   - github와 연동 및 커밋 업데이트

  # 2. 5 ~ 11화
    - Image ( Sprite Renderer )
      - 이미지 변경 Texture Type : Sprite(2D and UI)
      - Pixels per Unit ( 원래 크기에 값을 나누어 비율을 맞춤 )
      - color (색상 블랜딩 가능) 

    - Scene
      - 화면 비율 고정 및 변경

    - Script 생성
    - Console 창
      - Collapse : 중복된것을 묶어준다. ( 주소값도 같아야한다. )
      - Clear on Play, Clear on Build : 실행할때마다 Clear 시켜서 본다

    - 유니티 C#
      - 파일명과 동일한 클래스가 하나라도 있고 [ : MonoBehaviour ]을 상속 받아야 스크립트로서 Object에 넣어주는 것이 가능하다.
      - 시점 함수 ( Start, Update, Awake) [https://docs.unity3d.com/kr/530/Manual/ExecutionOrder.html]
      - 생성자 함수 : 함수명() { }
      - 제네릭 함수 GetComponent<>
        - Inspector에 접근 가능
        - Transform
          - Transform 함수명 = GetComponent<Transform>();
          - 함수명.position = new Vector3(x, y, z);
          - Transform을 자동으로 지원 [transform]
        - SpriteRenderer
          - SpriteRenderer 함수명 = GetComponent<SpriteRenderer>();
          - 함수명.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        - Script 중복으로 생성 가능
          - public 일때 멤버변수가 그대로 화면에 드러남.
            - [SerializeField] 어트리뷰트 문법
          - private을 사용 권장
      - Update() : 실행해줄 수 있는 프레임을 최대 한도로 실행
      - Time.deltaTime
        - 성능의 영향을 받음 (자동 계산)
      - Debug
        - Debug.Log("Log"); 일반적인 로그
        - Debug.LogWarning("LogWarning"); 경고 로그
        - Debug.LogError("LogError"); 에러 로그

    - 게임 설계
      - GameObject gameObj = new GameObject("name");
        - - transform.localScale = new Vector3(float, float, float);
      - AddComponent<클래스명>();
      - UnityEngine.Random.Range(float, float, float) : 랜덤 함수


      - 플레이어 (class Player)
        - 상태(멤버변수) 명사
        - 행동(멤버함수) 동사
        - RegidBody ( 중력, 충돌 )
          - 충돌해야하는 A와 B가 있다면
          - A 혹은 B 둘 중 하나는 RegidBody가 존재해야 한다.
          - 3D RegidBody라면 3D 컬라이더와만 충돌해야한다.
          - 강체라 하며, 물리적속성 전체에 관여 (힘)
          - AddForce ( 더하기 Y ) 0,10,0
          - Constraints : Position, Rotation Freeze 기능

      - 카메라 (class MoveCamera)

      - Map (class Pan)
        - Box Collider
      - 데이터 직렬화 [Serializable]
        - 컴퓨터가 읽고 쓰기를 쉽게 변경해주는 기능

      - Project Settings > Script Execution Order
        - Script 실행 순서
      - Project Settings > Physics
        - Gravity Y = 중력


  # 3. 12 ~ 18화
   - Box Collider
     - Is Trigger : 물리적 접촉을 체크는 하되, 밀려나지 않는다
   - GameObject.Instantiate(복사);
   - Sprite Editor 문제 해결
   - Animation, Animator
     - AnimationController : Animation을 관리한다
       - Make Transition으로  연결 시킨다
       - Any State : 명령으로 연결된 애니메이션 실행
       - 
     - Animator : Animation을 사용
   - 2D 렌더링
     - 렌더링의 순서
       - 맨 뒤부터 렌더링
       - Default는 z값이 뒤에 있는 Object가 그려진다고 볼 수 있다.
       - 카메라의 시점이나 위치에 따라 다를 수 있다.
       - sortingOrder : 렌더링의 순서를 결정 해줌.
       - 그 외 방법 : 카메라를 여러개 쓰며 각자의 Object를 비춰준다.
   - 물리적인 업데이트는 따로 구현한다.
   - AddForce(int, ForceMode.Impulse) : 물체 Mass 속성이랑 영향받아서 순간적인 힘을 주는 옵션
   - UI : 스크린 크기 기준으로 맞춘다
   - 캔버스 -> UGUI의 기본적인 기능을 제어
     - Render Mode
       - Overlay : 월드에 대한 크기
       - Camera : 카메라에 대한 크기
   - 캔버스 스케일러 -> 캔버스 공간의 크기에 대해 제어
   - 캔버스 레이캐스트 -> 캔버스 내부의 충돌과 이벤트에 대해 제어
     - 하나의 컴포넌트의 힘을 더 빌림 -> 이벤트 시스템이라는 컴포넌트의 힘들 빌림
     - 버튼, 스크롤바

  # 2. 19 ~ 24화
   - File > Build Settings : Scenes In Build에 사용 할 Scenes Setting
   - 일반적인 상속은 하나의 부모만 상속 받는다.
   - interface 여러개의 상속을 받을 수 있다. (추상 : abstract)
     - 실체를 가지지 않고 개념이 공통적일 때 사용
   - using UnityEngine.UI;
     - Text나 Button 같은 UGUI의 컴포넌트를 사용할 수 있다.
   - using UnityEngine.EventSystems;
     - ipointer 이벤트를 등록할 수 있다.
   - using UnityEngine.SceneManagement;
     - 씬을 넘기는 일을 실행시킬 수 있다.
     - 새로운 씬을 만들거나 중첩로딩을 할 수 있다.
       - SceneManager.LoadScene("PlayScene");
   - UI TEXT : 사이즈 지정 및 폰트 변경
   - GetComponents<Text>(); 내 안에 여러개의 컴포넌트를 호출
   - GetComponentsInChildren<Text>(); 내 안에 자식까지 여러개의 컴포넌트를 호출


    

# 질문 사항
 - VS C# 관련 마켓플레이스
  - C# 프레임워크
 - Time.deltaTime
   - 프레임 느낌 (FPS)
 - class Name에 _
 - 물리적 중력과 up 파워 

 - 판자와 캐릭터 겹침 // 해결: 판자localScale.z 캐릭터보다 늘림