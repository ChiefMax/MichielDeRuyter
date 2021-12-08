using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu]
public class DialogueScriptableObj : ScriptableObject
{
    public string chapter;
    [TextArea(3, 12)]
    public string[] dialogueText;

    public Texture[] imagesInUI;

}
