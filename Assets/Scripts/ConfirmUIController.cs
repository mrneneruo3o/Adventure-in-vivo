using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmUIController : MonoBehaviour
{
    public RectTransform cursor;
    public RectTransform[] options;   // Yes, No
    private int index = 0;            // 0 = Yes, 1 = No

    private string targetStage;

    public void OpenConfirm(string stageName)
    {
        targetStage = stageName;
        index = 0;
        UpdateCursor();
    }

    void Update()
    {
        if (!gameObject.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index = 0;
            UpdateCursor();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index = 1;
            UpdateCursor();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 0)
                SceneManager.LoadScene(targetStage); // Yes
            else
                gameObject.SetActive(false);         // No → メニューへ戻る
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    void UpdateCursor()
    {
        //カーソルのポジションは、option配列のindex番目のポジションにあわせる
        cursor.position = options[index].position;
    }
}
