using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

// Resource: https://www.youtube.com/watch?v=5JAYjmkreyw
public class StoryControl : MonoBehaviour
{
    //public static event Action<Story> OnCreateStory;

    [SerializeField]
    private TextAsset inkStory;

    public Story story;

    public TextMeshProUGUI storyText;
    public Button[] buttons;
    public TextMeshProUGUI[] buttonText;
    
    // Start is called before the first frame update
    void Start()
    {
        // Good for testing.
        StartStory();
    }

    void StartStory()
    {
        story = new Story(inkStory.text);
        UpdateStory();
    }

    void UpdateStory()
    {
        if (story != null)
        {
            int temp = 0;
            string currentStory = "";
            while (story.canContinue && temp < 100)
            {
                story.Continue();
                temp++;
                currentStory += story.currentText;
                storyText.text = currentStory;
                if (temp > 99)
                {
                    Debug.Log("Temp is greater than 99: " + temp);
                }
            }
        }
        if (story.currentChoices.Count > 0)
        {
            MakeChoices();
        }
        else
        {
            //buttonText[0].text = "Restart";
            Debug.Log("Story complete");
        }
    }

    void CreateContentView()
    {

    }

    public void Choice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        UpdateStory();
    }

    void MakeChoices()
    {
        for (int i = 0; i < buttonText.Length; i++)
        {
            if (i < story.currentChoices.Count)
            {
                buttons[i].gameObject.SetActive(true);
                buttonText[i].text = story.currentChoices[i].text;
            }
            else
            {
                buttonText[i].text = "";
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
