using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadEquipment : MonoBehaviour
{
	public static LoadEquipment data;

	[SerializeField]private string _linkToSpriteEquipment = "";

	public List<Equipment> equipments;

	public bool isLoadDone;

	void Start ()
	{
		data = this;

		equipments = new List<Equipment> ();

		StartCoroutine (LoadEquipmentData ());
	}

	//Load item to datalist
	private	IEnumerator LoadEquipmentData ()
	{
		isLoadDone = false;
		TextAsset xml = Resources.Load<TextAsset> ("XmlData/Equipments");
		yield return xml;
		if (xml == null) {
			Debug.Log ("We cant find xml file");
		}
		XmlDocument doc = new XmlDocument ();
		doc.PreserveWhitespace = false;

		doc.LoadXml (xml.text);

		LoadListEquipment (doc.SelectNodes ("dataroot/Equipments"));
	}


	// Converts an XmlNodeList into item objects and add to datalist
	private void LoadListEquipment (XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
			equipments.Add (GetInfor (node));

		isLoadDone = true;
	}

	//	Set information for item
	private Equipment GetInfor (XmlNode info)
	{
		Equipment equipment = new Equipment ();
		equipment.index = Ultility.Equipment + equipments.Count.ToString ();
		equipment.index = Ultility.Equipment + info.SelectSingleNode ("ID").InnerText;
		equipment.name = info.SelectSingleNode ("Name").InnerText;
		equipment.level = int.Parse (info.SelectSingleNode ("Level").InnerText);
		equipment.gold = int.Parse (info.SelectSingleNode ("Gold").InnerText);
		equipment.goldDiffer = int.Parse (info.SelectSingleNode ("GoldDiffer").InnerText);
		equipment.equipmentType = (EquipmentType)int.Parse (info.SelectSingleNode ("EquipmentType").InnerText);
		equipment.classify = (ClassifyItem)int.Parse (info.SelectSingleNode ("Classify").InnerText);

		equipment.icon = Resources.Load<Sprite> 
			(_linkToSpriteEquipment + "/" + equipment.equipmentType.ToString () + "/" + equipment.name);

		equipment.atkIncrease = int.Parse (info.SelectSingleNode ("AtkIncrease").InnerText);
		equipment.matkIncrease = int.Parse (info.SelectSingleNode ("MatkIncrease").InnerText);
		equipment.defIncrease = int.Parse (info.SelectSingleNode ("DefIncrease").InnerText);
		equipment.mdefIncrease = int.Parse (info.SelectSingleNode ("MdefIncrease").InnerText);
		equipment.evaIncrease = int.Parse (info.SelectSingleNode ("EvaIncrease").InnerText);
		equipment.accIncrease = int.Parse (info.SelectSingleNode ("AccIncrease").InnerText);
		equipment.speedIncrease = int.Parse (info.SelectSingleNode ("SpeedIncrease").InnerText);

		return equipment;
	}

	public Equipment GetEquipment (int index)
	{
		Equipment r = new Equipment ();
		if (index < equipments.Count)
			r = new Equipment (equipments [index]);

		return r;
	}

	public Equipment GetEquipment (string index)
	{
		return equipments.Find (x => x.index.CompareTo (index) == 0);
	}
}
