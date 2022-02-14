using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Awake()
    {
        gameObject.GetComponent<Button>().transform.position = new Vector3(0, gameObject.GetComponentInParent<RectTransform>().transform.position.y + 15f, 0);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TriggerDialogue();
        }
    }*/
}
