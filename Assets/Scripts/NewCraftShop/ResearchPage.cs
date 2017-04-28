using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchPage : MonoBehaviour
{
    public static ResearchPage p;

    public ItemSlotInInventory[] itemUseToCraft;
    public InventoryUI uiInvntory;
    public GameObject ResearchSuccess;
    public ItemInCraftShop[] itemCrafts;
    void Start()
    {
        p = this;
    }

    public bool AddItem(ShadowItem s)
    {
        bool wasAdd = false;
        for (int i = 0; i < itemUseToCraft.Length; i++)
        {
            if (itemUseToCraft[i].item != null && itemUseToCraft[i].item.idItem.CompareTo(s.idItem) == 0)
            {
                wasAdd = true;
                itemUseToCraft[i].item.number++;
                itemUseToCraft[i].ChangeInformationByShadow();
                break;
            }
        }

        if (!wasAdd)
            for (int i = 0; i < itemUseToCraft.Length; i++)
                if (itemUseToCraft[i].item == null || itemUseToCraft[i].item.idItem.CompareTo("") == 0)
                {
                    wasAdd = true;
                    itemUseToCraft[i].item = new ShadowItem(s);
                    itemUseToCraft[i].item.number = 1;
                    itemUseToCraft[i].ChangeInformationByShadow();

                    break;
                }

        return wasAdd;
    }

    public void btn_Research()
    {
        ShadowItem[] shadowItems = new ShadowItem[itemUseToCraft.Length];
        for (int i = 0; i < itemUseToCraft.Length; i++)
            if (itemUseToCraft[i].item != null)
                shadowItems[i] = itemUseToCraft[i].item;

        List<Forge> newItemForges = new List<Forge>();
        LoadForge.data.GetForgeCanLoad(ref newItemForges, shadowItems);

        for (int i = 0; i < itemCrafts.Length; i++)
            if (i < newItemForges.Count)
                itemCrafts[i].itemString = newItemForges[i].idItemCraft;
            else
                itemCrafts[i].itemString = null;

        ResearchSuccess.SetActive(true);

        foreach (ShadowItem shadow in shadowItems)
            if (shadow!=null)
            Inventory.i.TakeItem(shadow.idItem, shadow.number);

        foreach (ItemSlotInInventory item in itemUseToCraft)
        {
            item.item = null;
        }
        //for (int i = 0; i < newItemForges.Count; i++)
        //Debug.Log(newItemForges[i].idItemCraft);
    }
}
