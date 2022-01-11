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

    private bool smokeEffect1 = false;
    private bool smokeEffect2 = false;

    private bool once1 = false;
    private bool once2 = false;
    private bool once3 = false;

    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;
    public GameObject Option5;
    public GameObject Option6;

    public GameObject resetButton;
    public GameObject nextSentenceButton;

    public GameObject LastSentence1;
    public GameObject LastSentence2;
    public GameObject LastSentence3;

    public GameObject Options1;
    public GameObject Options2;
    public GameObject Options3;

    public GameObject canvas;
    public GameObject endCanvas;

    public GameObject[] smokeEffectsEnemy;
    public GameObject smokeEffectsFriendly;

    public BranchingDialogueManager branchingDialogue;
    public ShipAnim ship;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public RawImage imageToDisplay;

    private Queue<string> sentences = new Queue<string>();

    private int storySelect;

    private int randomParent;
    private int randomChild;

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
            if (!once1) 
            {
                smokeEffectsFriendly.transform.GetChild(Random.Range(0, smokeEffectsFriendly.transform.childCount)).gameObject.SetActive(true);
                once1 = true;
            }
            LastSentence1.SetActive(false);
        }
        if (showOp2)
        {
            nameText.text = branchingDialogue.scriptableObj[1].chapter;
            storySelect = 1;
            LastSentence1.SetActive(false);
        }
        if (showOp3) 
        {
            nameText.text = branchingDialogue.scriptableObj[2].chapter;
            storySelect = 2;
            if (!once2) 
            {
                smokeEffectsFriendly.transform.GetChild(Random.Range(0, smokeEffectsFriendly.transform.childCount)).gameObject.SetActive(true);
                once2 = true;
            }
            LastSentence2.SetActive(false);
        }
        if (showOp4)
        {
            nameText.text = branchingDialogue.scriptableObj[3].chapter;
            storySelect = 3;
            if (!once3)
            {
                smokeEffectsFriendly.transform.GetChild(Random.Range(0, smokeEffectsFriendly.transform.childCount)).gameObject.SetActive(true);
                once3 = true;
            }
            LastSentence2.SetActive(false);
        }
        if (showOp5)
        {
            nameText.text = branchingDialogue.scriptableObj[4].chapter;
            storySelect = 4;
            if (!once3)
            {
                smokeEffectsFriendly.transform.GetChild(Random.Range(0, smokeEffectsFriendly.transform.childCount)).gameObject.SetActive(true);
                once3 = true;
            }
            LastSentence3.SetActive(false);
        }
        if (showOp6)
        {
            nameText.text = branchingDialogue.scriptableObj[5].chapter;
            storySelect = 5;
            if (!once3)
            {
                smokeEffectsFriendly.transform.GetChild(Random.Range(0, smokeEffectsFriendly.transform.childCount)).gameObject.SetActive(true);
                once3 = true;
            }
            LastSentence3.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        nameText.text = branchingDialogue.scriptableObj[storySelect].chapter;
        dialogueText.text = "";

        sentences.Clear();

        foreach (string sentence in branchingDialogue.scriptableObj[storySelect].dialogueText)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        randomChild = Random.Range(0, smokeEffectsEnemy[0].transform.childCount);
        if (sentences.Count == 0)
        {
            EndDialogue();
            canvas.SetActive(false);
            if (/*storySelect == 0 ||*/ storySelect == 1)
            {
                Options1.SetActive(false);
                Options2.SetActive(true);
                sentences.Clear();
                dialogueText.text = "";
                smokeEffect1 = true;
                LastSentence1.SetActive(false);
                LastSentence2.SetActive(true);
            }

            if (storySelect == 0) 
            {
                Options1.SetActive(false);
                Options3.SetActive(true);
                sentences.Clear();
                dialogueText.text = "";
                smokeEffect2 = true;
                LastSentence3.SetActive(true);
            }

            if (storySelect == 2 || storySelect == 3 && Options2.activeSelf)
            {
                Options2.SetActive(false);
                Options3.SetActive(false);
                sentences.Clear();
                dialogueText.text = "";
                smokeEffect2 = true;
                LastSentence3.SetActive(false);
                endCanvas.SetActive(true);
            }

            if (Options3.activeSelf && showOp5 || showOp6)
            {
                Debug.Log("Showing end canvas");
                endCanvas.SetActive(true);
                LastSentence3.SetActive(false);
            }
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        if (!smokeEffect1) 
        {
            smokeEffectsEnemy[0].transform.GetChild(randomChild).gameObject.SetActive(true);
        }

        if (!smokeEffect2 && smokeEffect1) 
        {
            smokeEffectsEnemy[1].transform.GetChild(randomChild).gameObject.SetActive(true);
        }

        if (smokeEffect1 && smokeEffect2) 
        {
            smokeEffectsEnemy[2].transform.GetChild(randomChild).gameObject.SetActive(true);
        }
        
    }

    void EndDialogue()
    {
        //Debug.Log("Done talking.");
        showCanvas = false;
        ship.BackToIdle();
        canvas.SetActive(false);
        sentences.Clear();
        resetButton.SetActive(true);
        nextSentenceButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Option1") 
        {
            showCanvas = true;
            showOp1 = true;
            ship.BackToIdle();
        }

        if (other.gameObject.tag == "Option2")
        {
            showCanvas = true;
            showOp2 = true;
            ship.BackToIdle();
        }

        if (other.gameObject.tag == "Option3") 
        {
            showCanvas = true;
            showOp3 = true;
            ship.BackToIdle();
        }

        if (other.gameObject.tag == "Option4")
        {
            showCanvas = true;
            showOp4 = true;
            ship.BackToIdle();
        }

        if (other.gameObject.tag == "Option5")
        {
            showCanvas = true;
            showOp5 = true;
            ship.BackToIdle();
        }

        if (other.gameObject.tag == "Option6")
        {
            showCanvas = true;
            showOp6 = true;
            ship.BackToIdle();
        }
    }
}
