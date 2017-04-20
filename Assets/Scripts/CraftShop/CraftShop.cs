using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftShop : MonoBehaviour
{
	[SerializeField]private string _itemCrafting = "";
	public string codeItem;

	public Image icon;
	public Text nameItem;
	public Transform fillBar;

	[SerializeField]private Sprite baseSprite;

	public string itemCraftting {
		set {
			_itemCrafting = value; 
			if (_itemCrafting.CompareTo ("") == 0)
				return;

			if (_itemCrafting.StartsWith (Ultility.RawMaterial)) {
				RawMaterialItem r = LoadMaterials.data.GetRawMaterials (_itemCrafting);
				icon.sprite = r.icon;
				nameItem.text = r.name;
			} else if (_itemCrafting.StartsWith (Ultility.Consumption)) {
				ConsumptionItem c = LoadConsumptions.data.GetConsumption (_itemCrafting);
				icon.sprite = c.icon;
				nameItem.text = c.name;
			} else if (_itemCrafting.StartsWith (Ultility.Equipment)) {
				Equipment e = LoadEquipment.data.GetEquipment (_itemCrafting);
				icon.sprite = e.icon;
				nameItem.text = e.name;
			}

			isCrafting = true;
			timeCrafting = 5f;
			allTimeCraft = 5f;
		}
	}

	public bool isCrafting;
	public bool isDone;
	public ItemCanCraftPlace itemCanCraft;
	public float timeCrafting = 5f;
	public float allTimeCraft = 5f;

	void Update ()
	{
		if (!isCrafting)
			return;

		timeCrafting -= Time.deltaTime;
		float size = (allTimeCraft - timeCrafting) / allTimeCraft;
		fillBar.localScale = new Vector3 (size, 1f, 1f);

		if (timeCrafting <= 0)
			CraftDone ();
	}

	public void btn_ShowItemCanCraf ()
	{
		LoadForge.data.GetItemCanCraft (ref itemCanCraft.itemCanCraft, codeItem);
		itemCanCraft.gameObject.SetActive (true);
	}

	public void btn_GetItem ()
	{
		if (_itemCrafting.CompareTo ("") == 0)
			return;

		Debug.Log ("Add new item here");
		string shopName = "";
		if (Ultility.Equipment.CompareTo (codeItem) == 0)
			shopName = "Equipment";
		else if (Ultility.RawMaterial.CompareTo (codeItem) == 0)
			shopName = "Raw Material";
		else if (Ultility.Consumption.CompareTo (codeItem) == 0)
			shopName = "Consumption";
		else
			shopName = "Update later";
		
		itemCraftting = "";
		isCrafting = false;
		isDone = false;
		nameItem.text = shopName;

		icon.sprite = baseSprite;
		if (_itemCrafting.StartsWith (Ultility.RawMaterial))
			nameItem.text = "Raw Material";
		else if (_itemCrafting.StartsWith (Ultility.Consumption))
			nameItem.text = "Consumption";
		else if (_itemCrafting.StartsWith (Ultility.Equipment))
			nameItem.text = "Equipment";
		

		//TODO: Add new item here
//		Inventory.i.AddNewItem()
	}

	void CraftDone ()
	{
		isDone = true;
		isCrafting = false;
	}
}
