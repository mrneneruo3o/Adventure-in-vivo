using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
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

    //障害物の移動
    private void Move(Vector3 moveDirection)
    {
        //障害物の座標を取得
        var pos = transform.position;

        //移動速度
        var moveSpeed = 2;

        //移動速度と方向から移動値と現在値に加える
        pos += moveDirection * moveSpeed * Time.deltaTime;

        //障害物の位置更新
        transform.position = pos;

    }
}
