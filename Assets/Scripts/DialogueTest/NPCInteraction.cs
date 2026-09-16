using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject talkUI; // 「話す(T)」のUIオブジェクト
    public DialogueData dialogueData; // そのNPC専用のセリフデータ
    private DialogueManager dialogueManager;
    private bool canTalk = false; // 会話可能状態のフラグ

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // DialogueManager を見つけて取得
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // プレイヤーか確認
        {
            talkUI.SetActive(true);
            canTalk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talkUI.SetActive(false);
            canTalk = false;
        }
    }

    void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.T))
        {
            if (dialogueManager != null && dialogueData != null)
            {
                dialogueManager.StartDialogue(dialogueData); // ここでエラーが発生しないように修正！
            }
            else
            {
                Debug.LogWarning("DialogueManager または DialogueData が設定されていません！");
            }
        }
    }
}