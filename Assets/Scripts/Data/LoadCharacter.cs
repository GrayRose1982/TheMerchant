using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadCharacter : MonoBehaviour
{
	public static LoadCharacter data;

	public List<BaseCharacter> baseCharacterData;

	public bool isLoadDone;

	void Start ()
	{
		data = this;

		baseCharacterData = new List<BaseCharacter> ();

		StartCoroutine (LoadCharacterData ());
	}

	//Load item to datalist
	private	IEnumerator LoadCharacterData ()
	{
		isLoadDone = false;
		TextAsset xml = Resources.Load<TextAsset> ("XmlData/Character");
		yield return xml;
		if (xml == null) {
			Debug.Log ("bug here");
		}
		XmlDocument doc = new XmlDocument ();
		doc.PreserveWhitespace = false;

		doc.LoadXml (xml.text);

		LoadListMissile (doc.SelectNodes ("dataset/Character"));
	}


	// Converts an XmlNodeList into item objects and add to datalist
	private void LoadListMissile (XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
			baseCharacterData.Add (GetInfor (node));
		
		isLoadDone = true;
	}

	//	Set information for item
	private BaseCharacter GetInfor (XmlNode info)
	{
		BaseCharacter character = new BaseCharacter ();
//		string name;
//		int str, agi, intel, atk, matk, def, mdef, acc, eva, speed;

		character.name = info.SelectSingleNode ("Name").InnerText;
		character.str = int.Parse (info.SelectSingleNode ("Str").InnerText);
		character.agi = int.Parse (info.SelectSingleNode ("Agi").InnerText);
		character.intel = int.Parse (info.SelectSingleNode ("Intel").InnerText);
		character.atk = int.Parse (info.SelectSingleNode ("Attack").InnerText);
		character.matk = int.Parse (info.SelectSingleNode ("MagicAttack").InnerText);
		character.def = int.Parse (info.SelectSingleNode ("Defence").InnerText);
		character.mdef = int.Parse (info.SelectSingleNode ("MagicDefence").InnerText);
		character.acc = int.Parse (info.SelectSingleNode ("Accurate").InnerText);
		character.eva = int.Parse (info.SelectSingleNode ("Evasion").InnerText);
		character.speed = int.Parse (info.SelectSingleNode ("Speed").InnerText);

		return character;
	}

	public BaseCharacter GetCharacter (int index)
	{
		BaseCharacter c = new BaseCharacter ();
		if (index < baseCharacterData.Count)
			c = new BaseCharacter (baseCharacterData [index]);

		return c;
	}
}
