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
        {
            slots[i].item = shadowItems[i];
        }
    }

    public void AddItem(ShadowItem shadow)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item.idItem.CompareTo(shadow.idItem) == 0)
            {
                slots[i].item.number += shadow.number;
                slots[i].ChangeInformationByShadow();
            }
        }
    }

}
