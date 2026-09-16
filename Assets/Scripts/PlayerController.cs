using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var X = Input.GetAxisRaw("Horizontal");
        var Y = Input.GetAxisRaw("Vertical");
        var moveDirection = new Vector2(X, Y).normalized;
        Move(moveDirection);
    }

    private void Move(Vector3 moveDirection)
    {
        var pos = transform.position;
        var moveSpeed = 4;
        pos += moveDirection * moveSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -8.4f, 8.4f);
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);

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
        if (LayerName == "Enemy")
        {
            Destroy(this.gameObject);

            //自分の位置に爆発エフェクトを表示する
            Instantiate(Effect, transform.position, Quaternion.identity);

            //GameOverフラグをたてる
            //GameManagerにgameoverFlag
            GameManager.gameoverFlag = true;
            
        }
    }
}
