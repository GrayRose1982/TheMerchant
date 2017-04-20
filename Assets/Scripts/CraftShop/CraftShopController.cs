using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShopController : MonoBehaviour
{
	public static CraftShopController controller;
	public ItemCanCraftPlace canCraft;
	public IngredientCV ingreCV;

	public CraftShop[] crafts;

	void Start ()
	{
		controller = this;
	}

	public void GetCraftItem (string indexItem)
	{
		for (int i = 0; i < crafts.Length; i++)
			if (indexItem.StartsWith (crafts [i].codeItem)) {
				crafts [i].itemCraftting = indexItem;
				break;
			}
	}

	public void TurnOnIngredientCV ()
	{
		ingreCV.gameObject.SetActive (true);
	}

	public void SearchItemCanCraft (string itemID)
	{
		ingreCV.item = itemID;
	}
}
