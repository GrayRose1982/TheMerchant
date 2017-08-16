using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCV : MonoBehaviour
{
	public IngredientItem craftItem;
	public IngredientItem[] IngredientItems;

	private string _item;

	public string item {
		set {
			_item = value; 
			craftItem.itemString = _item;
			ChangeItemIngredient ();
		}
		get { return _item; }
	}

	void ChangeItemIngredient ()
	{
		Forge f = LoadForge.data.GetForge (_item);

		IngredientItems [0].itemString = f.idIngre1;
		IngredientItems [1].itemString = f.idIngre2;
		IngredientItems [2].itemString = f.idIngre3;
		IngredientItems [3].itemString = f.idIngre4;

		IngredientItems [0].number = f.numIngre1;
		IngredientItems [1].number = f.numIngre2;
		IngredientItems [2].number = f.numIngre3;
		IngredientItems [3].number = f.numIngre4;
	}

}
