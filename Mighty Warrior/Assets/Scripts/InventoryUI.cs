using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public Camera cam;

    [SerializeField] Image previewImage;

    Inventory inventory;
    bool camLook;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        // Disables inventory UI on start.
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
        }

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        camLook = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (inventoryUI.activeSelf == false)
            {
                previewImage.sprite = null;
                previewImage.enabled = false;
            }

            if (camLook)
            {
                cam.GetComponent<FirstPersonLook>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                camLook = false;
            }
            else
            {
                cam.GetComponent<FirstPersonLook>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                camLook = true;
            }
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("UPDATING UI");
    }

}
