using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadConsumptions : MonoBehaviour
{
	public static LoadConsumptions data;

	[SerializeField]private string _linkToMaterialSprite = "";
	public List<ConsumptionItem> consumptions;

	public bool isLoadDone;

	void Start ()
	{
		data = this;

		consumptions = new List<ConsumptionItem> ();

		StartCoroutine (LoadCharacterData ());
	}

	//Load item to datalist
	private	IEnumerator LoadCharacterData ()
	{
		isLoadDone = false;
		TextAsset xml = Resources.Load<TextAsset> ("XmlData/Consumptions");
		yield return xml;
		if (xml == null) {
			Debug.Log ("bug here");
		}
		XmlDocument doc = new XmlDocument ();
		doc.PreserveWhitespace = false;

		doc.LoadXml (xml.text);

		LoadListRawMaterial (doc.SelectNodes ("dataroot/Consumptions"));
	}


	// Converts an XmlNodeList into item objects and add to datalist
	private void LoadListRawMaterial (XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
			consumptions.Add (GetInfor (node));

		isLoadDone = true;
	}

	//	Set information for item
	private ConsumptionItem GetInfor (XmlNode info)
	{
		ConsumptionItem consumption = new ConsumptionItem ();
		consumption.index = Ultility.Consumption + consumptions.Count.ToString ();
		//		rawItem.index = info.SelectSingleNode ("Index").InnerText;
		consumption.name = info.SelectSingleNode ("Name").InnerText;
		consumption.icon = Resources.Load<Sprite> (_linkToMaterialSprite + "/" + consumption.name);
		consumption.level = int.Parse (info.SelectSingleNode ("Level").InnerText);
		consumption.gold = int.Parse (info.SelectSingleNode ("Gold").InnerText);
		consumption.goldDiffer = int.Parse (info.SelectSingleNode ("GoldDiffer").InnerText);
		consumption.classify = (ClassifyItem)int.Parse (info.SelectSingleNode ("Classify").InnerText);
		consumption.numberHealing = int.Parse (info.SelectSingleNode ("NumberHealing").InnerText);
		consumption.numberPoison = int.Parse (info.SelectSingleNode ("NumberPoision").InnerText);

		return consumption;
	}

	public ConsumptionItem GetConsumption (int index)
	{
		ConsumptionItem c = new ConsumptionItem ();
		if (index < consumptions.Count)
			c = new ConsumptionItem (consumptions [index]);

		return c;
	}

	public ConsumptionItem GetConsumption (string index)
	{
		return consumptions.Find (x => x.index.CompareTo (index) == 0);
	}
}
