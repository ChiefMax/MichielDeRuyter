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

    public BranchingDialogueManager branchingDialogue;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public RawImage imageToDisplay;

    private Queue<string> sentences = new Queue<string>();
    public Queue<Texture> rawImages = new Queue<Texture>();

    private int storySelect;

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

        if (showOp1) 
        {
            nameText.text = branchingDialogue.scriptableObj[0].chapter;
            storySelect = 0;
        }
        if (showOp2)
        {
            nameText.text = branchingDialogue.scriptableObj[1].chapter;
            storySelect = 1;
        }
    }

    public void StartDialogue()
    {
        //if (sho) 
        //{

        //}
        nameText.text = branchingDialogue.scriptableObj[storySelect].chapter;

        sentences.Clear();
        rawImages.Clear();

        foreach (string sentence in branchingDialogue.scriptableObj[storySelect].dialogueText)
        {
            sentences.Enqueue(sentence);
        }

        foreach (Texture texture in branchingDialogue.scriptableObj[storySelect].imagesInUI)
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
            canvas.SetActive(false);
            return;
        }

        string sentence = sentences.Dequeue();
        //Texture texture = rawImages.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
        //imageToDisplay.texture = texture;
    }

    void EndDialogue()
    {
        Debug.Log("Done talking.");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Option1") 
        {
            showCanvas = true;
            showOp1 = true;
        }

        if (other.gameObject.tag == "Option2")
        {
            showCanvas = true;
            showOp2 = true;
        }
    }
}
