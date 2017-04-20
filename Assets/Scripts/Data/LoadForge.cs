using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadForge : MonoBehaviour
{
	public static LoadForge data;

	[SerializeField]private string _linkToMaterialSprite = "";
	public List<Forge> forgeList;

	public bool isLoadDone;

	void Start ()
	{
		data = this;

		forgeList = new List<Forge> ();

		StartCoroutine (LoadCharacterData ());
	}

	//Load item to datalist
	private	IEnumerator LoadCharacterData ()
	{
		isLoadDone = false;
		TextAsset xml = Resources.Load<TextAsset> ("XmlData/Forge");
		yield return xml;
		if (xml == null) {
			Debug.Log ("bug here");
		}
		XmlDocument doc = new XmlDocument ();
		doc.PreserveWhitespace = false;

		doc.LoadXml (xml.text);

		LoadListRawMaterial (doc.SelectNodes ("dataroot/Forge"));
	}


	// Converts an XmlNodeList into item objects and add to datalist
	private void LoadListRawMaterial (XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
			forgeList.Add (GetInfor (node));

		isLoadDone = true;
	}

	//	Set information for item
	private Forge GetInfor (XmlNode info)
	{
		Forge forge = new Forge ();
		XmlNode node;
		forge.idItemCraft = info.SelectSingleNode ("IDProduct").InnerText;
	
		node = info.SelectSingleNode ("IDMaterial1");
		if (node == null)
			return forge;
		forge.idIngre1 = node.InnerText;
		forge.numIngre1 = int.Parse (info.SelectSingleNode ("Number1").InnerText);

		node = info.SelectSingleNode ("IDMaterial2");
		if (node == null)
			return forge;
		forge.idIngre2 = node.InnerText;
		forge.numIngre2 = int.Parse (info.SelectSingleNode ("Number2").InnerText);

		node = info.SelectSingleNode ("IDMaterial3");
		if (node == null)
			return forge;
		forge.idIngre3 = node.InnerText;
		forge.numIngre3 = int.Parse (info.SelectSingleNode ("Number3").InnerText);

		node = info.SelectSingleNode ("IDMaterial4");
		if (node == null)
			return forge;
		forge.idIngre4 = node.InnerText;
		forge.numIngre4 = int.Parse (info.SelectSingleNode ("Number4").InnerText);

		return forge;
	}

	public Forge GetForge (string itemID)
	{
		//Forge f = ;
		return forgeList.Find (x => x.idItemCraft.CompareTo (itemID) == 0);
	}

	public void GetItemCanCraft (ref List<Forge> result, string codeItem)
	{
		result = forgeList.FindAll (x => x.idItemCraft.StartsWith (codeItem));
	}
}
