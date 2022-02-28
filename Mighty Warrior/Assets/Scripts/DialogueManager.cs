using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject choiceParent;
    [SerializeField] private Button[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private int numChoices;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene!");
        }
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choiceParent.SetActive(false);

        // Get all of the choices and their text.
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (Button choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        // Return if dialogue is not playing.
        if (dialogueIsPlaying != true)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if(numChoices > 0)
            {
                dialogueText.enabled = false;
                choiceParent.SetActive(true);
                choices[0].Select();
            }
            else
            {
                ContinueStory();
                choiceParent.SetActive(false);
                dialogueText.enabled = true;
            }

        }

        /*// If player presses continue buttons, story is continued.
            if (currentStory.currentChoices.Count == 0 && (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.E)))
        {
            ContinueStory();
        }
        if (currentStory.currentChoices.Count != 0 && (Input.GetKeyUp(KeyCode.E)))
        {

        }*/
    }

    public void StartDialogue(TextAsset json)
    {
        currentStory = new Story(json.text);
        dialoguePanel.SetActive(true);
        dialogueIsPlaying = true;
        ContinueStory();

        //Debug.Log(json.text);
    }

    private void ContinueStory(bool continueAfterChoice = false)
    {
        if (continueAfterChoice == false)
        {
            if (currentStory.canContinue)
            {
                // set text for the current dialogue line.
                dialogueText.text = currentStory.Continue();
                // display choices, if any, for this dialogue line.
                DisplayChoices();
            }
            else
            {
                ExitDialogue();
            }
        }
        else
        {
            if (currentStory.canContinue)
            {
                // set text for the current dialogue line.
                dialogueText.text = currentStory.Continue();
                // display choices, if any, for this dialogue line.
                DisplayChoices();
            }
            else
            {
                ExitDialogue();
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        numChoices = currentChoices.Count;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initilize the choices up to the amount of choices for this line of dialogue.
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through remaining choices the UI supports and make sure they're hidden.
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    public void OnClickChoiceButton(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory(true);
        choiceParent.SetActive(false);
        dialogueText.enabled = true;
    }

    private void ExitDialogue()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    /*public GameObject dialogueScreen;
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

        *//*foreach(string sentence in dialogue.sentences)
        {
            sentences.Add(sentence);
        }*//*

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        *//*if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }*//*

        //string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        dialogueScreen.SetActive(false);
    }*/
}
