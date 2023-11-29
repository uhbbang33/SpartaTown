using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 쓰지 않는 script
[CreateAssetMenu(fileName ="NewNpcDialogueData")]
public class NpcDialogueData : ScriptableObject
{
    public List<string> dialogueLines = new List<string>();
}
