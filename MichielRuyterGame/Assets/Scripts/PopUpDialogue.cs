using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDialogue : MonoBehaviour
{
    public bool showCanvas;

    public GameObject Option1;
    public GameObject Option2;

    public GameObject canvas;

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
