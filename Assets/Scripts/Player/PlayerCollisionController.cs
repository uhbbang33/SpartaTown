using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            UIManager.Instance.ShowDialogueButtonPanel(true, collision.gameObject.GetComponentInParent<NpcController>().NpcName.text);
            UIManager.Instance.SetDialogueMessage(collision.gameObject.GetComponentInParent<NpcController>().DialogueData);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            UIManager.Instance.ShowDialogueButtonPanel(false, null);
        }
    }
}
