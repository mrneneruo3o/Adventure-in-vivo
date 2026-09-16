using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewDialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    public List<DialogueEntry> sentences; // `string` Å® `DialogueEntry` Ç…ïœçXÅI
}