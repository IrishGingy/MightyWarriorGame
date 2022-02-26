using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
        PreAdd();
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    [SerializeField] Handheld phone;

    private void PreAdd()
    {
        if (items != null)
        {
            Debug.Log("Inventory list is not null!");
            if (items.Count > 0)
            {
                Debug.Log("There's something in the inventory list.");
                List<Item> itemsToAdd = new List<Item>();
                /*foreach (Item i in items)
                {
                    itemsToAdd.Add(i);
                }
                foreach (Item i in itemsToAdd)
                {
                    instance.Add(i);
                }
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }*/
            }
            else
            {
                Debug.Log("There's nothing in the the inventory list.");
            }
        }
        else
        {
            Debug.Log("NULL Inventory list!");
        }
    }

    public bool Add(Item item)
    {
        /*if (item.isDefaultItem)
        {
            items.Add(item);
        }*/
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public Handheld GetItem(HandheldType type)
    {
        if (type == HandheldType.Phone)
        {
            return phone;
        }

        // Need to change to note later (but needs to be specific note).
        return phone;
    }
}
