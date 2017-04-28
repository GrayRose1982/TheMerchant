using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCanCraft : MonoBehaviour
{
	public GridLayoutGroup grid;
	public float sizeGird;
	public GameObject baseIngredientObject;
	public Transform scroll;

	public List<Forge> itemCanCraft;
	public List<ItemInCraftShop> showItem;

	//	void OnEnable ()
	//	{
	//		ShowItemCanCraft ();
	////		SetGrid ();
	//	}

	void Start ()
	{
	}

	public void ShowItemCanCraft ()
	{
		for (int i = 0; i < itemCanCraft.Count; i++) {
			if (i >= showItem.Count) {
				GameObject g = Instantiate (baseIngredientObject, scroll) as GameObject;
				g.transform.localScale = Vector3.one;
				showItem.Add (g.GetComponent<ItemInCraftShop> ());
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

	void SetGrid ()
	{
		int child = scroll.childCount;
		int number = grid.constraintCount;
		int numberRow = child / number;
		float sizeY = grid.padding.top + grid.padding.bottom + numberRow * grid.cellSize.y + numberRow * grid.spacing.y;
		Vector2 size = new Vector2 (grid.cellSize.x, sizeY);
		grid.GetComponent<RectTransform> ().sizeDelta = size;
	}
}
