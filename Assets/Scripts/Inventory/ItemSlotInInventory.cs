using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotInInventory : MonoBehaviour
{
    [SerializeField]
    string _idItem;
    [SerializeField]
    private ShadowItem _item;

    public Image imgIcon;
    public Text txtNumber;

    public string idItem
    {
        get { return _idItem; }
        set
        {
            _idItem = value;
            ChangeInformation();
        }
    }

    public ShadowItem item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (value != null)
                ChangeInformationByShadow();
            else
                ResetSlot();
        }
    }

    void OnEnable()
    {
        if (_item.idItem.CompareTo("") == 0)
            ResetSlot();
    }
    void ChangeInformation()
    {
        ShadowItem s = Inventory.i.GetItem(_idItem);
        imgIcon.color = Color.white;
        imgIcon.sprite = s.icon;
        txtNumber.text = s.number > 0 ? s.number.ToString() : "";
    }

   public void ChangeInformationByShadow()
    {
        imgIcon.color = Color.white;
        imgIcon.sprite = _item.icon;
        txtNumber.text = _item.number > 0 ? _item.number.ToString() : "";
    }

    void ResetSlot()
    {
        imgIcon.sprite = null;
        imgIcon.color = Color.clear;
        txtNumber.text = "";
    }

    public void btn_AddItemToResearch()
    {
        if(_item.number >0)
        if (ResearchPage.p.AddItem(_item))
            _item.number --;

        ChangeInformationByShadow();
    }

    public void btn_RemoveItemFromResearch()
    {
        ResearchPage.p.uiInvntory.AddItem(_item);
        item = null;
    }
}
