using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCanCraftPlace : MonoBehaviour
{
	public static ItemCanCraftPlace itemCanCraftShop;

	public GridLayoutGroup grid;
	public GameObject baseIngredientObject;
	public Transform scroll;

	public List<Forge> itemCanCraft;
	public List<IngredientItem> showItem;

	void OnEnable ()
	{
		ShowItemCanCraft ();
		SetGrid ();
	}

	void Start ()
	{
		itemCanCraftShop = this;
	}

	void ShowItemCanCraft ()
	{
		for (int i = 0; i < itemCanCraft.Count; i++) {
			if (i >= showItem.Count) {
				GameObject g = Instantiate (baseIngredientObject, scroll) as GameObject;
				g.transform.localScale = Vector3.one;
				showItem.Add (g.GetComponent<IngredientItem> ());
			}

			showItem [i].gameObject.SetActive (true);
			showItem [i].itemString = itemCanCraft [i].idItemCraft;
		}

		int diff = showItem.Count - itemCanCraft.Count;
		if (diff > 0)
			for (int i = itemCanCraft.Count; i < showItem.Count; i++) {
				showItem [i].gameObject.SetActive (false);
			}
	}

	public void btn_ShowIngredient ()
	{
		CraftShopController.controller.TurnOnIngredientCV ();
	}

	void SetGrid ()
	{
//		grid.padding.left = (int)Screen.width / 2;	//+ (int)grid.cellSize.x / 2;
//		grid.padding.right = (int)Screen.width / 2; //+ (int)grid.cellSize.x / 2;
		int child = transform.childCount;
		float sizeY = grid.padding.top + grid.padding.bottom + (child) * grid.cellSize.y + (child) * grid.spacing.y;
		Vector2 size = new Vector2 (grid.cellSize.y, sizeY);
		grid.GetComponent<RectTransform> ().sizeDelta = size;
		//		sizeX = Screen.width;
	}
}
