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

    public GameObject CanvasItem;
    public GameObject LastSentence1;

    public AudioSource BackgroundSound;
    public AudioSource Chatter;
    public AudioSource NavalBattle;
    public AudioSource WarSound;

    private Queue<string> sentences;

    private int counter = 0;

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
            CanvasItem.SetActive(false);
            LastSentence1.SetActive(true);
            BackgroundSound.Stop();
            Chatter.Stop();
            WarSound.Stop();
            NavalBattle.Play();
            return;
        }

        counter++;

        if (counter == 3) 
        {
            Debug.Log("Playing market chatter!");
            Chatter.Play();
        }

        if (counter == 8) 
        {
            Debug.Log("Playing war sounds!");
            BackgroundSound.Stop();
            Chatter.Stop();
            WarSound.Play();
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
