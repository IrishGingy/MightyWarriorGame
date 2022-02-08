using UnityEngine;
using UnityEngine.UI;

public class HelpText : MonoBehaviour
{
    public Text helpText;

    // Start is called before the first frame update
    void Start()
    {
        helpText.enabled = false;
    }

    public void Display(string ht)
    {
        helpText.text = ht;
        helpText.enabled = true;
    }
}
