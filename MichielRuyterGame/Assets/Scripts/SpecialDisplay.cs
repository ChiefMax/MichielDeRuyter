using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDisplay : MonoBehaviour
{
    public DialogueScriptableObj obj;

    public void SpecialDialogueTrigger()
    {
        FindObjectOfType<PopUpDialogue>().StartDialogue();
    }
}
