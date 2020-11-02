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