using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    public DialogueScriptableObj scriptableObj;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public RawImage imageToDisplay;
    public GameObject CanvasItem;

    private Queue<string> sentences = new Queue<string>();
    public Queue<Texture> rawImages = new Queue<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Testing " + scriptableObj.chapter);
    }

    //public void DisplayNextSentence()
    //{
    //    if (sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        CanvasItem.SetActive(false);
    //        return;
    //    }



    //    string sentence = sentences.Dequeue();
    //    Texture texture = rawImages.Dequeue();
    //    //Debug.Log(sentence);
    //    dialogueText.text = sentence;
    //    imageToDisplay.texture = texture;
    //}


    public void StartDialogue(/*Dialogue dialogue, ImagesShow show*/)
    {
        //Debug.Log("Starting convo with " + dialogue.name);
        //nameText.text = dialogue.name;

        //scriptableObj.chapter = nameText.text;
        nameText.text = scriptableObj.chapter;

        sentences.Clear();
        rawImages.Clear();


        foreach (string sentence in scriptableObj.dialogueText)
        {
            sentences.Enqueue(sentence);
        }

        foreach (Texture texture in scriptableObj.imagesInUI)
        {
            rawImages.Enqueue(texture);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            CanvasItem.SetActive(false);
            return;
        }



        string sentence = sentences.Dequeue();
        Texture texture = rawImages.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
        imageToDisplay.texture = texture;
    }

    void EndDialogue()
    {
        Debug.Log("Done talking.");
    }
}
