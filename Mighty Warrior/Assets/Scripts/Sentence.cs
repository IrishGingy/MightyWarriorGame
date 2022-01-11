using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence : MonoBehaviour
{
    public string name;
    
    [TextArea]
    public string[] sentence;
}
