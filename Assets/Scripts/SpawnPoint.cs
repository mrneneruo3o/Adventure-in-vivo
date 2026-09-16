using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Bulletのプレハブを呼び出す
    public GameObject misairuPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Instantiate(misairuPrefab, transform.position, Quaternion.identity);
        }

    }
}
