using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationForMonsters
{

	[SerializeField]private CharacterMonster[] _monsters;

	public CharacterMonster[] heroes{ get { return _monsters; } }

	public FormationForMonsters ()
	{
		_monsters = new CharacterMonster[6];
	}

	public CharacterMonster SetHeroesToFormation (CharacterMonster hero, int position)
	{
		CharacterMonster current = _monsters [position];

		_monsters [position] = hero;

		if (current.str == 0 && current.intel == 0 && current.agi == 0)
			return null;

		return current;
	}
}
