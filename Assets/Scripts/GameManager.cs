using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public enum Wave
    {
        StartEvent, //開始時の会話イベント　20251203
        Block, // 1.障害物ウェーブ
        Enemy, // 2.ザコ敵ウェーブ
        Boss   // 3.ボスウェーブ
    }

    //BlockのPrefabを呼び出す
    public GameObject BlockPrefab;

    //避ける障害物の数
    public int BlockNums;

    //障害物の出現間隔
    public float BlockInterval;

    //EnemyのPrefabを呼び出す
    public GameObject EnemyPrefab;

    //倒すザコ敵の数
    public int EnemyNums;

    //ザコ敵の出現間隔
    public float EnemyInterval;

    //Bossのプレハブを呼び出す
    public GameObject BossPrefab;

    //ウエーブとウエーブの間の待ち時間
    public float WaveInterval;

    //現在のウエーブ
    //private Wave currentWave = Wave.Block;
    private Wave currentWave = Wave.StartEvent;


    //生成した数を数えるため
    private int spawnCount = 0;

    //出現時間を計算するため
    private float timeCount = 0.0f;

    //倒した敵の数を数える用
    //DefeatCountはEnemyスクリプトでカウント
    public static int DefeatCount = 0;

    //Gameover時に文字を出す
    public GameObject gameoverText;
　　
    //PlayerがGameover状態か判定
    public static bool gameoverFlag = false;

    //Gameover時に文字を出す
    public GameObject GameClearText;

    //Playerがgameclear状態か判定
    public static bool gameclearFlag = false;

    //会話イベント　20251203
    [SerializeField] public DialogueManager dialogueManager;


    private void Update()
    {
        //現在のウェーブによって処理を帰る
        switch (currentWave)
        {
            //会話イベント　20251203
            case Wave.StartEvent:
                UpdateStartEvent();
                break;

            case Wave.Block: //障害物
                UpdateBlockMove();
                break;

            case Wave.Enemy: //ザコ敵
                UpdateEnemyMove();
                break;

            case Wave Boss://ボス
                UpdateBossMove();
                break;
        }

        if(gameoverFlag == true)
        {
          //  public GameObject gameoverText;

        　　// GameOverテキストを呼び出す
        　　gameoverText.SetActive(true);
            Debug.Log("画面表示");

            if (Input.GetKey(KeyCode.Space))
            {   
                //最初からスタート
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //gameoverFlagはfalseへ
                gameoverFlag = false;
            }

        }

        if (gameclearFlag == true)
        {

            // GameClearテキストを呼び出す
            GameClearText.SetActive(true);

            //スタート画面へ戻る
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("Start");
            }



        }

    }

    //20251203
    void UpdateStartEvent()
    {
        //dialogueManager.StartDialogue();
        dialogueManager.Test();

    }

    void UpdateBlockMove()
    {
        //時間のカウント
        timeCount += Time.deltaTime;

        //出現数分作成が終わっているとき
        if (spawnCount >= BlockNums)
        {
            //ウェーブ待機時間が過ぎたら次のウェーブに進
            if (timeCount >= WaveInterval)
            {
                //時間のカウントと出現数をリセットする
                spawnCount = 0;
                timeCount = 0;

                //ザコ敵ウェーブへ
                currentWave = Wave.Enemy;
            }
        }
        else
        {
            //出現間隔時間を超えたら障害物をつくる
            if (timeCount >= BlockInterval)
            {
                //障害物生成
                Instantiate(BlockPrefab, new Vector3(10.0f, 0f, 0), Quaternion.identity);
                //出現した数に+1
                spawnCount++;

                //時間にカウントを0にリセットする
                timeCount = 0;
            }
        }
    }

    //ザコ敵ウェーブ
    void UpdateEnemyMove()
    {
        timeCount += Time.deltaTime;

        //指定の数を倒したとき
        if (DefeatCount >= EnemyNums)
        {
            //ウェーブ待機時間を過ぎたら次のウェーブに進
            if (timeCount >= WaveInterval)
            {
                //時間のカウントと出現数をリセットする
                DefeatCount = 0;
                timeCount = 0;
                //ボスウェーブへ
                currentWave = Wave.Boss;
            }
        }
        else if (timeCount >= EnemyInterval)
        {
            var randomPos = new Vector3(10.0f, Random.Range(-4.0f, 4.0f), 0);
            Instantiate(EnemyPrefab, randomPos, Quaternion.identity);

            timeCount = 0;
        }
    }

    //ボスウェーブ
    void UpdateBossMove()
    {
        //ボスはすぐに出てくるので時間のカウントをしない
        //ボスは1体だけでいいので出現数が0のときだけボスをつくる
        if(spawnCount == 0)
        {
            Instantiate(BossPrefab, new Vector3(15f, -0.5f, 0), Quaternion.identity);
            spawnCount++;
        }
    }
}
