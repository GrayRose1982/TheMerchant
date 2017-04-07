using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

[System.Serializable]
public class Inventory:MonoBehaviour
{
	public static Inventory i;

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
	}

	public void AddNewItem (RawMaterialItem newItem)
	{
		_raws.Add (newItem);
	}

	public void AddNewItem (ConsumptionItem newItem)
	{
	}

	public void AddNewItem (ScrollItem newItem)
	{

	}

	public void AddNewItem (Equipment newItem)
	{
		_equipments.Add (newItem);
	}

	public void GetItem ()
	{
		
	}
}
