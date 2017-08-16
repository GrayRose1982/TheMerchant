using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientItem : MonoBehaviour
{
	[SerializeField]private string _itemString;
	[SerializeField]private int _number;
	[SerializeField]private Text txtName;
	[SerializeField]private Text txtDescription;
	[SerializeField]private Text txtNumber;

	public Image icon;

	public string itemString {
		set {
			_itemString = value; 
			if (_itemString == null || _itemString.CompareTo ("") == 0) {
				gameObject.SetActive (false);
				return;
			}

			gameObject.SetActive (true);
			SetIngredientItem ();
		}
	}

	public int number {
		set {
			_number = value;
			txtNumber.text = "x" + _number.ToString ();
		}
	}

	void SetIngredientItem ()
	{
		if (_itemString.StartsWith (Ultility.RawMaterial)) {
			RawMaterialItem r = LoadMaterials.data.GetRawMaterials (_itemString);
			if (r == null)
				return;
			
			icon.sprite = r.icon;
			txtName.text = r.name;
			txtDescription.text = r.description;
		} else if (_itemString.StartsWith (Ultility.Consumption)) {
			ConsumptionItem c = LoadConsumptions.data.GetConsumption (_itemString);
			if (c == null)
				return;
			icon.sprite = c.icon;
			txtName.text = c.name;
			txtDescription.text = c.description;
		} else if (_itemString.StartsWith (Ultility.Equipment)) {
			Equipment e = LoadEquipment.data.GetEquipment (_itemString);
			if (e == null)
				return;
			icon.sprite = e.icon;
			txtName.text = e.name;
			txtDescription.text = e.description;
		}
	}

	public void btn_ShowIngredient ()
	{
	}

	public void btn_SendItemCraft ()
	{
	}
}
