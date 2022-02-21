using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Handheld Item", menuName = "Items/Handheld")]
public class Handheld : Items
{
    public GameObject prefab;
    public bool readable;
    public HandheldType handheldType;
}

public enum HandheldType { Note, Phone }