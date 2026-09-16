using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 2.Scene関係の処理を行うときに必要なライブラリ
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
    
}
