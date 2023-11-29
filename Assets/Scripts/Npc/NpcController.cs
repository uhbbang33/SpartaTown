using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _npcName;
    public TextMeshProUGUI NpcName { get { return _npcName; } }

    [SerializeField] string _dialogueData;
    public string DialogueData { get { return _dialogueData; } }
    //[SerializeField] NpcDialogueData _dialogueData;
    //public NpcDialogueData DialogueData {  get { return _dialogueData; } }

    void Start()
    {
        //SpriteRenderer _npcSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //_npcSpriteRenderer.sprite = Random

    }
}
