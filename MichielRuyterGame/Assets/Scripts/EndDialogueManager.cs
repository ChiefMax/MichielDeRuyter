using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndDialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public RawImage imageToDisplay;
    public Queue<Texture> rawImages = new Queue<Texture>();

    public GameObject canvasItem;
    public GameObject quitButton;
    public GameObject nextSentenceButton;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, ImagesShow show)
    {
        //Debug.Log("Starting convo with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();
        rawImages.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (Texture texture in show.textures)
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
            quitButton.SetActive(true);
            nextSentenceButton.SetActive(false);
            return;
        }



        string sentence = sentences.Dequeue();
        Texture texture = rawImages.Dequeue();
        dialogueText.text = sentence;
        imageToDisplay.texture = texture;

    }

    void EndDialogue()
    {
        Debug.Log("Done talking.");
    }
}
