using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Handheld Item", menuName = "Items/Handheld")]
public class Handheld : Item
{
    public GameObject prefab;
    public bool readable;
    public HandheldType handheldType;
}

public enum HandheldType { Phone, Note }