using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupManager : MonoBehaviour
{
    public int currentlyEquippedHandheld = -1;
    public GameObject currentHandheldObject = null;
    public GameObject HandheldHolderR = null; 
    public float interactDistance = 5f;

    private bool holdingObject = false;
    private Animator anim;
    private Inventory inventory;
    private bool pressed = false;

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
        if (Input.GetKey(KeyCode.Tab))
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

        if (Input.GetKey(KeyCode.E))
        {
            pressed = true;
        }
    }

    void FixedUpdate()
    {
        if (pressed)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                Debug.Log(hit.distance);
                PickUp(hit);
            }
            else
            {
                Debug.Log(hit.distance);
                Debug.Log("aksdflasd");
            }
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

    private void PickUp(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Note"))
        {
            Debug.Log("NIce");
        }
        switch (hit.collider.tag)
        {
            case "Note":
                Debug.Log("Picked up note.");
                break;
            default:
                Debug.Log("Nothing");
                break;
        }
    }
}
