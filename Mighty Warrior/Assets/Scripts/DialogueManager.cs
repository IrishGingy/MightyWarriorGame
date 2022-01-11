using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueScreen;
    public Text nameText;
    public Text dialogueText;

    //private Queue<string> sentences;
    //private Dictionary<string, string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        //sentences = new Dictionary<string, string>();
        dialogueScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.names[0];
        dialogueScreen.SetActive(true);

        //sentences.Clear();

        /*foreach(string sentence in dialogue.sentences)
        {
            sentences.Add(sentence);
        }*/

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        /*if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }*/

        //string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        dialogueScreen.SetActive(false);
    }
}