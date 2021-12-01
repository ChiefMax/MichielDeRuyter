using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpDialogue : MonoBehaviour
{
    public bool showCanvas;
    public bool showOp1 = false;
    public bool showOp2 = false;

    public GameObject Option1;
    public GameObject Option2;

    public GameObject canvas;

    public DialogueScriptableObj scriptableObj;
    public DialogueDisplay dialogueDisplay;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public RawImage imageToDisplay;
    public GameObject CanvasItem;

    private Queue<string> sentences = new Queue<string>();
    public Queue<Texture> rawImages = new Queue<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showCanvas) 
        {
            canvas.SetActive(true);
        }
    }

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

        dialogueDisplay.DisplayNextSentence();
        //DisplayNextSentence();
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

    //void EndDialogue()
    //{
    //    Debug.Log("Done talking.");
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Option1") 
        {
            showCanvas = true;
        }

        if (other.gameObject.tag == "Option2")
        {
            showCanvas = true;
        }
    }
}
