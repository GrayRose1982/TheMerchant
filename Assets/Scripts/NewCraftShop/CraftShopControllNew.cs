using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShopControllNew : MonoBehaviour
{
	public static CraftShopControllNew craftShop;

	[SerializeField] ItemCanCraft itemCanCraft;
	[SerializeField] MainItemFocusToCraft focus;
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
//		itemCanCraft.gameObject.SetActive (true);
	}

	public void ShowItemIngredient (string itemID)
	{
		focus.item = itemID;
	}
}
