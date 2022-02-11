using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New HelpText", menuName = "HelpText")]
public class HelpText : ScriptableObject
{
    [TextArea]
    public string text;

    public Sprite icon = null;
    public Color color = Color.yellow;
}
