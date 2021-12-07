using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpDialogue : MonoBehaviour
{
    private bool showCanvas;
    private bool showOp1 = false;
    private bool showOp2 = false;
    private bool showOp3 = false;
    private bool showOp4 = false;
    private bool showOp5 = false;
    private bool showOp6 = false;

    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;
    public GameObject Option5;
    public GameObject Option6;

    public GameObject Options1;
    public GameObject Options2;
    public GameObject Options3;

    private bool DialogueIsDone = true;

    public GameObject canvas;

    public BranchingDialogueManager branchingDialogue;
    public ShipAnim ship;

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
        else 
        {
            canvas.SetActive(false);
        }

        if (showOp1) 
        {
            nameText.text = branchingDialogue.scriptableObj[0].chapter;
            storySelect = 0;
            ShowOrHideOption();
            DialogueIsDone = false;
        }
        if (showOp2)
        {
            nameText.text = branchingDialogue.scriptableObj[1].chapter;
            storySelect = 1;
            ShowOrHideOption();
            DialogueIsDone = false;
        }
        if (showOp3) 
        {
            nameText.text = branchingDialogue.scriptableObj[2].chapter;
            storySelect = 2;
            ShowOrHideOption();
            DialogueIsDone = false;
        }
        if (showOp4)
        {
            nameText.text = branchingDialogue.scriptableObj[3].chapter;
            storySelect = 3;
            ShowOrHideOption();
            DialogueIsDone = false;
        }
        if (showOp5)
        {
            nameText.text = branchingDialogue.scriptableObj[4].chapter;
            storySelect = 4;
            ShowOrHideOption();
            DialogueIsDone = false;
        }
        if (showOp6)
        {
            nameText.text = branchingDialogue.scriptableObj[5].chapter;
            storySelect = 5;
            ShowOrHideOption();
            DialogueIsDone = false;
        }
    }

    public void StartDialogue()
    {
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
            DialogueIsDone = true;
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
        showCanvas = false;
        ship.BackToIdle();
        canvas.SetActive(false);
    }


    public void ShowOrHideOption() 
    {
        if (showOp1 || showOp2 && DialogueIsDone) 
        {
            Debug.Log("Correct one");
            Options1.SetActive(false);
            Options2.SetActive(true);
        }

        if (showOp3 || showOp4 && DialogueIsDone) 
        {
            Debug.Log("Wrong one");
            Options2.SetActive(false);
            Options3.SetActive(true);
        }

        //if (Option5 || Option6)
        //{
        //    Options2.SetActive(false);
        //}
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

        if (other.gameObject.tag == "Option3") 
        {
            showCanvas = true;
            showOp3 = true;
        }

        if (other.gameObject.tag == "Option4")
        {
            showCanvas = true;
            showOp4 = true;
        }

        if (other.gameObject.tag == "Option5")
        {
            showCanvas = true;
            showOp5 = true;
        }

        if (other.gameObject.tag == "Option6")
        {
            showCanvas = true;
            showOp6 = true;
        }
    }
}
