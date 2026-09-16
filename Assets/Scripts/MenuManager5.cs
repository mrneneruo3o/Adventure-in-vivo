using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager5 : MonoBehaviour
{
    private int index = 0;
    private int menuCount = 0;
    private GameObject[] menus;

    public string[] stageSceneNames;

    public GameObject confirmUI;     // 確認パネル
    public Text confirmText;         // 上部メッセージ用テキスト
    public Text[] optionTexts;       // 「はい」「いいえ」のテキストUI（2つ）

    private bool isConfirming = false;
    private int confirmIndex = 0;    // 0=はい, 1=いいえ

    void Start()
    {
        menuCount = transform.childCount;
        menus = new GameObject[menuCount];

        for (int i = 0; i < menuCount; i++)
        {
            menus[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject menu in menus)
            menu.SetActive(false);

        menus[index].SetActive(true);

        if (confirmUI != null)
            confirmUI.SetActive(false);
    }

    void Update()
    {
        if (isConfirming)
        {
            ConfirmInput();
            return;
        }

        // 通常メニュー操作
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeMenu(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeMenu(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            ShowConfirm();
        }
    }

    void ChangeMenu(int direction)
    {
        menus[index].SetActive(false);
        index += direction;

        if (index >= menuCount) index = 0;
        if (index < 0) index = menuCount - 1;

        menus[index].SetActive(true);
    }

    void ShowConfirm()
    {
        isConfirming = true;
        confirmIndex = 0; // 最初は「はい」を選択

        confirmUI.SetActive(true);
        confirmText.text = "このステージで遊びますか？";

        UpdateConfirmUI();
    }

    void ConfirmInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            confirmIndex = 1 - confirmIndex; // 0↔1切り替え
            UpdateConfirmUI();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (confirmIndex == 0) // はい
                LoadStage();
            else // いいえ
                CancelConfirm();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelConfirm();
        }
    }

    void UpdateConfirmUI()
    {
        // 選択中の文字をハイライト表示（例：黄色）
        for (int i = 0; i < optionTexts.Length; i++)
        {
            optionTexts[i].color = (i == confirmIndex) ? Color.yellow : Color.white;
        }
    }

    void CancelConfirm()
    {
        isConfirming = false;
        confirmUI.SetActive(false);
    }

    void LoadStage()
    {
        if (index < stageSceneNames.Length && !string.IsNullOrEmpty(stageSceneNames[index]))
        {
            SceneManager.LoadScene(stageSceneNames[index]);
        }
    }
}
