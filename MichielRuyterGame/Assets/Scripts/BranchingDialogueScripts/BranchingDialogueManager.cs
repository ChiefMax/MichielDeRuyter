using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BranchingDialogueManager : MonoBehaviour
{

    public DialogueScriptableObj[] scriptableObj;

    //public TMP_Text nameText;
    //public TMP_Text dialogueText;

    //public RawImage imageToDisplay;
    //public Queue<Texture> rawImages = new Queue<Texture>();

    //public GameObject CanvasItem;

    //private Queue<string> sentences;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    sentences = new Queue<string>();
    //}

    //public void StartDialogue(/*DialogueScriptableObj scriptableObj*/)
    //{
    //    //Debug.Log("Starting convo with " + dialogue.name);
    //    nameText.text = scriptableObj[0].chapter;

    //    sentences.Clear();
    //    rawImages.Clear();

    //    foreach (string sentence in scriptableObj[0].dialogueText)
    //    {
    //        sentences.Enqueue(sentence);
    //    }

    //    foreach (Texture texture in scriptableObj[0].imagesInUI)
    //    {
    //        rawImages.Enqueue(texture);
    //    }

    //    DisplayNextSentence();
    //}

    //public void DisplayNextSentence()
    //{
    //    if (sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        CanvasItem.SetActive(false);
    //        return;
    //    }

    //    string sentence = sentences.Dequeue();
    //    //Texture texture = rawImages.Dequeue();
    //    //Debug.Log(sentence);
    //    dialogueText.text = sentence;
    //    //imageToDisplay.texture = texture;
    //}

    //void EndDialogue()
    //{
    //    Debug.Log("Done talking.");
    //}
}
