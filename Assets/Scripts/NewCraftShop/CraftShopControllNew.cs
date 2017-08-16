using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShopControllNew : MonoBehaviour
{
	public static CraftShopControllNew craftShop;

	public CraftShop csUse;

	[SerializeField] ItemCanCraft itemCanCraft;
	[SerializeField] MainItemFocusToCraft focus;
	//	[SerializeField] KindOfItemCraft[] kinds;
	// Use this for initialization
	void Start ()
	{
		if (craftShop)
			DestroyImmediate (gameObject);
		craftShop = this;
	}

	public void GetItemCanCraft (string codeItem)
	{
		LoadForge.data.GetItemCanCraft (ref itemCanCraft.itemCanCraft, codeItem);
		itemCanCraft.ShowItemCanCraft ();
	}

	public void ShowItemIngredient (string itemID)
	{
		focus.item = itemID;
	}

	//	public bool MakeNewItem (string itemID)
	//	{
	//		foreach (KindOfItemCraft kind in kinds) {
	//			if (itemID.StartsWith (kind.codeItem))
	//			if (kind.itemCraftting.CompareTo ("") == 0) {
	//				kind.itemCraftting = itemID;
	//				return true;
	//			} else
	//				return false;
	//		}
	//
	//		return false;
	//	}

	public void btn_ShowItemCanCraft (string codeItem)
	{
		CraftShopControllNew.craftShop.GetItemCanCraft (codeItem);
	}

	public void CraftItem (string item)
	{
		if (csUse)
			csUse.itemCraftting = item;
		else
			Debug.LogWarning ("Done have craft shop");
	}
}
