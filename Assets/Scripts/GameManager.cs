using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 壁方向
    public const int WALL_FRONT = 1; // 前
    public const int WALL_RIGHT = 2; // 右
    public const int WALL_BACK = 3; // 後
    public const int WALL_LEFT = 4; // 左

    public GameObject panelWalls; // 壁全体
    public GameObject buttonMessage; // ボタン：メッセージ
    public GameObject buttonMessageText; // メッセージテキスト

    private int wallNo; // 現在の向いている方向

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT; // スタート時点は前を向く
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // メモをタップ
    public void PushButtonMemo()
    {
        DisplayMessage("エッフェル塔と書いてある。");
    }

    // メッセージをタップ
    public void PushButtonMessage()
    {
        buttonMessage.SetActive(false); // メッセージを消す
    }

    // メッセージを表示
    void DisplayMessage(string mes)
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }

    // 右ボタン押す
    public void PushButtonRight()
    {
        wallNo++; // 方向を１つ右に(wallNoを1増やす)

        // 左の時は前に移動する(wallNoを1にする)
        if (wallNo > WALL_LEFT)
        {
            wallNo = WALL_FRONT;
        }

        DisplayWall(); //壁表示更新
    }

    // 左ボタン押す
    public void PushButtonLeft()
    {
        wallNo--; // 方向を１つ左に(wallNoを1減らす)

        // 前の時は左に移動する(wallNoを4にする)
        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEFT;
        }

        DisplayWall(); //壁表示更新
    }

    // 向いている方向の壁を表示
    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT: // 前
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;

            case WALL_RIGHT: // 右
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;

            case WALL_BACK: // 後
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;

            case WALL_LEFT: // 左
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }
    }
}
