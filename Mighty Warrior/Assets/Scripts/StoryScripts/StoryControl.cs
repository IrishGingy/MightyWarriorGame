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


    // Start is called before the first frame update
    void Start()
    {
        // Good for testing.
        StartStory();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartStory()
    {
        story = new Story(inkStory.text);
        if (story != null)
        {
            /*int temp = 0;
            string currentStory = "";
            while (story.canContinue && temp < 100)
            {
                story.Continue();
                temp++;
                storyText.text = story.currentText;
                if (temp > 99)
                {
                    Debug.Log(temp);
                }
                *//*string text = story.Continue();
                text = text.Trim();
                CreateContentView();*//*
            }*/

            story.Continue();
            storyText.text = story.currentText;
            if (story.canContinue)
            {
                story.Continue();
                storyText.text = story.currentText;
            }
        }
    }

    void CreateContentView()
    {

    }

    public void Choice(int choiceIndex)
    {

    }
}
