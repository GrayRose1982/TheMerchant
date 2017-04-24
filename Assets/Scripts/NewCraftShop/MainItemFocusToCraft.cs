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
		
		IngredientItems [0].itemString = f.idIngre1;
		IngredientItems [1].itemString = f.idIngre2;
		IngredientItems [2].itemString = f.idIngre3;
		IngredientItems [3].itemString = f.idIngre4;

		IngredientItems [0].number = f.numIngre1;
		IngredientItems [1].number = f.numIngre2;
		IngredientItems [2].number = f.numIngre3;
		IngredientItems [3].number = f.numIngre4;

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
