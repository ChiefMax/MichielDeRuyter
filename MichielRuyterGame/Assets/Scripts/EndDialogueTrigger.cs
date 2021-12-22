using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public ImagesShow texture;

    public void TriggerDialogue()
    {
        FindObjectOfType<EndDialogueManager>().StartDialogue(dialogue, texture);
    }
}
