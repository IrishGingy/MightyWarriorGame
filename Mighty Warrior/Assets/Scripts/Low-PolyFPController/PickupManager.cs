using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private int currentlyEquippedHandheld = 0;
    private GameObject currentHandheldObject = null;

    [SerializeField] private Transform HandheldHolderR = null;
    private Animator anim;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("You just pressed tab...");
            UnequipHandheld();
            EquipHandheld(inventory.GetItem(HandheldType.Phone));
        }
    }

    private void EquipHandheld(Handheld handheld)
    {
        currentlyEquippedHandheld = (int)handheld.handheldType;
        anim.SetInteger("handheldType", (int)handheld.handheldType);
        currentHandheldObject = Instantiate(handheld.prefab, HandheldHolderR);
    }

    private void UnequipHandheld()
    {
        anim.SetTrigger("unequipHandheld");
        Destroy(currentHandheldObject);
    }

    private void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = Inventory.instance;
    }
}
