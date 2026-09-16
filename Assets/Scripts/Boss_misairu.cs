using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_misairu : MonoBehaviour
{
    //変数
    //test bossの体表に爆発エフェクトを出したい
    public static Vector3 explorepos;

    public GameObject Effect_Bossmisairu;

    //爆発エフェクトを呼び出す
    public GameObject Effect;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //左へ進む
        //Vector2は勝手にVector3に変換される
        Move(Vector2.left);


        //画面外に出たらオブジェクトを削除
        if (transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }

    }

    private void Move(Vector3 moveDirection)
    {
        //ミサイルの座標を取得
        var pos = transform.position;

        //移動速度
        var moveSpeed = 5;

        //移動速度と方向から移動値と現在値に加える
        pos += moveDirection * moveSpeed * Time.deltaTime;

        //ザコ敵の位置更新
        transform.position = pos;

    }

    //Collider2Dが設定されたオブジェクトと衝突したときに何が起きるか
    private void OnTriggerEnter2D(Collider2D col)
    {
        //test bossの体表に爆発エフェクトを出したい
        explorepos = transform.position;

        //衝突する相手のレイヤー名を取得
        var LayerName = LayerMask.LayerToName(col.gameObject.layer);

        //Misairuというレイヤー名のオブジェクトと衝突したら消える
        if (LayerName == "Misairu")
        {
            Destroy(this.gameObject);
        }

        //自分の位置に爆発エフェクトを表示する
        Instantiate(Effect, transform.position, Quaternion.identity);


    }

}
