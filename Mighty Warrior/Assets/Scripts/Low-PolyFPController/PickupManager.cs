using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupManager : MonoBehaviour
{
    public int currentlyEquippedHandheld = -1;
    public GameObject currentHandheldObject = null;
    public GameObject HandheldHolderR = null;

    private bool holdingObject = false;
    private Animator anim;
    private Inventory inventory;
    private Keyboard keyboard;

    // Dialogue
    [Header("Dialogue")]
    [SerializeField] private DialogueTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
        InitVariables();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard.tabKey.isPressed)
        {
            Debug.Log("You just pressed tab...");
            trigger.TriggerDialogue();

            if (currentHandheldObject != null)
            {
                UnequipHandheld();
                //EquipHandheld(inventory.GetItem(HandheldType.Phone));
                holdingObject = false;
            }
            else
            {
                EquipHandheld(inventory.GetItem(HandheldType.Phone));
                holdingObject = true;
            }
            //UnequipHandheld();
        }
    }

    private void EquipHandheld(Handheld handheld)
    {
        currentlyEquippedHandheld = (int)handheld.handheldType;
        anim.SetInteger("handheldType", currentlyEquippedHandheld);
        //currentHandheldObject = Instantiate(handheld.prefab, HandheldHolderR.transform);
        //SetLayer(currentHandheldObject, HandheldHolderR.layer, true);
    }

    private void UnequipHandheld()
    {
        anim.SetTrigger("unequipHandheld");
        anim.SetInteger("handheldType", -1);
        //Destroy(currentHandheldObject);
    }

    private void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetInteger("handheldType", -1);
        inventory = Inventory.instance;
    }

    private void InitVariables()
    {

    }
}
