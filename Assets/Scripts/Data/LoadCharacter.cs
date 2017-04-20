using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Collections.ObjectModel;

public class LoadCharacter : MonoBehaviour
{
	public static LoadCharacter data;

	[SerializeField]private string _linkToEnemiesSprite = "";
	[SerializeField]private string _linkToHeroesSprite = "";

	[SerializeField]private List<CharacterMonster> _monsters;
	[SerializeField]private List<CharacterHero> _heroes;

	public ReadOnlyCollection<CharacterMonster> monsters{ get { return _monsters.AsReadOnly (); } }

	public ReadOnlyCollection<CharacterHero> heroes{ get { return _heroes.AsReadOnly (); } }

	public bool isLoadMonsterDone;
	public bool isLoadHeroDone;

	void Start ()
	{
		data = this;
		_monsters = new List<CharacterMonster> ();
		_heroes = new List<CharacterHero> ();
		StartCoroutine (LoadMonsterData ());
		StartCoroutine (LoadHeroData ());
	}

	#region Load monster

	//Load item to datalist
	private	IEnumerator LoadMonsterData ()
	{
		isLoadMonsterDone = false;
		TextAsset xml = Resources.Load<TextAsset> ("XmlData/MonsterCharacters");
		yield return xml;
		if (xml == null) {
			Debug.Log ("bug here");
		}
		XmlDocument doc = new XmlDocument ();
		doc.PreserveWhitespace = false;

		doc.LoadXml (xml.text);

		LoadListMonster (doc.SelectNodes ("dataroot/MonsterCharacters"));
	}


	// Converts an XmlNodeList into item objects and add to datalist
	private void LoadListMonster (XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
			_monsters.Add (GetInforMonster (node));

		isLoadMonsterDone = true;
	}

	//	Set information for item
	private CharacterMonster GetInforMonster (XmlNode info)
	{
		CharacterMonster character = new CharacterMonster ();
		//		string name;
		//		int str, agi, intel, atk, matk, def, mdef, acc, eva, speed;
		character.name = info.SelectSingleNode ("Name").InnerText;
		character.avatar = Resources.Load<Sprite> (_linkToEnemiesSprite + "/" + character.name);
		character.icon = Resources.Load<Sprite> (_linkToEnemiesSprite + "/icn_" + character.name);

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


	#endregion

	#region Load hero

	private	IEnumerator LoadHeroData ()
	{
		isLoadMonsterDone = false;
		TextAsset xml = Resources.Load<TextAsset> ("XmlData/HeroCharacters");
		yield return xml;
		if (xml == null) {
			Debug.Log ("bug here");
		}
		XmlDocument doc = new XmlDocument ();
		doc.PreserveWhitespace = false;

		doc.LoadXml (xml.text);

		LoadListHeroes (doc.SelectNodes ("dataroot/HeroCharacters"));
	}

	private void LoadListHeroes (XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
			_heroes.Add (GetInforHero (node));

		isLoadHeroDone = true;
	}

	//	Set information for item
	private CharacterHero GetInforHero (XmlNode info)
	{
		CharacterHero character = new CharacterHero ();
		//		string name;
		//		int str, agi, intel, atk, matk, def, mdef, acc, eva, speed;
		character.name = info.SelectSingleNode ("Name").InnerText;
		character.avatar = Resources.Load<Sprite> (_linkToHeroesSprite + "/" + character.name);
		character.icon = Resources.Load<Sprite> (_linkToHeroesSprite + "/icn_" + character.name);

		character.str = int.Parse (info.SelectSingleNode ("Str").InnerText);
		character.agi = int.Parse (info.SelectSingleNode ("Agi").InnerText);
		character.intel = int.Parse (info.SelectSingleNode ("Intel").InnerText);
//		character.atk = int.Parse (info.SelectSingleNode ("Attack").InnerText);
//		character.matk = int.Parse (info.SelectSingleNode ("MagicAttack").InnerText);
//		character.def = int.Parse (info.SelectSingleNode ("Defence").InnerText);
//		character.mdef = int.Parse (info.SelectSingleNode ("MagicDefence").InnerText);
//		character.acc = int.Parse (info.SelectSingleNode ("Accurate").InnerText);
//		character.eva = int.Parse (info.SelectSingleNode ("Evasion").InnerText);
//		character.speed = int.Parse (info.SelectSingleNode ("Speed").InnerText);

		return character;
	}

	#endregion

	public CharacterMonster GetCharacter (int index)
	{
		CharacterMonster c = new CharacterMonster ();
		if (index < _monsters.Count)
			c = new CharacterMonster (_monsters [index]);

		return c;
	}

}
