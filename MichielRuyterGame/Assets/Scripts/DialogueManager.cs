using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public RawImage imageToDisplay;
    public Queue<Texture> rawImages = new Queue<Texture>();

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

        foreach ( Texture texture in show.textures) 
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
            return;
        }



        string sentence = sentences.Dequeue();
        Texture texture = rawImages.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
        imageToDisplay.texture = texture;
        //foreach (var image in rawImages)
        //{
        //    if (sentences.Count == rawImages.Count)
        //    {
        //        Debug.Log("sentences count: " + sentences.Count + "raw image texture count: " + rawImages.Count);
        //        imageToDisplay.texture = image;
        //    }
        //}
    }

    void EndDialogue() 
    {
        Debug.Log("Done talking.");
    }
}
