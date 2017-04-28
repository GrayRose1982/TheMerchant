using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainItemFocusToCraft : MonoBehaviour
{
	public ItemInCraftShop itemWantCraft;
	public ItemInCraftShop[] IngredientItems;

	public GameObject btnMakeItem;

	private Forge f;

	private string _item;

	public string item {
		set {
			_item = value; 
			itemWantCraft.itemString = _item;
			ChangeItemIngredient ();
		}
		get { return _item; }
	}

	void ChangeItemIngredient ()
	{
		f = LoadForge.data.GetForge (_item);
		if (f == null)
			return;

	    for (int i = 0; i < f.idIngres.Length; i++)
	    {
            IngredientItems[i].itemString = f.idIngres[i];
            IngredientItems[i].number = f.numbers[i];
	        
	    }

		SetButtonMakeItem ();
	}

	public void btn_MakeItem ()
	{
		bool canCraft = CraftShopControllNew.craftShop.MakeNewItem (item);

		if (canCraft)
			foreach (ItemInCraftShop i in IngredientItems) {
				if (i.itemString != null && i.itemString.CompareTo ("") != 0)
					Inventory.i.TakeItem (i.itemString, i.number);
			}

		SetButtonMakeItem ();
	}

	void SetButtonMakeItem ()
	{
		bool canCraft = true;

		for (int i = 0; i < IngredientItems.Length; i++)
			canCraft &= IngredientItems [i].isEnoughtNumber;

		btnMakeItem.SetActive (canCraft);
	}
}
