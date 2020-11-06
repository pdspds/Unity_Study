using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using System;

public class EditorWindowTest : EditorWindow
{

    //[ExecuteInEditMode]

    [MenuItem("Custom/PlayWindow")]
    public static void Open() {


        Debug.Log("커스텀 윈도우 Start");
        GetWindow<EditorWindowTest>().titleContent = new GUIContent("PlayWindow");
    }

    private void OnGUI() {

        // 플레이어 캐릭터 이미지
        Object player_c_1 = Resources.Load("Image/player_1/Idle (1)");
        Object player_c_2 = Resources.Load("Image/player_2/Idle (1)");
        Object player_c_3 = Resources.Load("Image/player_3/Idle (1)");
        Object player_c_4 = Resources.Load("Image/player_4/Idle (1)");



        GUILayout.Label("Player Characters");
        GUILayout.BeginHorizontal("Player Characters List");
            if (GUILayout.Button((Texture)player_c_1, GUILayout.Width(100), GUILayout.Height(100)))
            {
                Player_Characters(1);
            } else
            if (GUILayout.Button((Texture)player_c_2, GUILayout.Width(100), GUILayout.Height(100)))
            {
                Player_Characters(2);
            }
            if (GUILayout.Button((Texture)player_c_3, GUILayout.Width(100), GUILayout.Height(100)))
            {
                Player_Characters(3);
            }
            if (GUILayout.Button((Texture)player_c_4, GUILayout.Width(100), GUILayout.Height(100)))
            {
                Player_Characters(4);
            }
        GUILayout.EndHorizontal();



    }

    private void Player_Characters(int character)
    {
        // 플레이어 캐릭터 변경
        GameObject player = GameObject.Find("Player");
        SpriteRenderer playerSR = player.GetComponent<SpriteRenderer>();

        playerSR.sprite = Resources.Load("Image/player_"+ character+ "/Idle (1)", typeof(Sprite)) as Sprite;


    }
}
 