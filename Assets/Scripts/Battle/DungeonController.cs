﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour
{
	public static DungeonController dungeon;

	public FormationBattleMonsters mons;
	public List<CharacterMonster> monsters;
	public List<FormationForMonsters> formations;

	//	public MonsterBattle[] monsterInformation;

	void Start ()
	{
		monsters = new List<CharacterMonster> ();
		formations = new List<FormationForMonsters> ();
		dungeon = this;
		StartCoroutine (AddSomeHero ());
	}

	IEnumerator AddSomeHero ()
	{
		while (!LoadCharacter.data)
			yield return new WaitForSeconds (.5f);

		while (!LoadCharacter.data.isLoadHeroDone)
			yield return new WaitForSeconds (.5f);

		monsters.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		monsters.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		monsters.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		monsters.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		monsters.Add (new CharacterMonster (LoadCharacter.data.monsters [1]));

		SetForamtion ();
	}

	void SetForamtion ()
	{
		FormationForMonsters formation = new FormationForMonsters ();
		formation.AddCharacter (monsters [0], 0, LineInFormtaion.Front);
		formation.AddCharacter (monsters [1], 1, LineInFormtaion.Front);
		formation.AddCharacter (monsters [2], 2, LineInFormtaion.Front);
		formation.AddCharacter (monsters [3], 3, LineInFormtaion.Front);
		formation.AddCharacter (monsters [4], 4, LineInFormtaion.Front);
//		formation.AddCharacter (monsters [5], 5, LineInFormtaion.Front);

		formations.Add (formation);
		SetUIFormation ();
	}

	void SetUIFormation ()
	{
		mons.SetFormation (formations [0]);
	}
}
