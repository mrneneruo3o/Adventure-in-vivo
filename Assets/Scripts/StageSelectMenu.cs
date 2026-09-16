using UnityEngine;

public class StageSelectMenu : MonoBehaviour
{
    public GameObject confirmPanel;               // 確認パネル
    public ConfirmUIController confirmController; // 確認UI制御
    public string[] stageSceneNames;              // 遷移するシーン名

    private int index = 0;
    private int max;
    private GameObject[] pages;

    void Start()
    {
        max = transform.childCount; //アタッチされたオブジェクトのtransformコンポーネントのchildCount
        pages = new GameObject[max]; //配列を作りObject型の配列変数pagesに入れる。要素数はmax個。


        for (int i = 0; i < max; i++)　//int型(整数)のiを0からmaxを超えるまで1ずつ増やして以下の処理を繰り返す
            pages[i] = transform.GetChild(i).gameObject; //変数pagesにi番目の子のゲームオブジェクトを代入する

        //forの変わりに使える配列・リストに使える繰り返し文
        //pages配列から1つずつ取り出して、SetActiveをfalseにする
        foreach (var p in pages) p.SetActive(false);

        //pagesの0番目(=先頭）を有効化する
        pages[index].SetActive(true);

        //confirmPanelを無効化する
        confirmPanel.SetActive(false);
    }

    void Update()
    {
        //confirmPanelがActiveなら処理を抜ける
        if (confirmPanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            ChangePage(1);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ChangePage(-1);

        if (Input.GetKeyDown(KeyCode.Return))
            OpenConfirm();
    }

    void ChangePage(int dir)
    {
        //index番目のステージ選択画面を無効化する。indexには引数dirを足す。
        pages[index].SetActive(false);
        index += dir;

        //1週したらまた戻る仕組み
        //indexがmax以上ならｍindexを0に戻す
        if (index >= max) index = 0;
        //indexが0より小さいならmax-1にする。
        if (index < 0) index = max - 1;

        //index番目のステージ選択画面を有効化する
        pages[index].SetActive(true);
    }

    void OpenConfirm()
    {
        //confirmPanelを有効化する
        confirmPanel.SetActive(true);
        //confirmControllerのOpenConfirmメソッドを呼び出す。引数には、stageSceneNamesに格納したindex番目を代入する。
        confirmController.OpenConfirm(stageSceneNames[index]);
    }
}
