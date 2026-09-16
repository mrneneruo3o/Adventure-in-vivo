using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_spawnpoint : MonoBehaviour
{
    public GameObject BossmisairuPrefab;
    public AudioClip sound;
    public float bossmisairuInterval = 2f;  // ‰½•b‚²‚Æ‚É”­ŽË‚·‚é‚©
    private float timer = 0f;

    //ƒeƒXƒg
    private float misairuCount = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= bossmisairuInterval)
        {
            Fire();

            timer = 0f;
        }

    }

    void Fire()
    {
        Instantiate(BossmisairuPrefab,transform.position, Quaternion.identity);
        misairuCount++;
        Debug.Log(misairuCount);

    }
}
