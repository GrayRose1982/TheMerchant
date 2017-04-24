using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchPage : MonoBehaviour
{
    public static ResearchPage p;

    public ItemSlotInInventory[] itemUseToCraft;
    public InventoryUI uiInvntory;
    void Start()
    {
        p = this;
    }

    public bool AddItem(ShadowItem s)
    {
        bool wasAdd = false;
        for (int i = 0; i < itemUseToCraft.Length; i++)
        {
            if (itemUseToCraft[i].item.idItem.CompareTo(s.idItem) == 0)
            {
                wasAdd = true;
                itemUseToCraft[i].item.number++;
                itemUseToCraft[i].ChangeInformationByShadow();
                break;
            }
        }

        if (!wasAdd)
            for (int i = 0; i < itemUseToCraft.Length; i++)
                if (itemUseToCraft[i].item.idItem.CompareTo("") == 0)
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

    }
}
