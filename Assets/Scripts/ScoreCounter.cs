using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIはこの行が必要

public class ScoreCounter : MonoBehaviour
{
    //スコアの初期値は0
    int score = 0;
    Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        //テキスト部分に「Score点数」と表示する点数の部分は可変
        this.textComponent = GameObject.Find("Text").GetComponent<Text>();
        this.textComponent.text = "Score" + score.ToString();
        
    }

    //ザコ敵を倒したら100点
    public void AddScoreEnemy()
    {
        this.score += 100;
        this.textComponent.text = "Score" + score.ToString();
    }

    //ボスを倒したら5000点
    public void AddScoreBoss()
    {
        this.score += 5000;
        this.textComponent.text = "Score" + score.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
