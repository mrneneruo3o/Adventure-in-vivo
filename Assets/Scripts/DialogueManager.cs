using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public Canvas dialogueCanvas; // 会話用のキャンバス
    public Text villagerText; // 村人のテキストフィールド
    public Text playerText; // プレイヤーのテキストフィールド

    private Queue<DialogueEntry> sentences; // セリフをキューで管理
    private bool isTalking = false;
    //private bool isVillagerSpeaking = true; // 交互に話すためのフラグ

    void Start()
    {
        /*
        sentences = new Queue<DialogueEntry>();
        dialogueCanvas.gameObject.SetActive(false); // 最初は非表示
        */
    }

    public void StartDialogue(DialogueData dialogueData) // ← public の dialogueData を削除
    {
        /*
        if (isTalking) return;

        isTalking = true;
        Time.timeScale = 0; // ゲームを一時停止

        sentences.Clear();

        foreach (var entry in dialogueData.sentences)
        {
            sentences.Enqueue(entry);
        }

        dialogueCanvas.gameObject.SetActive(true);
        DisplayNextSentence();
        */
    }

    public void DisplayNextSentence()
    {
        /*
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueEntry entry = sentences.Dequeue();

        if (entry.isVillagerSpeaking)
        {
            villagerText.text = entry.sentence;
            playerText.text = ""; // プレイヤーのテキストを非表示
        }
        else
        {
            playerText.text = entry.sentence;
            villagerText.text = ""; // 村人のテキストを非表示
        }
        */
    }

    public void EndDialogue()
    {
        /*
        dialogueCanvas.gameObject.SetActive(false);
        Time.timeScale = 1; // ゲーム再開
        isTalking = false;
        */
    }

    void Update()
    {   
        /*
        if (isTalking && Input.GetKeyDown(KeyCode.Return)) // Enterキーで次の文章へ
        {
            DisplayNextSentence();
        }
        */
    }
    public void Test()
    {
        Debug.Log("呼べたよ～");
    }
}