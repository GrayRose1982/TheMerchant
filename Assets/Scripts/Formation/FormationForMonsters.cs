using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FormationForMonsters
{
	[SerializeField]private CharacterMonster[] _monsters;

	public CharacterMonster[] monsters{ get { return _monsters; } }

	public FormationForMonsters ()
	{
		_monsters = new CharacterMonster[30];
	}

	public CharacterMonster SetHeroesToFormation (CharacterMonster hero, int position)
	{
		CharacterMonster current = _monsters [position];

		_monsters [position] = hero;

		if (current.str == 0 && current.intel == 0 && current.agi == 0)
			return null;

		return current;
	}

	public void AddCharacter (BaseCharacter c, int position, LineInFormtaion line)
	{
		c.line = line;
		CharacterMonster m = new CharacterMonster (c);
		_monsters [position] = m;
//		_monsters [position].line = line;
	}
}
