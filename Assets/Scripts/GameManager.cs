using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �Ǖ���
    public const int WALL_FRONT = 1; // �O
    public const int WALL_RIGHT = 2; // �E
    public const int WALL_BACK = 3; // ��
    public const int WALL_LEFT = 4; // ��

    // �{�^���J���[
    public const int COLOR_GREEN = 0; // ��
    public const int COLOR_RED = 1; // ��
    public const int COLOR_BLUE = 2; // ��
    public const int COLOR_WHITE = 3; // ��

    public GameObject panelWalls; // �ǑS��
    public GameObject buttonMessage; // �{�^���F���b�Z�[�W
    public GameObject buttonMessageText; // ���b�Z�[�W�e�L�X�g

    public GameObject buttonHammer; // �{�^���F�g���J�`
    public GameObject imageHammerIcon; // �A�C�R���F�g���J�`

    public GameObject[] buttonLamp = new GameObject[3]; // �{�^���F����

    public Sprite[] buttonPicture = new Sprite[4]; // �{�^���̊G

    public Sprite hammerPicture; // �g���J�`�̊G

    private int wallNo; // ���݂̌����Ă������
    private bool doesHaveHammer; // �g���J�`�̏��L�t���O
    private int[] buttonColor = new int[3]; // ���ɂ̃{�^���z�񃊃X�g

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT; // �X�^�[�g���_�͑O������
        doesHaveHammer = false; // �g���J�`������
        buttonColor[0] = COLOR_GREEN; // �{�^��1�u�΁v
        buttonColor[1] = COLOR_RED; // �{�^��2�u�ԁv
        buttonColor[2] = COLOR_BLUE; // �{�^��3�u�v

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �������^�b�v
    public void PushButtonMemo()
    {
        DisplayMessage("�G�b�t�F�����Ə����Ă���B");
    }

    // ���b�Z�[�W���^�b�v
    public void PushButtonMessage()
    {
        buttonMessage.SetActive(false); // ���b�Z�[�W������
    }

    // ���b�Z�[�W��\��
    void DisplayMessage(string mes)
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }

    // �E�{�^������
    public void PushButtonRight()
    {
        wallNo++; // �������P�E��(wallNo��1���₷)

        // ���̎��͑O�Ɉړ�����(wallNo��1�ɂ���)
        if (wallNo > WALL_LEFT)
        {
            wallNo = WALL_FRONT;
        }

        DisplayWall(); //�Ǖ\���X�V
    }

    // ���{�^������
    public void PushButtonLeft()
    {
        wallNo--; // �������P����(wallNo��1���炷)

        // �O�̎��͍��Ɉړ�����(wallNo��4�ɂ���)
        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEFT;
        }

        DisplayWall(); //�Ǖ\���X�V
    }

    // �����Ă�������̕ǂ�\��
    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT: // �O
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;

            case WALL_RIGHT: // �E
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;

            case WALL_BACK: // ��
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;

            case WALL_LEFT: // ��
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;
        }
    }

    // ���ɂ̃{�^��1���^�b�v
    public void PushButtonLamp1()
    {
        ChangeButtonColor(0);
    }

    // ���ɂ̃{�^��2���^�b�v
    public void PushButtonLamp2()
    {
        ChangeButtonColor(1);
    }

    // ���ɂ̃{�^��3���^�b�v
    public void PushButtonLamp3()
    {
        ChangeButtonColor(2);
    }

    // ���ɂ̃{�^���̐F��ύX
    void ChangeButtonColor(int buttonNo)
    {
        buttonColor[buttonNo]++;

        // �u���v�̎��́u�΁v�ɖ߂�
        if (buttonColor[buttonNo] > COLOR_WHITE)
        {
            buttonColor[buttonNo] = COLOR_GREEN;
        }

        // �{�^���̉摜��ύX
        buttonLamp[buttonNo].GetComponent<Image>().sprite = buttonPicture[buttonColor[buttonNo]];
    }
}
