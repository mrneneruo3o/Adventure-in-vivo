using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //BOSSのHPを20に設定する
    public int HP = 20;

    //test ボスにやられたアニメーションをつける
    private Animator animator;

    //移動速度
    //[SerializeField] float downSpeed = 5;
    [SerializeField] float verticalSpeed = 2; // 上下移動スピード

    [SerializeField] float stopX = 7f;            // 左に進んで止まる位置
    [SerializeField] float topY = 4f;             // 上限
    [SerializeField] float bottomY = -4f;         // 下限

    //ボスが倒れたフラグ
    private bool boss_Down = false;
    private bool moveDown = true; // trueなら下方向へ動く

    //効果音1 やられた
    public AudioClip sound1;
    AudioSource audioSource;


    //ボスの行動パターン
    public enum ActionPattern
    {
        Appear, //出現
        Wait   //待機
    }

    //現在の行動パターン
    private ActionPattern currentAction;

    // Start is called before the first frame update
    void Start()
    {
        //test ボスにやられたアニメーションをつける
        animator = GetComponent<Animator>();

        //効果音を取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss_Down)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 5);
            return;
        }

        //ボスの行動パターンを切り替える
        switch (currentAction)
        { 
            case ActionPattern.Appear:
                UpdateAppearAction();
                break;
            case ActionPattern.Wait:
                UpdateWaiteAction();
                break;
        }

    }

    //出現パターンですること
    private void UpdateAppearAction()
    {
        //左へ進む
        Move(Vector2.left);

        /*//指定の位置まで移動したら待機パターンに切り替える
        if (transform.position.x <= 7f)
        {
            currentAction = ActionPattern.Wait;
        }*/
        // X座標が指定位置に達したら停止して待機モードへ
        if (transform.position.x <= stopX)
        {
            transform.position = new Vector3(stopX, transform.position.y, transform.position.z);
            currentAction = ActionPattern.Wait;
        }

    }

    private void Move(Vector3 moveDirection)
    {
        //ボスの座標を取得
        var pos = transform.position;

        //移動速度
        var movespeed = 5;

        //移動速度と方向から移動値を現在値に加える
        pos += moveDirection * movespeed * Time.deltaTime;

        //ボスの位置の更新
        transform.position = pos;
    }

    private void UpdateWaiteAction()
    {
        // 現在の移動方向に応じて上下に移動
        if (moveDown)
        {
            transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
            if (transform.position.y <= bottomY)
            {
                moveDown = false;
            }
        }
        else
        {
            transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
            if (transform.position.y >= topY)
            {
                moveDown = true;
            }
        }
    }


    //爆発エフェクトを呼び出す
    public GameObject Effect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //出現中は当たり判定をしないようにする
        if (currentAction == ActionPattern.Appear)
        {
            return;
        }

        //衝突する相手のレイヤー名を取得
        var LayerName = LayerMask.LayerToName(col.gameObject.layer);

        //Misairuというレイヤー名のオブジェクトとの当たり判定を処理
        if (LayerName == "Misairu")
        {
            //ボスのHPを1ずつ減らす
            HP -= 1;

            //test bossの体表に爆発エフェクトを出したい
            //自分の位置に爆発エフェクトを表示する
            //Instantiate(Effect, transform.position, Quaternion.identity);
            Instantiate(Effect, Misairu.explorepos, Quaternion.identity);

            //ボスのHPが0になったらオブジェクトを消す
            if (HP == 0)
            {
                //test ボスにやられたアニメーションをつける
                // ダウンアニメーション再生
                animator.SetTrigger("IsDown");
                //Destroy(this.gameObject); //test ボスにやられたアニメーションをつける

                //スコアを増やす
                //条件達成されたらtextにアタッチされているスクリプトの点数が実行される
                GameObject.Find("Text").GetComponent<ScoreCounter>().AddScoreBoss();

            }
        }

     }

    //test ボスにやられたアニメーションをつける
    public void OnAnimaionFinish()
    {

        boss_Down = true;  //bossが倒れたフラグを立てる

        //GameClearフラグをたてる
        //GameManagerにgameclearFlag
        GameManager.gameclearFlag = true;

        //音(sound1)を鳴らす
        audioSource.PlayOneShot(sound1);


    }

}
