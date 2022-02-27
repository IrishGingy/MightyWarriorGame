using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private Inventory inventory;
    private PickupManager manager;

    private void Start()
    {
        GetReferences();
    }

    public void DestroyHandheld()
    {
        Destroy(manager.currentHandheldObject);
    }

    public void InstantiateHandheld()
    {
        manager.currentHandheldObject = Instantiate(inventory.GetItem(HandheldType.Phone).prefab, manager.HandheldHolderR.transform);
        SetLayer(manager.currentHandheldObject, manager.HandheldHolderR.layer, true);
    }

    private void GetReferences()
    {
        inventory = Inventory.instance;
        manager = GetComponentInParent<PickupManager>();
    }

    public void SetLayer(GameObject gameObject, int layer, bool includeChildren = false)
    {
        if (!gameObject) return;
        if (!includeChildren)
        {
            gameObject.layer = layer;
            return;
        }

        foreach (var child in gameObject.GetComponentsInChildren(typeof(Transform), true))
        {
            child.gameObject.layer = layer;
        }
    }
}
