using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager2 : MonoBehaviour
{
    private int index = 0;
    private int menuCount = 0;
    private GameObject[] menus;

    void Start()
    {
        // 子オブジェクト数を取得
        menuCount = transform.childCount;

        // 配列を用意
        menus = new GameObject[menuCount];

        // 子オブジェクトを配列に格納
        for (int i = 0; i < menuCount; i++)
        {
            menus[i] = transform.GetChild(i).gameObject;
        }

        // 全部非表示
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        // 最初のメニューを表示
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
    }

    void ChangeMenu(int direction)
    {
        // 現在のを非表示
        menus[index].SetActive(false);

        // インデックス更新
        index += direction;
        if (index >= menuCount) index = 0;
        if (index < 0) index = menuCount - 1;

        // 新しいメニューを表示
        menus[index].SetActive(true);
    }
}
