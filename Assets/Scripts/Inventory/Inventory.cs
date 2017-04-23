using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;
using System;

[System.Serializable]
public class Inventory:MonoBehaviour
{
	public static Inventory i;
	public static Action updateAction;

	[SerializeField]private List<RawMaterialItem> _raws;
	[SerializeField]private List<ConsumptionItem> _consumptions;
	[SerializeField]private List<ScrollItem> _scrolls;
	[SerializeField]private List<Equipment> _equipments;

	public ReadOnlyCollection<RawMaterialItem> raws{ get { return _raws.AsReadOnly (); } }

	public ReadOnlyCollection<ConsumptionItem> consumptions{ get { return _consumptions.AsReadOnly (); } }

	public ReadOnlyCollection<ScrollItem> scrolls{ get { return _scrolls.AsReadOnly (); } }

	public ReadOnlyCollection<Equipment> equipments{ get { return _equipments.AsReadOnly (); } }


	void Start ()
	{
		i = this;
		_raws = new List<RawMaterialItem> ();
		_consumptions = new List<ConsumptionItem> ();
		_scrolls = new List<ScrollItem> ();
		_equipments = new List<Equipment> ();

		StartCoroutine (AddSomeItem ());
	}

	public void AddNewItem (RawMaterialItem newItem)
	{
		int id = _raws.FindIndex (x => x.index.CompareTo (newItem.index) == 0);
		if (id >= 0)
			_raws [id].number += newItem.number;
		else
			_raws.Add (newItem);
	
		if (updateAction != null)
			updateAction.Invoke ();
	}

	public void AddNewItem (ConsumptionItem newItem)
	{
		_consumptions.Add (newItem);

		if (updateAction != null)
			updateAction.Invoke ();
	}

	public void AddNewItem (ScrollItem newItem)
	{
		_scrolls.Add (newItem);
	
	}

	public void AddNewItem (Equipment newItem)
	{
		_equipments.Add (newItem);
	}

	public void GetItem ()
	{
		
	}

	public RawMaterialItem GetRawMaterialItem (string index)
	{
		if (index != null && index.StartsWith (Ultility.RawMaterial)) {
			return _raws.Find (x => x.index.CompareTo (index) == 0);
		} else
			return null;
	}

	public ConsumptionItem GetConsumptionItem (string index)
	{
		if (index != null && index.StartsWith (Ultility.Consumption)) {
			return _consumptions.Find (x => x.index.CompareTo (index) == 0);
		} else
			return null;
	}

	public Equipment GetEquipmentItem (string index)
	{
		if (index != null && index.StartsWith (Ultility.Equipment)) {
			return _equipments.Find (x => x.index.CompareTo (index) == 0);
		} else
			return null;
	}

	public void TakeItem (string itemIndex, int number)
	{
		if (itemIndex.CompareTo ("") == 0)
			return;

		if (itemIndex.StartsWith (Ultility.RawMaterial)) {
			_raws.Find (x => x.index.CompareTo (itemIndex) == 0).number -= number;
		} else if (itemIndex.StartsWith (Ultility.Consumption)) {
			_raws.Find (x => x.index.CompareTo (itemIndex) == 0).number -= number;
		}
		
		if (updateAction != null)
			updateAction.Invoke ();
	}

	IEnumerator AddSomeItem ()
	{
		while (!LoadMaterials.data || !LoadMaterials.data.isLoadDone)
			yield return new WaitForSeconds (.5f);
			
		_raws.Add (new RawMaterialItem (LoadMaterials.data.GetRawMaterials ("RM1"), 10));
		_raws.Add (new RawMaterialItem (LoadMaterials.data.GetRawMaterials ("RM2"), 10));
		_raws.Add (new RawMaterialItem (LoadMaterials.data.GetRawMaterials ("RM3"), 10));
		_raws.Add (new RawMaterialItem (LoadMaterials.data.GetRawMaterials ("RM9"), 4));
		_raws.Add (new RawMaterialItem (LoadMaterials.data.GetRawMaterials ("RM12"), 4));
		_raws.Add (new RawMaterialItem (LoadMaterials.data.GetRawMaterials ("RM13"), 4));
		_raws.Add (new RawMaterialItem (LoadMaterials.data.GetRawMaterials ("RM14"), 10));
	}
}
