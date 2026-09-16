using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager4 : MonoBehaviour
{
    private int index = 0;
    private int menuCount = 0;
    private GameObject[] menus;

    public string[] stageSceneNames;   // シーン名配列
    public GameObject confirmUI;       // 確認メッセージのUI（Canvas内に用意）
    public Text confirmText;           // メッセージ表示用Text（またはTextMeshPro）

    private bool isConfirming = false; // 確認中フラグ

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
            // 確認中の入力処理
            if (Input.GetKeyDown(KeyCode.Return))
            {
                LoadStage();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                CancelConfirm();
            }
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

        if (confirmUI != null)
        {
            confirmUI.SetActive(true);
            if (confirmText != null)
                confirmText.text = "このステージで遊びますか？\nEnter：はい　Esc：いいえ";
        }
    }

    void CancelConfirm()
    {
        isConfirming = false;

        if (confirmUI != null)
            confirmUI.SetActive(false);
    }

    void LoadStage()
    {
        if (index < stageSceneNames.Length && !string.IsNullOrEmpty(stageSceneNames[index]))
        {
            SceneManager.LoadScene(stageSceneNames[index]);
        }
        else
        {
            Debug.LogWarning($"インデックス {index} に対応するシーン名が設定されていません。");
        }
    }
}
