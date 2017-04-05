using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadMaterials : MonoBehaviour
{
	public static LoadMaterials data;

	public List<RawMaterialItem> baseRawMaterial;

	public bool isLoadDone;

	void Start ()
	{
		data = this;

		baseRawMaterial = new List<RawMaterialItem> ();

		StartCoroutine (LoadCharacterData ());
	}

	//Load item to datalist
	private	IEnumerator LoadCharacterData ()
	{
		isLoadDone = false;
		TextAsset xml = Resources.Load<TextAsset> ("XmlData/RawMaterials");
		yield return xml;
		if (xml == null) {
			Debug.Log ("bug here");
		}
		XmlDocument doc = new XmlDocument ();
		doc.PreserveWhitespace = false;

		doc.LoadXml (xml.text);

		LoadListRawMaterial (doc.SelectNodes ("RawMaterials/RawMaterial"));
	}


	// Converts an XmlNodeList into item objects and add to datalist
	private void LoadListRawMaterial (XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
			baseRawMaterial.Add (GetInfor (node));

		isLoadDone = true;
	}

	//	Set information for item
	private RawMaterialItem GetInfor (XmlNode info)
	{
		RawMaterialItem rawItem = new RawMaterialItem ();

		rawItem.index = info.SelectSingleNode ("Index").InnerText;
		rawItem.name = info.SelectSingleNode ("Name").InnerText;
		rawItem.level = int.Parse (info.SelectSingleNode ("Level").InnerText);
		rawItem.gold = int.Parse (info.SelectSingleNode ("Gold").InnerText);
		rawItem.goldDiffer = int.Parse (info.SelectSingleNode ("GoldDiffer").InnerText);
		rawItem.classify = (ClassifyItem)int.Parse (info.SelectSingleNode ("Classify").InnerText);

		return rawItem;
	}

	public RawMaterialItem GetRawMaterials (int index)
	{
		RawMaterialItem r = new RawMaterialItem ();
		if (index < baseRawMaterial.Count)
			r = new RawMaterialItem (baseRawMaterial [index]);

		return r;
	}
}
