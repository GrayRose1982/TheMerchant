using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;
using System;

[System.Serializable]
public class Inventory : MonoBehaviour
{
	public static Inventory i;
	public static Action updateAction;

	[SerializeField]
	private List<RawMaterialItem> _raws;
	[SerializeField]
	private List<ConsumptionItem> _consumptions;
	[SerializeField]
	private List<ScrollItem> _scrolls;
	[SerializeField]
	private List<Equipment> _equipments;

	public ReadOnlyCollection<RawMaterialItem> raws { get { return _raws.AsReadOnly (); } }

	public ReadOnlyCollection<ConsumptionItem> consumptions { get { return _consumptions.AsReadOnly (); } }

	public ReadOnlyCollection<ScrollItem> scrolls { get { return _scrolls.AsReadOnly (); } }

	public ReadOnlyCollection<Equipment> equipments { get { return _equipments.AsReadOnly (); } }

	void Start ()
	{
		i = this;
		_raws = new List<RawMaterialItem> ();
		_consumptions = new List<ConsumptionItem> ();
		_scrolls = new List<ScrollItem> ();
		_equipments = new List<Equipment> ();

		StartCoroutine (AddSomeItem ());

	}

	#region Add item to inventory

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

	#endregion

	#region Get Item

	//	public BaseItem GetItem (string idItem)
	//	{
	//		if (idItem != null)
	//		if (idItem.StartsWith (Ultility.RawMaterial))
	//			return _raws.Find (x => x.index.CompareTo (idItem) == 0);
	//		else if (idItem.StartsWith (Ultility.Consumption))
	//			return _consumptions.Find (x => x.index.CompareTo (idItem) == 0);
	//		selse if (idItem.StartsWith (Ultility.Equipment))
	//			return _equipments.Find (x => x.index.CompareTo (idItem) == 0);
	////		else if (idItem.StartsWith (Ultility.Scr))
	////			return _scrolls.Find (x => x.index.CompareTo (idItem) == 0);
	//		else
	//			return null;
	//	}

	public ShadowItem GetItem (string idItem)
	{
		if (idItem != null)
		if (idItem.StartsWith (Ultility.RawMaterial))
			return new ShadowItem (_raws.Find (x => x.index.CompareTo (idItem) == 0));
		else if (idItem.StartsWith (Ultility.Consumption))
			return new ShadowItem (_consumptions.Find (x => x.index.CompareTo (idItem) == 0));
		else if (idItem.StartsWith (Ultility.Equipment))
			return new ShadowItem (_equipments.Find (x => x.index.CompareTo (idItem) == 0));

		return null;
	}

	public List<ShadowItem> GetAllItem ()
	{
		List<ShadowItem> allShadownItems = new List<ShadowItem> ();
		for (int i = 0; i < _raws.Count; i++)
			if (_raws [i].number > 0)
				allShadownItems.Add (new ShadowItem (_raws [i]));
		for (int i = 0; i < _consumptions.Count; i++)
			if (_consumptions [i].number > 0)
			if (_consumptions [i].number > 0)
				allShadownItems.Add (new ShadowItem (_consumptions [i]));
		for (int i = 0; i < _scrolls.Count; i++)
			allShadownItems.Add (new ShadowItem (_scrolls [i]));
		for (int i = 0; i < _equipments.Count; i++)
			allShadownItems.Add (new ShadowItem (_equipments [i]));
       
		return allShadownItems;
	}

	public RawMaterialItem GetRawMaterialItem (string idItem)
	{
		if (idItem != null && idItem.StartsWith (Ultility.RawMaterial)) {
			return _raws.Find (x => x.index.CompareTo (idItem) == 0);
		} else
			return null;
	}

	public ConsumptionItem GetConsumptionItem (string idItem)
	{
		if (idItem != null && idItem.StartsWith (Ultility.Consumption)) {
			return _consumptions.Find (x => x.index.CompareTo (idItem) == 0);
		} else
			return null;
	}

	public Equipment GetEquipmentItem (string idItem)
	{
		if (idItem != null && idItem.StartsWith (Ultility.Equipment)) {
			return _equipments.Find (x => x.index.CompareTo (idItem) == 0);
		} else
			return null;
	}

	/// <summary>
	/// Takes the item when craft, research and sell.
	/// </summary>
	public void TakeItem (string idItem, int number)
	{
		if (idItem.CompareTo ("") == 0)
			return;
		else
			Debug.Log ("Take item " + idItem + " with number " + number);

		if (idItem.StartsWith (Ultility.RawMaterial)) {
			_raws.Find (x => x.index.CompareTo (idItem) == 0).number -= number;
		} else if (idItem.StartsWith (Ultility.Consumption)) {
			_consumptions.Find (x => x.index.CompareTo (idItem) == 0).number -= number;
		} else if (idItem.StartsWith (Ultility.Equipment)) {
			_equipments.Remove (_equipments.Find (x => x.index.CompareTo (idItem) == 0));
		}

		if (updateAction != null)
			updateAction.Invoke ();
	}

	/// <summary>
	/// Check item for is enough to get
	/// </summary>
	public bool IsEnoughItem (string idItem, int number)
	{
		bool isEnough = false;
		if (idItem.CompareTo ("") == 0)
			return isEnough;
		else
			Debug.Log ("Check item " + idItem + " with number " + number);

		if (idItem.StartsWith (Ultility.RawMaterial)) {
			isEnough = _raws.Find (x => x.index.CompareTo (idItem) == 0).number <= number;
		} else if (idItem.StartsWith (Ultility.Consumption)) {
			isEnough = _consumptions.Find (x => x.index.CompareTo (idItem) == 0).number <= number;
		} else if (idItem.StartsWith (Ultility.Equipment)) {
			isEnough = _equipments.Exists (x => x.index.CompareTo (idItem) == 0);
		}

		return isEnough;
	}

	public bool IsEnoughItems (string[] idItems, int[] numberItems)
	{
		bool isEnough = false;
		
		for (int i = 0; i < idItems.Length; i++)
			if (i < numberItems.Length)
				isEnough &= IsEnoughItem (idItems [i], numberItems [i]);
			else
				isEnough = false;

		return isEnough;
	}

	#endregion

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


		if (updateAction != null)
			updateAction.Invoke ();
	}
}
