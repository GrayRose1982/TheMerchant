using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slot;

    public List<ItemSlotInInventory> slots;

    private void OnEnable()
    {
        Inventory.updateAction += UpdateItem;
    }

    private void OnDisable()
    {
        Inventory.updateAction -= UpdateItem;
    }

    public void UpdateItem()
    {
        List<ShadowItem> shadowItems = Inventory.i.GetAllItem();
        for (int i = 0; i < shadowItems.Count; i++)
                slots[i].item = shadowItems[i];

        if (shadowItems.Count < slots.Count)
            for (int i = shadowItems.Count; i < slots.Count; i++)
                slots[i].item = null;
    }


    public void AddItem(ShadowItem shadow)
    {
        foreach (ItemSlotInInventory s in slots)
        {
            if (shadow != null && s.item != null)
                if (s.item.idItem.CompareTo(shadow.idItem) == 0)
                {
                    s.item.number += shadow.number;
                    s.ChangeInformationByShadow();
                }
        }
    }
}
