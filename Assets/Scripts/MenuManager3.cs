using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ← シーン切り替え用

public class MenuManager3 : MonoBehaviour
{
    private int index = 0;
    private int menuCount = 0;
    private GameObject[] menus;

    // シーン名を設定（インスペクターで指定可能）
    public string[] stageSceneNames;

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeMenu(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeMenu(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Return)) // Enterキー
        {
            LoadStage();
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

    void LoadStage()
    {
        if (stageSceneNames.Length == 0)
        {
            Debug.LogWarning("ステージのシーン名が設定されていません。");
            return;
        }

        if (index < stageSceneNames.Length && !string.IsNullOrEmpty(stageSceneNames[index]))
        {
            Debug.Log($"ステージ「{stageSceneNames[index]}」をロードします");
            SceneManager.LoadScene(stageSceneNames[index]);
        }
        else
        {
            Debug.LogWarning($"インデックス {index} に対応するシーン名が設定されていません。");
        }
    }

    //void LoadMessage()
}
