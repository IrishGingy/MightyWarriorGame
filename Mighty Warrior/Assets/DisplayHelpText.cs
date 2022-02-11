using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHelpText : MonoBehaviour
{
    public HelpText helpText;

    Text scriptText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        scriptText = gameObject.GetComponent<Text>();
    }

    public void Display()
    {
        scriptText.text = helpText.text;
        gameObject.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
