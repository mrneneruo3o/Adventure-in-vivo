using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //スクロールのスピード
    public float scrollspeed;

    //背景を配置する間隔
    public float bgInterval;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //左に少しずつ移動させる
        var nextPosX = transform.position.x - (scrollspeed * Time.deltaTime);
        transform.position = new Vector2(nextPosX, 0);

        //画面外の左側まできたら右側に移動させる
        if(transform.position.x <= -bgInterval)
        {
            transform.position = new Vector2(bgInterval, 0);
        }
        
    }
}
