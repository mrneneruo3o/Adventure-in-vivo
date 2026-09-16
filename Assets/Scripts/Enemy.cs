using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
//using static UnityEditor.PlayerSettings;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //左へ進む
        Move(Vector2.left);

        //画面外に出たらオブジェクトを削除
        if (transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }

    //ザコ敵の移動
    private void Move(Vector3 moveDirection)
    {
        //ザコ敵の座標を取得
        var pos = transform.position;

        //移動速度
        var moveSpeed = 3;

        //移動速度と方向から移動値と現在値に加える
        pos += moveDirection * moveSpeed * Time.deltaTime;

        //ザコ敵の位置更新
        transform.position = pos;
    }

    //爆発エフェクトを呼び出す
    public GameObject Effect;

    //Collider2Dが設定されたオブジェクトと衝突したときに何が起きるか
    private void OnTriggerEnter2D(Collider2D col)
    {
        //衝突する相手のレイヤー名を取得
        var LayerName = LayerMask.LayerToName(col.gameObject.layer);

        //Enemyというレイヤー名のオブジェクトと衝突したら消える
        if (LayerName == "Misairu")
        {
            Destroy(this.gameObject);

            //ザコ敵の倒した数をプラスしGameManagerに送る
            GameManager.DefeatCount++;

            //スコアを増やす
            //条件達成されたらtextにアタッチされているスクリプトの点数が実行される
            GameObject.Find("Text").GetComponent<ScoreCounter>().AddScoreEnemy();

            //自分の位置に爆発エフェクトを表示する
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }

}
