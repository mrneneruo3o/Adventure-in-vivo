using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // ← これをつけると、Inspectorでリスト管理がしやすくなる！
public class DialogueEntry
{
    public string sentence; // セリフの文章
    public bool isVillagerSpeaking; // 村人が話すなら true、プレイヤーなら false

    public DialogueEntry(string sentence, bool isVillagerSpeaking)
    {
        this.sentence = sentence;
        this.isVillagerSpeaking = isVillagerSpeaking;
    }
}