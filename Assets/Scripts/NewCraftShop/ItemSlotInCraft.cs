using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotInCraft : MonoBehaviour
{
	public bool isEnoughtNumber = true;

	[SerializeField]private string _itemString;
	[SerializeField]private int _number;
	[SerializeField]private Text txtName;
	[SerializeField]private Text txtDescription;
	[SerializeField]private Text txtNumber;

	[SerializeField] bool isInForcus;

	public Image icon;

	public string itemString {
		set {
			_itemString = value; 
			if (_itemString == null || _itemString.CompareTo ("") == 0) {
				isEnoughtNumber = true;
				gameObject.SetActive (false);
				return;
			}

			gameObject.SetActive (true);
			SetIngredientItem ();
		}
		get{ return _itemString; }
	}

	public int number {
		set {
			_number = value;
			if (txtNumber)
			if (isInForcus)
				SetNumberOfItem ();
		}

		get{ return _number; }
	}

	void OnEnable ()
	{
		if (isInForcus)
			Inventory.updateAction += SetNumberOfItem;
	}

	void OnDisable ()
	{
		if (isInForcus)
			Inventory.updateAction -= SetNumberOfItem;
	}

	void SetIngredientItem ()
	{
		if (_itemString.StartsWith (Ultility.RawMaterial)) {
			RawMaterialItem r = LoadMaterials.data.GetRawMaterials (_itemString);
			if (r == null)
				return;

			icon.sprite = r.icon;
			SetText (txtName, r.name);
			SetText (txtDescription, r.description);
		} else if (_itemString.StartsWith (Ultility.Consumption)) {
			ConsumptionItem c = LoadConsumptions.data.GetConsumption (_itemString);
			if (c == null)
				return;
			icon.sprite = c.icon;
			SetText (txtName, c.name);
			SetText (txtDescription, c.description);
		} else if (_itemString.StartsWith (Ultility.Equipment)) {
			Equipment e = LoadEquipment.data.GetEquipment (_itemString);
			if (e == null)
				return;
			icon.sprite = e.icon;
			SetText (txtName, e.name);
			SetText (txtDescription, e.description);
		}
	}

	/// <summary>
	/// Set string to text field
	/// </summary>
	void SetText (Text text, string str)
	{
		if (text)
			text.text = str;
	}

	public void btn_ShowItemIngredient ()
	{
		CraftShopControllNew.craftShop.ShowItemIngredient (_itemString);
	}

	void SetNumberOfItem ()
	{
		int numberInInventory = 0;
		if (Inventory.i.GetRawMaterialItem (_itemString) != null)
			numberInInventory = Inventory.i.GetRawMaterialItem (_itemString).number;

		if (isEnoughtNumber = numberInInventory >= _number)
			txtNumber.color = Color.white;
		else
			txtNumber.color = Color.red;

		txtNumber.text = numberInInventory.ToString () + "/" + _number.ToString ();
	}
}
