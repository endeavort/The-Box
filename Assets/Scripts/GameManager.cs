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

    // ボタンカラー
    public const int COLOR_GREEN = 0; // 緑
    public const int COLOR_RED = 1; // 赤
    public const int COLOR_BLUE = 2; // 青
    public const int COLOR_WHITE = 3; // 白

    public GameObject panelWalls; // 壁全体
    public GameObject buttonMessage; // ボタン：メッセージ
    public GameObject buttonMessageText; // メッセージテキスト

    public GameObject buttonHammer; // ボタン：トンカチ
    public GameObject imageHammerIcon; // アイコン：トンカチ

    public GameObject[] buttonLamp = new GameObject[3]; // ボタン：金庫

    public Sprite[] buttonPicture = new Sprite[4]; // ボタンの絵

    public Sprite hammerPicture; // トンカチの絵

    private int wallNo; // 現在の向いている方向
    private bool doesHaveHammer; // トンカチの所有フラグ
    private int[] buttonColor = new int[3]; // 金庫のボタン配列リスト

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT; // スタート時点は前を向く
        doesHaveHammer = false; // トンカチ未所持
        buttonColor[0] = COLOR_GREEN; // ボタン1「緑」
        buttonColor[1] = COLOR_RED; // ボタン2「赤」
        buttonColor[2] = COLOR_BLUE; // ボタン3「青」

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

    // 金庫のボタン1をタップ
    public void PushButtonLamp1()
    {
        ChangeButtonColor(0);
    }

    // 金庫のボタン2をタップ
    public void PushButtonLamp2()
    {
        ChangeButtonColor(1);
    }

    // 金庫のボタン3をタップ
    public void PushButtonLamp3()
    {
        ChangeButtonColor(2);
    }

    // 金庫のボタンの色を変更
    void ChangeButtonColor(int buttonNo)
    {
        buttonColor[buttonNo]++;

        // 「白」の次は「緑」に戻す
        if (buttonColor[buttonNo] > COLOR_WHITE)
        {
            buttonColor[buttonNo] = COLOR_GREEN;
        }

        // ボタンの画像を変更
        buttonLamp[buttonNo].GetComponent<Image>().sprite = buttonPicture[buttonColor[buttonNo]];
    }
}
